using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BMS_MVC_11_2_28092024.Models
{
    public class BookModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int  Category { get; set; }

        public List<SelectListItem> CategoryList { get; set; }
        public HttpPostedFileBase CoverPhoto { get; set; }
    }
}