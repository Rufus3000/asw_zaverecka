using Pecka_Soundcloud.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pecka_Soundcloud.Models
{
    public class AlbumCreatorViewModel
    {
        public AlbumCreatorViewModel()
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
        [DisplayName("Vydáno")]
        public DateTime ReleaseDate
        {
            get;
            set;
        }
        public Album CreateEntity()
        {
            var album = Album.Create(this.Name, this.ReleaseDate);

            return album;
        }
    }
}
