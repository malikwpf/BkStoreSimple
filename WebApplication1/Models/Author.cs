using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{

    public class Author
    {
       
        [Required(AllowEmptyStrings = false)]
        [Display(Name ="The author's name")]
        public string FullName { get; set; }

        [Key]
        public int Id { get; set; }
    }
}
