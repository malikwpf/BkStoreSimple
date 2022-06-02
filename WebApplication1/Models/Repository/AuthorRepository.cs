using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Repository;

namespace WebApplication1.Models
{
    public class AuthorRepository : IBookRepository<Author>
    {
        List<Author> authors;

        public AuthorRepository()
        {
            authors = new List<Author>() {
                new Author(){
                Id = 1,
                FullName = "Malik" },


                new Author(){
                Id = 2,
                FullName = "Pahul" }  };

        }

        public void Add(Author entity)
        {
            authors.Add(entity);
        }

        public void Delete(int id)
        {
            var author = Find(id);
            authors.Remove(author);
        }

        public Author Find(int id)
        {
            var author = authors.SingleOrDefault(a => a.Id == id);
            return author;
        }

    

        public IList List()
        {
            return authors.ToList();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public IList<Author> Search(string search)
        {
            throw new NotImplementedException();
        }

        public void Update(int id,Author new_author)
        {
            var old_author = Find(id);
            old_author.FullName = new_author.FullName;
        }

       
    }
}
