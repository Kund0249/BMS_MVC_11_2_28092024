﻿using BMS_MVC_11_2_28092024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using BMS_MVC.DataAccess.Repositories;
using BMS_MVC.DataAccess.Entity;
using System.Web.UI.WebControls;

namespace BMS_MVC_11_2_28092024.Controllers
{
    public class BookController : Controller
    {
        // GET: Book

        private CategoryRepository categoryRepository;
        private BookRepository bookRepository;
        public BookController()
        {
            categoryRepository = new CategoryRepository();
            bookRepository = new BookRepository();
        }
        public ActionResult Index()
        {
            return View(bookRepository.GetAllBooks);
        }


        public ActionResult Create()
        {
            List<CategoryEntity> catlist = categoryRepository.Get();
            BookModel model = new BookModel()
            {
                CategoryList = catlist.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.CategoryId.ToString()
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(BookModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.CoverPhoto != null)
                {
                    string ext = Path.GetExtension(model.CoverPhoto.FileName);
                    string fileName = DateTime.Now.ToString("ddmmyyyy-") + Guid.NewGuid().ToString() + ext;
                    string directory = "~/Resources/Image";
                    string filePath = Path.Combine(Server.MapPath(directory), fileName);
                    model.CoverPhoto.SaveAs(filePath);

                    BookEntity bookEntity = new BookEntity()
                    {
                        CoverPhotoPath = directory + "/" + fileName,
                        Title = model.BookName
                    };

                    bookRepository.Save(bookEntity);
                }
                return RedirectToAction(nameof(Index));
            }
            model.CategoryList = categoryRepository.Get()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.CategoryId.ToString()
                }).ToList();
            return View(model);
        }
    }
}