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
		private GenericRepository<Genre> _genresRepository;
		private GenericRepository<FileFormat> _fileFormatsRepository;

		public GenericRepository<Book> BooksRepository => _booksRepository ?? (_booksRepository = new GenericRepository<Book>(context));

		public GenericRepository<Country> CountriesRepository => _countriesRepository ?? (_countriesRepository = new GenericRepository<Country>(context));

		public GenericRepository<Language> LanguagesRepository => _languagessRepository ?? (_languagessRepository = new GenericRepository<Language>(context));

		public GenericRepository<Series> SeriesRepository => _seriesRepository ?? (_seriesRepository = new GenericRepository<Series>(context));

		public GenericRepository<Tag> TagsRepository => _tagsRepository ?? (_tagsRepository = new GenericRepository<Tag>(context));

		public GenericRepository<Genre> GenresRepository => _genresRepository ?? (_genresRepository = new GenericRepository<Genre>(context));

		public GenericRepository<FileFormat> FileformatsRepository => _fileFormatsRepository ?? (_fileFormatsRepository = new GenericRepository<FileFormat>(context));

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