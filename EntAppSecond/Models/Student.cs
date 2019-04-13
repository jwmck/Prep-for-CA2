using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Validation.Models
{
    public class Student
    {
        
        [Required]
        [RegularExpression(@"^(s|S)\d{7}$", ErrorMessage ="ID Must be of format s1234567")]
        public string StudentID { get; set; } = "";


        [Required]
        [MaxLength(20, ErrorMessage = "First Name must be at most 20 characters")]
        [Display(Name = "First Name")]
        [RegularExpression(@"\S{2,}", ErrorMessage ="First Name must be at least two characters.")]
        public string FirstName { get; set; } = "";


        [Required]
        [RegularExpression(@"\S{3,}", ErrorMessage = "Last Name must be at least three characters")]
        public string LastName { get; set; } = "";


        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }


        [Required]
        [Range(1, 100, ErrorMessage = "You must be registered for at least one module")]
        public int NrModules { get; set; }


        [Required]
        [Range(50, 250, ErrorMessage = "Height must be between 50 and 250 cms, sorry!!")]
        public int Height { get; set; }

        //Changed type from EmailAddressAttribute to string as there were problems with
        //primary key
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required]
        [Compare("Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailConfirm { get; set; }

        public Student()
        {

        }

    }
}
