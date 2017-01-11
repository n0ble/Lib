using System;
using System.Collections.Generic;

namespace Lib.Web.Models.ViewModels
{
	public class BooksListViewModel
	{
		public IEnumerable<Book> Books { get; set; }
		public PagingInfo PagingInfo { get; set; }
		public string CurrentGenre { get; set; }
		public IEnumerable<Genre> Genres { get; set; }
	}
}