using Pecka_Soundcloud.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pecka_Soundcloud.Entities
{
    public class Song
    {

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

        [Required]
        public SongGenre Type
        {
            get;
            set;
        }


        [Required]
        public int AlbumId
        {
            get;
            set;
        }

        [Required]
        public int InterpretId
        {
            get;
            set;
        }

        [ForeignKey(nameof(AlbumId))]
        public virtual Album Album
        {
            get;
            set;
        }

        [ForeignKey(nameof(InterpretId))]
        public virtual Interpret Interpret
        {
            get;
            set;
        }

        public static Song Create(string name, DateTime date, SongGenre type, int album, int interpret)
        {
            return new Song()
            {
                Name = name,
                ReleaseDate = date,
                Type = type,
                AlbumId = album,
                InterpretId = interpret
            };
        }
    }
}
