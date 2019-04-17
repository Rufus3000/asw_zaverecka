using Pecka_Soundcloud.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pecka_Soundcloud.Models
{
    public class InterpretCreateViewModel
    {
        public InterpretCreateViewModel()
        {
            
        }

        public int Id
        {
            get;
            set;
        }
        [Required]
        [DisplayName("Name")]
        public string Name
        {
            get;
            set;
        }

        [Required]
        [DisplayName("Země původu")]
        public string Country
        {
            get;
            set;
        }
        public Interpret CreateEntity()
        {
            var interpret = Interpret.Create(this.Name, this.Country);

            return interpret;
        }
    }
}
