using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveitAPI.Model;
using ReserveitAPI.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReserveitAPI.Controllers
{
#nullable disable
    [Route("api/[Controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext context;
        public StudentController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var getAllStudents = await context.Students.ToListAsync();
            return Ok(getAllStudents);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetSingleStudent")]
        public async Task<IActionResult> GetSingleStudent([FromRoute] Guid id)
        {
            var getSingleStudent = await context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (getSingleStudent != null)
            {
                return Ok(getSingleStudent);
            }
            return NotFound("Student not found !");
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            student.Id = Guid.NewGuid();
            await context.Students.AddAsync(student);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSingleStudent), new { id = student.Id }, student);
        }

        //[HttpPost]
        //public async Task<IActionResult> ListOfStrings([FromBody] Student student)
        //{
        //    List<string> Students = new List<string>();
        //    Students.Add("");
        //    Students.Add("Tahmid Radit");
        //    authors.Add("CSE");
        //    authors.Add("456");
        //}

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] Guid id, Student student)
        {
            var getSingleStudent = await context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (getSingleStudent != null)
            {
                getSingleStudent.Name = student.Name;
                getSingleStudent.Department = student.Department;
                getSingleStudent.StudentId = student.StudentId;
                await context.SaveChangesAsync();
                return Ok(getSingleStudent);
            }
            return NotFound("Student not found !");
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid id)
        {
            var getSingleStudent = await context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (getSingleStudent != null)
            {
                context.Students.Remove(getSingleStudent);
                await context.SaveChangesAsync();
                return Ok(getSingleStudent);
            }
            return NotFound("Student not found !");
        }
    }
}

