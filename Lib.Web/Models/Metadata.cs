using System.ComponentModel.DataAnnotations;

namespace Lib.Web.Models
{
	public class TagMetadata
	{
		[Required(ErrorMessageResourceType = typeof(Resources.Resource),
		  ErrorMessageResourceName = "NameRequired")]
		[Display(Name = "Name", ResourceType = typeof(Resources.Resource))]
		public string Name { get; set; }
	}
}