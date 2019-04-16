using Pecka_Soundcloud.Code;
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
    public class SongEditorViewModel : IValidatableObject
    {

		public SongEditorViewModel()
        {
        }

        public SongEditorViewModel(Song song)
        {
            this.Name = song.Name;
            this.Type = song.Type;
            this.ReleaseDate = song.ReleaseDate;
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

        internal void UpdateEntity(Song song)
        {
            song.Name = this.Name;
            song.ReleaseDate = this.ReleaseDate;
            song.Type = this.Type;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));

            var song = context.Songs.FirstOrDefault(c => c.Id == this.Id);

            if (song == null)
                yield return new ValidationResult("💦💦💦💦", new string[] { nameof(this.Id) });

            if (song != null && song.Album.ReleaseDate > this.ReleaseDate)
                yield return new ValidationResult("jujky co pak tu děláš za brikule", new string[] { nameof(this.ReleaseDate) });
        }
    }
}
