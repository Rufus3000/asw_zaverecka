using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pecka_Soundcloud.Entities
{
    public class Interpret
    {
        public Interpret()
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
        public string Country
        {
            get;
            set;
        }

        public virtual ICollection<Song> Songs
        {
            get;
            set;
        }

        public static Interpret Create(string name, string country)
        {
            var model = new Interpret()
            {
                Name = name,
                Country = country,

            };

            return model;
        }
    }
}
