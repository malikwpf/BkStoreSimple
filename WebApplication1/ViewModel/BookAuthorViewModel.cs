using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.ViewModel
{
    public class BookAuthorViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }


        public string Description { get; set; }

        
        public string ImageUrl { get; set; }
        
        
        public virtual int AuthorId { get; set; }

        
        public virtual List<Author> authors { get; set; }
    

        public IFormFile File { get; set; }
    }
}
