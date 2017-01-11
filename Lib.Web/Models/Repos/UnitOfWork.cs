using System;

namespace Lib.Web.Models.Repos
{
	public class UnitOfWork : IDisposable
	{
		private Entities context = new Entities();
		private GenericRepository<Book> _booksRepository;
		private GenericRepository<Tag> _tagsRepository;
		private GenericRepository<Country> _countriesRepository;
		private GenericRepository<Language> _languagessRepository;
		private GenericRepository<Series> _seriesRepository;

		public GenericRepository<Book> BooksRepository
		{
			get
			{

				if (_booksRepository == null)
				{
					_booksRepository = new GenericRepository<Book>(context);
				}
				return _booksRepository;
			}
		}

		public GenericRepository<Country> CountriesRepository
		{
			get
			{

				if (_countriesRepository == null)
				{
					_countriesRepository = new GenericRepository<Country>(context);
				}
				return _countriesRepository;
			}
		}

		public GenericRepository<Language> LanguagesRepository
		{
			get
			{

				if (_languagessRepository == null)
				{
					_languagessRepository = new GenericRepository<Language>(context);
				}
				return _languagessRepository;
			}
		}

		public GenericRepository<Series> SeriesRepository
		{
			get
			{

				if (_seriesRepository == null)
				{
					_seriesRepository = new GenericRepository<Series>(context);
				}
				return _seriesRepository;
			}
		}

		public GenericRepository<Tag> TagsRepository
		{
			get
			{

				if (_tagsRepository == null)
				{
					_tagsRepository = new GenericRepository<Tag>(context);
				}
				return _tagsRepository;
			}
		}

		public void Save()
		{
			context.SaveChanges();
		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					context.Dispose();
				}
			}
			disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}