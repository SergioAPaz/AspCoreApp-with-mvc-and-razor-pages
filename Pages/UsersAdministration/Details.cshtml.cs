using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUDCore.Models;

namespace CRUDCore.Pages.UsersAdministration
{
    public class DetailsModel : PageModel
    {
        private readonly CRUDCore.Models.CRUDAPPContext _context;

        public DetailsModel(CRUDCore.Models.CRUDAPPContext context)
        {
            _context = context;
        }

        public CtUsers CtUsers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CtUsers = await _context.CtUsers
                .Include(c => c.RoleNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (CtUsers == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
