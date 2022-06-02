using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Repository
{
    public class BookRepository : IBookRepository<Book>
    {
        List<Book> Books;
       public BookRepository()
        {
             Books= new List<Book>()
            {
                new Book
                {
                    Title="C#",
                    Description="My favorite book",
                    Id=1,
                    ImageUrl="Angry bird.jpg",
                    Author=new Author()
                },
                new Book
                {
                    Title="Java",
                    Description="Android",
                    Author=new Author(),
                    Id=2,
                    ImageUrl="brushtool assignment.jpg"

                },
                new Book
                {
                    Title="C++",
                    Description="Big tech",
                    Id=3,
                    Author=new Author(),
                    ImageUrl="Horror movie poster.jpg f"
                },
            };
        }

        public void Add(Book entity)
        {
            Books.Add(entity);
        }

        public void Delete(int id)
        {
            var book = Find(id);
            Books.Remove(book);
        }

        public Book Find(int id)
        {
            var book = Books.SingleOrDefault(a => a.Id == id);
            return book;
        }

      
        public IList List()
        {
            return Books;
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public IList<Book> Search(string search)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Book new_book)
        {
            var old_book = Find(id);
            old_book.Title = new_book.Title;
            old_book.Description = new_book.Description;
            old_book.ImageUrl = new_book.ImageUrl;
        }
    }
}
