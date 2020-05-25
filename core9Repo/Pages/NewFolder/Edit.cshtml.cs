using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDCore.Models;

namespace CRUDCore.Pages.NewFolder
{
    public class EditModel : PageModel
    {
        private readonly CRUDCore.Models.CRUDAPPContext _context;

        public EditModel(CRUDCore.Models.CRUDAPPContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["Role"] = new SelectList(_context.CtRoles, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CtUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CtUsersExists(CtUsers.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CtUsersExists(int id)
        {
            return _context.CtUsers.Any(e => e.Id == id);
        }
    }
}
