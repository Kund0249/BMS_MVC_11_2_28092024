using BMS_MVC_11_2_28092024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BMS_MVC_11_2_28092024.Controllers
{

    //Controller Class - Handle the http request and response
    public class CategoryController : Controller
    {

        //Action method
        /*
            should be public
            shoul be non-static
            decorate with http verbs (default is get)
            can't overload like c# method
         */

        //public string GetMessage()
        //{
        //    return "This is my first controller";
        //}
        //[HttpPost]
        //public string GetMessage(int id)
        //{
        //    return "This is my first controller - " + id.ToString();
        //}

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        //[HttpGet]
        [HttpPost]
        public ViewResult Create(string txtCategoryName, string txtCategoryDesc)
        {
            return View();
        }


        //[HttpGet]
        //public ViewResult Create(CategoryModel model)
        //{
        //    return View();
        //}
    }
}