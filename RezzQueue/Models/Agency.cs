using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RezzQueue.Models
{
    public class Agency
    {
        public int AgencyId { get; set; }

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
        public string AgencyName { get; set; }

        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
       ErrorMessage = "Please provide valid email id")]
        public string EmailID { get; set; }

        [Required(ErrorMessage = "Please provide location", AllowEmptyStrings = false)]
        public string AgencyLocation { get; set; }



        //nav property
        //Agency(one) - animal(many)
        public virtual ICollection<Animal> Animals { get; set; }

    }
}