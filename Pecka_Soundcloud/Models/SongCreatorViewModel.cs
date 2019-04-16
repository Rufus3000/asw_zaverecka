using Pecka_Soundcloud.Code;
using Pecka_Soundcloud.Data;
using Pecka_Soundcloud.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pecka_Soundcloud.Models
{
    public class SongCreatorViewModel : IValidatableObject
    {
        public SongCreatorViewModel()
        {
            this.ReleaseDate = DateTime.Today;
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
        [DisplayName("Datum vydání")]
        public DateTime ReleaseDate
        {
            get;
            set;
        }

        [Required]
        [DisplayName("Žánr songu")]
        public SongGenre Type
        {
            get;
            set;
        }

        [Required]
        [DisplayName("Album")]
        public int AlbumId
        {
            get;
            set;
        }

        [Required]
        [DisplayName("Interpret")]
        public int InterpretId
        {
            get;
            set;
        }
        [NotMapped]
        public Dictionary<int, string> Albums
        {
            get;
            set;
        }
        [NotMapped]
        public Dictionary<int, string> Interprets
        {
            get;
            set;
        }

        public Song CreateEntity()
        {
            return Song.Create(this.Name, this.ReleaseDate, this.Type, this.AlbumId, this.InterpretId);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));

            var album = context.Albums.FirstOrDefault(b => b.Id == this.AlbumId);

            if (album == null)
                yield return new ValidationResult("🐒🐒🐒🐒🐒", new string[] { nameof(this.AlbumId) });

            if (album != null && album.ReleaseDate > this.ReleaseDate)
                yield return new ValidationResult("song před albem? nn", new string[] { nameof(this.ReleaseDate) });

            var interpret = context.Interprets.FirstOrDefault(b => b.Id == this.InterpretId);

            if (interpret == null)
                yield return new ValidationResult("🐒🐒🐒🐒🐒", new string[] { nameof(this.InterpretId) });

        }
    }
}
