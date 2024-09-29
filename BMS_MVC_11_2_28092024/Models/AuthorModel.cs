using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_MVC_11_2_28092024.Models
{
    public class AuthorModel
    {
        public int AuthorId { get; set; } 
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
        public string AuthorPhone { get; set; }
    }
}