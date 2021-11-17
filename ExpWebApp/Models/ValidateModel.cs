using System;
using System.ComponentModel.DataAnnotations;

namespace ExpWebApp.Models
{
    public class ValidateModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please input a valid number")]
        [Required(ErrorMessage = "Please input a valid number")]
        public int myDays { get; set; }

        [Required(ErrorMessage = "Please input a valid date")]
        public DateTime myDate { get; set; }
    }
}
