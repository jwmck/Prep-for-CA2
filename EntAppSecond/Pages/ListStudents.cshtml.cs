using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Validation.Models;

namespace Validation.Pages
{
    public class ListStudentsModel : PageModel
    {
       
        private readonly CollegeContext _db;

        [TempData]
        public string Message { get; set; }

        public string Message2;

        public ListStudentsModel(CollegeContext db)
            {
                _db = db;
            }

            public IList<Student> Students { get; private set; }

        //gets the list of students when the page is loaded. AsNoTracking improves performance - tells the system not to track db changes
            public async Task OnGetAsync()
            {
                Students = await _db.Students.AsNoTracking().ToListAsync();
            }

    }
    }
