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
    public class InterpretEditorViewModel : IValidatableObject
    {
        public InterpretEditorViewModel()
        {
        }

        public InterpretEditorViewModel(Interpret interpret)
        {
            this.Id = interpret.Id;
            this.Name = interpret.Name;
            this.Country = interpret.Country;
        }

        public int Id
        {
            get;
            set;
        }

        [Required]
        [DisplayName("Jméno")]
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



        public void UpdateEntity(Interpret interpret)
        {

            interpret.Name = this.Name;
            interpret.Country = this.Country;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));

            var interpret = context.Interprets.FirstOrDefault(b => b.Id == this.Id);

            if (interpret == null)
                yield return new ValidationResult("🍆🍆🍆🍆🍆🍆🍆🍆🍆🍆", new string[] { nameof(Id) });

           
        }
    }
}
