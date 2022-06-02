using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Repository
{
    public interface IBookRepository<t>
    {
        public IList List();
        public t Find(int id);
        public void Add(t entity);
        public void Update(int id, t new_entity);
        public void Delete(int id);
        public void SaveChanges();
        public IList<t> Search(string search);
    }
}
