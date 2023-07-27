using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ispit.API.Models;
using Ispit.API.Interface;

namespace Ispit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListsController : ControllerBase
    {
        private IRepository _repository;

        public ToDoListsController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/ToDoLists
        [HttpGet]
        public ActionResult<IEnumerable<ToDoList>> GetToDoLists()
        {
            try
            {
                return Ok(_repository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Greška sa serverom!");
            }
        }

        // GET: api/ToDoLists/5
        [HttpGet("{id}")]
        public ActionResult<ToDoList> GetToDoList(int id)
        {
            try
            {
                var result = _repository.GetById(id);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Greška sa serverom!");
            }
        }

        // PUT: api/ToDoLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutToDoList(int id, ToDoList toDoList)
        {
            try
            {
                if (id != toDoList.Id) return BadRequest();

                var listUpdate = _repository.GetById(id);

                if (listUpdate == null) return NotFound();

                return Ok(_repository.Update(toDoList));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Greška sa serverom!");
            }
        }

        // POST: api/ToDoLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<ToDoList> PostToDoList(ToDoList toDoList)
        {
            ToDoList? createdList = null;

            try
            {
                createdList = _repository.Insert(toDoList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Greška sa serverom!");

            }
            return CreatedAtAction("GetToDoList", new { id = createdList.Id }, createdList);
        }

        // DELETE: api/ToDoLists/5
        [HttpDelete("{id}")]
        public IActionResult DeleteToDoList(int id)
        {
            try
            {
                var listDelete = _repository.GetById(id);

                if (listDelete == null) return Problem("Not found!");

                _repository.Delete(id);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Greška sa serverom!");
            }
        }

        

    }
}
