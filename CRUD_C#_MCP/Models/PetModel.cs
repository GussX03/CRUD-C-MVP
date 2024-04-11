using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // AGREGRAR REFERENCIA DATA ANNOTATIONS VALIDATORS 
using System.ComponentModel;


namespace CRUD_C__MCP.Models
{
    public class PetModel
    {
        // Fields
        private int id;
        private string name;
        private string type;
        private string colour;
        // properties - Validations 
        [DisplayName("Pet ID")]
        public int Id { 
            get => id; 
            set => id = value; 
        }
        [DisplayName("Pet Name")]
        [Required(ErrorMessage = "Pet Name is required")]
        [StringLength(50, MinimumLength =3, ErrorMessage = "Pet Name must be between 3 and 50 characters")]
        public string Name { 
            get => name; 
            set => name = value; 
        }
        [DisplayName("Pet Type")]
        [Required(ErrorMessage = "Pet Type is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Pet Type must be between 3 and 50 characters")]
        public string Type { 
            get => type; 
            set => type = value; 
        }
        [DisplayName("Pet Colour")]
        [Required(ErrorMessage = "Pet Colour is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Pet Colour must be between 3 and 50 characters")]
        public string Colour { 
            get => colour; 
            set => colour = value; 
        }
    }
}
