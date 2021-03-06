//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lib.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            this.Authors = new HashSet<Author>();
            this.Genres = new HashSet<Genre>();
            this.Interpreters = new HashSet<Interpreter>();
            this.Publishers = new HashSet<Publisher>();
            this.Tags = new HashSet<Tag>();
            this.FileFormats = new HashSet<FileFormat>();
        }
    
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Annotation { get; set; }
        public Nullable<short> Rating { get; set; }
        public Nullable<System.Guid> SeriesId { get; set; }
        public Nullable<short> PagesNumber { get; set; }
        public Nullable<System.DateTime> PublishedOn { get; set; }
        public Nullable<System.DateTime> TranslatedOn { get; set; }
        public Nullable<System.DateTime> ReleasedOn { get; set; }
        public Nullable<System.Guid> LanguageId { get; set; }
        public Nullable<System.Guid> CoutryId { get; set; }
    
        public virtual Country Country { get; set; }
        public virtual Language Language { get; set; }
        public virtual Series Series { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Author> Authors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Genre> Genres { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Interpreter> Interpreters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Publisher> Publishers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FileFormat> FileFormats { get; set; }
    }
}
