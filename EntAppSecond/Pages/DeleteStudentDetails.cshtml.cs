using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Validation.Models;

namespace Validation.Pages
{
    public class DeleteStudentDetailsModel : PageModel
    {

        private readonly CollegeContext _db;

        public DeleteStudentDetailsModel(CollegeContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Student = await _db.Students.FindAsync(id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var student = await _db.Students.FindAsync(Student.StudentID);

            if (student != null)
            {
                _db.Students.Remove(student);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage("ListStudents");
        }
    }
}