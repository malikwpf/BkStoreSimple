using Stripe;
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;
//using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Models.Repository
{
    public class DbBookStoreRepository : IBookRepository<Book>
    {
        public DbBookStoreRepository(BookStoreDb bsd)
        {
            Bsd = bsd;
        }

        public BookStoreDb Bsd { get; }

        public void Add(Book entity)
        {
            Bsd.books.Add(entity);
            SaveChanges();
        }

        public void Delete(int id)
        {
            var book = Find(id);
            Bsd.books.Remove(book);
            SaveChanges();
        }

        public Book Find(int id)
        {
            var book = Bsd.books.SingleOrDefault(a => a.Id == id);
            return book;
        }

       

        public IList<Book> Index(string searchString)
        {
            var books = from m in Bsd.books
                        select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title!.Contains(searchString));
            }

            return books.ToList();
        }

        public IList List()
        {
            return Bsd.books.ToList();
        }

        public void SaveChanges()
        {
            Bsd.SaveChanges();
        }

        public IList<Book> Search(string search)
        {
            var p = Bsd.books.Where(q =>q.Title.Contains(search)||
            q.Author.FullName.Contains(search)||
            q.Description.Contains(search));

            return p.ToList();
        }

        public void Update(int id, Book new_book)
        {
            
            if (new_book.Id == default(int))
            {
                Bsd.books.Add(new_book);
            }
            else
            {
                //var manager = new_book.Author;
                //new_book.Author = null;

                //Bsd.Entry(new_book).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
                //the line before did attach the object to the context
                // with project.Manager == null
                //new_book.Author = manager;
                //this "fakes" a change of the relationship, EF will detect this
                // and update the relatonship

                Bsd.Update(new_book);
            }
            SaveChanges();

        }
    }
}
