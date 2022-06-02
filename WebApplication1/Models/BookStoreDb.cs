using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class BookStoreDb : DbContext
    {
        //internal readonly object Configuration;

        public BookStoreDb(DbContextOptions<BookStoreDb> options) : base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Book>()
        //.HasOne(s => s.Author)
        //.WithMany()
        //.IsRequired();
        //}

        public DbSet<Book> books { get; set; }
        public DbSet<Author> authors { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        @"Server=(localdb)\mssqllocaldb;Database=mydb;Trusted_Connection=True");
        //}

 
    }
}
