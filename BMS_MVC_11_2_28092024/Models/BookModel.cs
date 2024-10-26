using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace BMS_MVC_11_2_28092024.Models
{
    public class BookModel
    {
        public int BookId { get; set; }

        [Required(ErrorMessage ="Book title is required.")]
        [RegularExpression("[a-zA-Z\\s]*",ErrorMessage ="Book tile should be alphabets only.")]
        [StringLength(20,MinimumLength =6,ErrorMessage = "should not less than 6 and more than 20 characters.")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public int  Category { get; set; }

        public List<System.Web.Mvc.SelectListItem> CategoryList { get; set; }

        [Required(ErrorMessage = "Cover photo is required.")]
        public HttpPostedFileBase CoverPhoto { get; set; }



        //[EmailAddress]
        //public string Email { get; set; }


        //[Required]
        //public string SalaryAccountNumber { get; set; }

        //[Required]
        //[Compare("SalaryAccountNumber",ErrorMessage ="")]
        //public string ConfirmSalaryAccountNumber { get; set; }

        //[Range(50000,500000,ErrorMessage ="")]
        //public int Salary { get; set; }


    }
}