using System.Linq;
using System.Web.Mvc;
using Lib.Web.Models.Repos;

namespace Lib.Web.Controllers
{
    public class NavController : Controller
    {
		private UnitOfWork _unitOfWork = new UnitOfWork();

		public PartialViewResult Menu()
		{
			var genres = _unitOfWork.GenresRepository
				.Get()
				.OrderBy(g => g.Name)
				.Select(g => g.Name);

			return PartialView(genres);
		}
	}

}