using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BMS_MVC.DataAccess.Entity
{
    [Table("TBOOK")]
    public class BookEntity
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }

        [Column("BookImagePath")]
        public string CoverPhotoPath { get; set; }
    }
}
