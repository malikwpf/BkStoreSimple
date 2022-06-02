using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Repository
{
    public class DbAuthorRepository : IBookRepository<Author>
    {
        public DbAuthorRepository(BookStoreDb bsd)
        {
            Bsd = bsd;
        }

        public BookStoreDb Bsd { get; }

        public void Add(Author entity)
        {
            Bsd.authors.Add(entity);
            SaveChanges();
        }

        public void Delete(int id)
        {
            Bsd.authors.Remove(Find(id));
            SaveChanges();
        }

        public Author Find(int id)
        {
            var author = Bsd.authors.SingleOrDefault(a => a.Id == id);
            return author;
        }

        public IList<Author> Index(string searchString)
        {
            throw new NotImplementedException();
        }

        public IList List()
        {
            return Bsd.authors.ToList();

        }

        public void SaveChanges()
        {
            Bsd.SaveChanges();
        }

        public IList<Author> Search(string search)
        {
            var p = Bsd.authors.Where(q =>q.FullName.Contains(search));

            return p.ToList();
        }

        public void Update(int id, Author new_entity)
        {

            

            var author = Find(id);
            author.FullName = new_entity.FullName;
            Bsd.authors.Update(author);
            SaveChanges();
        }

        
    }
}
