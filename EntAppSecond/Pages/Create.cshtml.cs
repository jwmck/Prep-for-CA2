using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Validation.Models;
using Microsoft.AspNetCore.Http;

namespace Validation.Pages
{
    public class CreateStudentsModel : PageModel
    {

        private readonly CollegeContext _db;


        public CreateStudentsModel(CollegeContext db)
        {
            _db = db;
        }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Student Student { get; set; }



        public void OnGet()
        {

        }



        public async Task<IActionResult> OnPostAsync()
        {

            if (ModelState.IsValid)
            {
                _db.Students.Add(Student);
                await _db.SaveChangesAsync();
                Message = $"Student {Student.StudentID} has been added";
                return RedirectToPage("ListStudents");
            }

            else return Page();

        }
    }
}