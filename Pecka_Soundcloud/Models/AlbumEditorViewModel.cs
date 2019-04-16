using Pecka_Soundcloud.Data;
using Pecka_Soundcloud.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pecka_Soundcloud.Models
{
        public class AlbumEditorViewModel : IValidatableObject
        {

            public AlbumEditorViewModel()
            {
            }

            public AlbumEditorViewModel(Album album)
            {
                this.Id = album.Id;
                this.Name = album.Name;
                this.ReleaseDate = album.ReleaseDate;
            }

            public int Id
            {
                get;
                set;
            }

            [Required]
            [DisplayName("Název")]
            public string Name
            {
                get;
                set;
            }

            [Required]
            [DisplayName("Založeno")]
            public DateTime ReleaseDate
            {
                get;
                set;
            }



            public void UpdateEntity(Album album)
            {

                album.Name = this.Name;
                album.ReleaseDate = this.ReleaseDate;
            }

            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                var context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));

                var album = context.Albums.FirstOrDefault(b => b.Id == this.Id);

                if (album == null)
                    yield return new ValidationResult("frajere to asi ne žejo", new string[] { nameof(Id) });

                if (album != null && album.Songs.Any(c => c.ReleaseDate < this.ReleaseDate))
                    yield return new ValidationResult("nevím co chceš", new string[] { nameof(ReleaseDate) });
            }
        
    }
}
