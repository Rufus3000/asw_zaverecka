using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pecka_Soundcloud.Entities
{
    public class Album
    {
        public Album()
        {
            this.Songs = new List<Song>();
        }


        [Key]
        public int Id
        {
            get;
            set;
        }

        [Required]
        public string Name
        {
            get;
            set;
        }

        [Required]
        public DateTime ReleaseDate
        {
            get;
            set;
        }

        public virtual ICollection<Song> Songs
        {
            get;
            set;
        }

        public static Album Create(string name, DateTime releaseDate)
        {
            var model = new Album()
            {
                Name = name,
                ReleaseDate = releaseDate,

            };

            return model;
        }
    }
}
