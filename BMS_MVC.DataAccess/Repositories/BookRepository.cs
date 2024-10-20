using BMS_MVC.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS_MVC.DataAccess.Repositories
{
    public class BookRepository
    {
        private readonly BMSContext _context;
        public BookRepository()
        {
            _context = new BMSContext();
        }

        public List<BookEntity> GetAllBooks 
        {
            get
            {
               return _context.Books.ToList();
            }
        }
        public void Save(BookEntity book)
        {
            try
            {
                if (book != null)
                {
                    _context.Books.Add(book);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
