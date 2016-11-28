using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RezzQueue.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public int PetStatusId { get; set; }  
                   
        [Required(ErrorMessage = "Please provide username", AllowEmptyStrings = false)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please provide Password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be 8 char long.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password dose not match.")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Please provide full name", AllowEmptyStrings = false)]
        public string CustomerName { get; set; }

        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
       ErrorMessage = "Please provide valid email id")]
        public string EmailID { get; set; }

        [Required(ErrorMessage = "Please provide location", AllowEmptyStrings = false)]
        public string CustomerLocation { get; set; }



        //nav property
        //customer(many) - animal(many)
        public virtual ICollection<Animal> Animals { get; set; }
        //Customer(many)-Status(many)
        public ICollection<PetStatus> PetStatuses { get; set; }
    }
}