using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Lib.Web.Models;
using Lib.Web.Models.Repos;
using Lib.Web.Models.ViewModels;

namespace Lib.Web.Controllers
{
	public class BooksController : Controller
    {
        //private Entities db = new Entities();
		private UnitOfWork _unitOfWork = new UnitOfWork();
	    private GenericRepository<Book> _repo;

		private const int _defaultPageSize = 3;

	    public BooksController()
	    {
		    _repo = _unitOfWork.BooksRepository;


		}

        // GET: Books
        public ActionResult Index(string genre, int page = 1)
        {
			BooksListViewModel model = new BooksListViewModel
			{
				Books = _repo
				.Get(includeProperties: "Country,Language,Series,Genres")
				.Where(b => genre == null || b.Genres.Select(g => g.Name).ToList().Contains(genre))
				.OrderBy(b => b.ISBN)
				.Skip((page - 1) * _defaultPageSize)
				.Take(_defaultPageSize)
				.ToList(),
				PagingInfo = new PagingInfo
				{
					CurrentPage = page,
					ItemsPerPage = _defaultPageSize,
					TotalItems = genre == null ? _repo.Get().Count() : _repo.Get().Count(b => b.Genres.Select(g => g.Name).ToList().Contains(genre))
				},
				Genres = _unitOfWork.GenresRepository.Get(),
				CurrentGenre = genre
			};
			return View(model);
		}



        // GET: Books/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book =_repo.GetByID(id);
            if (book == null)
            {
                return HttpNotFound();
            }
	        ViewBag.ExistingFileFormats = _unitOfWork
				.FileformatsRepository
				.Get()
				.Where(ff => ff.Books.Contains(book));

            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.CoutryId = new SelectList(_unitOfWork.CountriesRepository.Get(), "Id", "Name");
            ViewBag.LanguageId = new SelectList(_unitOfWork.LanguagesRepository.Get(), "Id", "Name");
            ViewBag.SeriesId = new SelectList(_unitOfWork.SeriesRepository.Get(), "Id", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ISBN,Name,Annotation,Rating,SeriesId,PagesNumber,PublishedOn,TranslatedOn,ReleasedOn,LanguageId,CoutryId")] Book book)
        {
            if (ModelState.IsValid)
            {
				_repo.Insert(book);
				_unitOfWork.Save();
                return RedirectToAction("Index");
            }

            ViewBag.CoutryId = new SelectList(_unitOfWork.CountriesRepository.Get(), "Id", "Name", book.CoutryId);
            ViewBag.LanguageId = new SelectList(_unitOfWork.LanguagesRepository.Get(), "Id", "Name", book.LanguageId);
            ViewBag.SeriesId = new SelectList(_unitOfWork.SeriesRepository.Get(), "Id", "Name", book.SeriesId);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _repo.GetByID(id);
			if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.CoutryId = new SelectList(_unitOfWork.CountriesRepository.Get(), "Id", "Name", book.CoutryId);
            ViewBag.LanguageId = new SelectList(_unitOfWork.LanguagesRepository.Get(), "Id", "Name", book.LanguageId);
            ViewBag.SeriesId = new SelectList(_unitOfWork.SeriesRepository.Get(), "Id", "Name", book.SeriesId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ISBN,Name,Annotation,Rating,SeriesId,PagesNumber,PublishedOn,TranslatedOn,ReleasedOn,LanguageId,CoutryId")] Book book)
        {
            if (ModelState.IsValid)
            {
				_repo.Update(book);
				_unitOfWork.Save();
				return RedirectToAction("Index");
            }
            ViewBag.CoutryId = new SelectList(_unitOfWork.CountriesRepository.Get(), "Id", "Name", book.CoutryId);
            ViewBag.LanguageId = new SelectList(_unitOfWork.LanguagesRepository.Get(), "Id", "Name", book.LanguageId);
            ViewBag.SeriesId = new SelectList(_unitOfWork.SeriesRepository.Get(), "Id", "Name", book.SeriesId);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			Book book = _repo.GetByID(id);
			if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
			Book book = _repo.GetByID(id);
			_repo.Delete(book);
			_unitOfWork.Save();
            return RedirectToAction("Index");
        }


		[HttpPost]
		public JsonResult UploadFile(string id)
		{

			var book = _repo.GetByID(id);
			if (book == null)
			{
				throw new ArgumentException("id");
			}
			

			try
			{
				foreach (string file in Request.Files)
				{
					var fileContent = Request.Files[file];

					if (fileContent != null && fileContent.ContentLength > 0)
					{
						var extension = Path.GetExtension(fileContent.FileName);
						// get a stream
						var stream = fileContent.InputStream;
						// and optionally write the file to disk
						var fileName = string.Concat(id, extension);
						var path = Path.Combine(Server.MapPath("~/App_Data/Uploads"), fileName);
						using (var fileStream = System.IO.File.Create(path))
						{
							stream.CopyTo(fileStream);
						}
						var tmp = _unitOfWork
							.FileformatsRepository
							.Get();

						var fileFormat = _unitOfWork
							.FileformatsRepository
							.Get()
							.FirstOrDefault(f => string.Equals(f.Name,
											extension?.Substring(1),
											StringComparison.InvariantCultureIgnoreCase));

						book.FileFormats.Add(fileFormat);
						_repo.Update(book);
						_unitOfWork.Save();
					}
				}
			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return Json("Upload failed");
			}

			return Json("File uploaded successfully");
		}

		[HttpGet]
		public virtual FileResult DownloadFile(string id)
		{
			string fullPath = Path.Combine(Server.MapPath("~/App_Data/Uploads"), id);
			return File(fullPath, MimeMapping.GetMimeMapping(fullPath), id);
		}

		protected override void Dispose(bool disposing)
        {
			_unitOfWork.Dispose();
			base.Dispose(disposing);
		}
    }
}
