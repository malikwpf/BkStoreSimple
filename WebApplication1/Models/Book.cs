using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }


        public string Title { get; set; }


        public string Description { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }


        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }
    }
}
