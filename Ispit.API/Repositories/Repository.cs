using Ispit.API.Interface;
using Ispit.API.Models;

namespace Ispit.API.Repositories
{
    public class Repository : IRepository
    {
        private IspitApiDbContext _dbcontext;

        public Repository(IspitApiDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public ToDoList GetById(int id)
        {
            return _dbcontext.ToDoLists.FirstOrDefault(t => t.Id == id);
        }

        public List<ToDoList> GetAll()
        {
            return _dbcontext.ToDoLists.ToList();
        }

        public ToDoList Update(ToDoList toDo)
        {
            var result = _dbcontext.ToDoLists.FirstOrDefault(t => t.Id == toDo.Id);

            if (result != null)
            {
                result.Title = toDo.Title;
                result.Description = toDo.Description;
                result.IsCompleted= toDo.IsCompleted;

                _dbcontext.SaveChanges();

                return result;
                
            }

            return null;
        }

        public ToDoList Insert(ToDoList toDo)
        {
            var result = _dbcontext.ToDoLists.Add(toDo);
            _dbcontext.SaveChanges();

            return result.Entity;
        }

        public void Delete(int id)
        {
            var result = _dbcontext.ToDoLists.FirstOrDefault(t => t.Id == id);

            if (result != null)
            {
                _dbcontext.ToDoLists.Remove(result);
                _dbcontext.SaveChanges();
            }
        }

        
    }
}
