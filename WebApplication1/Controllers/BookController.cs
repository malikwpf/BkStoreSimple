using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Repository;
using WebApplication1.ViewModel;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Grpc.Core;
namespace WebApplication1.Controllers
{
    public class BookController : Controller
    {
        public IBookRepository<Book> Bk { get; }
        public IBookRepository<Author> Aut { get; }
        public IWebHostEnvironment Host { get; }

        public BookController(IBookRepository<Book> bk,IBookRepository<Author> aut,
            IWebHostEnvironment host)
        {
            Bk = bk;
            Aut = aut;
            Host = host;
        }

        // GET: BookController
        public ActionResult Index()
        {
            
                var books = Bk.List();
                return View(books);
            


        }

  
        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book = Bk.Find(id);
            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            BookAuthorViewModel auts = new BookAuthorViewModel();
            
                auts.authors = get_all_authors().ToList();
             


            return View(auts);
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAuthorViewModel bookvm)
        {
            try
            {
                var author = Aut.Find(bookvm.AuthorId);
                string FileName = ProcessUploadedFile(bookvm.File);
                //if (bookvm.File != null)
                //{ 
                //    var uploads = Path.Combine(Host.WebRootPath, "uploads");
                //    FileName = bookvm.File.FileName;
                //    var FullPath = Path.Combine(uploads, FileName);
                //    bookvm.File.CopyTo(new FileStream(FullPath, FileMode.Create));

                //to do : Save uniqueFileName  to your db table   
                //}

                

                Book book = new Book()
                {
                    Title = bookvm.Title,
                    Description = bookvm.Description,
                    Id = bookvm.Id,
                    ImageUrl = FileName,
                    Author = author
                };

                Bk.Add(book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
           
            Book bk = Bk.Find(id);
            //if (bk.Author != null)
            //{
                BookAuthorViewModel bkvm = new BookAuthorViewModel()
                {

                    Id = bk.Id,
                    Description = bk.Description,
                    ImageUrl = bk.ImageUrl,
                    Title = bk.Title,
                    AuthorId = bk.Author.Id,
                    authors = get_all_authors().ToList()
                };

                return View(bkvm);
            //}
            //return RedirectToAction(nameof(Index));
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookAuthorViewModel bkvm)
        {


            Book book = Bk.Find(bkvm.Id);

            var author = Aut.Find(bkvm.AuthorId);



            var authors = get_all_authors().ToList();
            try
            {




                //string FileName = string.Empty; ;
                //if (bkvm.File != null)
                //{
                //    var uploads = Path.Combine(Host.WebRootPath, "uploads");
                //    FileName = bkvm.File.FileName;
                //    var FullPath = Path.Combine(uploads, FileName);
                //    string OldFileName = Bk.Find(bkvm.Id).ImageUrl;
                //    var OldFullPath = Path.Combine(uploads, OldFileName);
                //    if (OldFullPath != FullPath)
                //    {

                //System.IO.File.Delete(OldFullPath);
                //bkvm.File.CopyTo(new FileStream(FullPath, FileMode.Create));
                // }
                ;
                book.Title = bkvm.Title;
               
                book.Id = bkvm.Id;
               
                //book.Author.Id = bkvm.AuthorId;
                book.Description = bkvm.Description;
                book.Author = author;
                
                if (bkvm.File != null)
                {
                    if (bkvm.ImageUrl != null)
                    {

                        string filePath = Path.Combine(Host.WebRootPath, "uploads", bkvm.ImageUrl);
                        System.IO.File.Delete(filePath);

                    }
                    book.ImageUrl = ProcessUploadedFile(bkvm.File);
                }
              


                

                Bk.Update(id, book);
               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            Book book = Bk.Find(id);
            
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Book book)
        {
            try
            {
                book = Bk.Find(id);
                Bk.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        IList<Author> get_all_authors()
        {
            return (IList<Author>)Aut.List();
        }

        private string ProcessUploadedFile(IFormFile model)
        {
            string uniqueFileName = null;

            if (model!= null)
            {
               
                    string uploadsFolder = Path.Combine(Host.WebRootPath, "uploads");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        model.CopyTo(fileStream);
                    }
                
            }

            return uniqueFileName;
        }
        public ActionResult Search(string term)
        {

            var books = Bk.Search(term);
            return View("Index", books);



        }




    }
}
