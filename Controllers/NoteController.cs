using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notes.Authentication;
using Notes.Interfaces;
using Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class NoteController : ControllerBase
    {
        private readonly INoteRepo NoteRepo;

        public NoteController(INoteRepo Note)
        {
            this.NoteRepo = Note;
        }
        [HttpPost]
        public IActionResult Create(NoteVM Note)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var c = NoteRepo.Add(Note);
                    return Ok(c);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }

            var data = new response();
            var errors = ModelState.Values;
            foreach (var item in errors)
            {
                data.Errors.Add(item.Errors.ToString());
            }
            data.Message = "Invalid Data";
            data.Status = "Error";
            return BadRequest(data);
        }

        // [HttpGet("GetAll")]
        [HttpGet]
        public IActionResult Get()
        {
            var data = NoteRepo.GetAll();
            return Ok(data);
        }

        // [HttpPost("Delete")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = NoteRepo.Delete(id);
            if (data == null)
                return BadRequest(new response { Message = "Can Not Delete", Status = "Error" });
            return Ok(data);
        }
        // [HttpPost("Edit")]
        [HttpPut]
        public IActionResult Edit(NoteVM ob)
        {
            var data =NoteRepo.Edit(ob);
            if (data == null)
                return BadRequest(new response { Message = "Can Not Edit", Status = "Error" });
            return Ok(data);
        }
       
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = NoteRepo.GetById(id);
            if (data == null)
                return BadRequest(new response { Message = "Not Found", Status = "Error" });
            return Ok(data);
        }

        [HttpGet("search/{name}")]
        public IActionResult search(string name)
        {
            var data =NoteRepo.Search(name);
            if (data == null)
                return BadRequest(new response { Message = "Not Found", Status = "Error" });
            return Ok(data);
        }
    }
}
