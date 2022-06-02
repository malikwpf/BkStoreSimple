using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Repository;

namespace WebApplication1.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IBookRepository<Author> aut;

        public AuthorController(IBookRepository<Author> aut)
        {
            this.aut = aut;
        }

        // GET: AuthorController
        public ActionResult Index()
        {
            var authors = aut.List();
            return View(authors);
           
        }

        // GET: AuthorController/Details/5
        public ActionResult Details(int id)
        {
            var author = aut.Find(id);
            return View(author);
        }

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author new_author)
        {
            try
            {
                aut.Add(new_author);
                return RedirectToAction(nameof(Index));
        }
            catch
            {
                return View();
    }
}

        // GET: AuthorController/Edit/5
        public ActionResult Edit(int id)
        {
            var author = aut.Find(id);
            return View(author);
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Author new_author)
        {
            try
            {
                
                aut.Update(id, new_author);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Delete/5
        public ActionResult Delete(int id)
        {
            var author = aut.Find(id);
            return View(author);
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                aut.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Search(string term)
        {

            var authors = aut.Search(term);
            return View("Index", authors);



        }
    }
}
