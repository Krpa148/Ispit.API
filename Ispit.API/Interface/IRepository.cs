using Ispit.API.Models;

namespace Ispit.API.Interface
{
    public interface IRepository
    {
        ToDoList GetById(int id);
        List<ToDoList> GetAll();
        ToDoList Update(ToDoList toDoList);
        ToDoList Insert(ToDoList toDoList);
        void Delete(int id);
    }
}
