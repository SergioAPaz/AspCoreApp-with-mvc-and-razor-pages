using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CRUDCore.Models;
using CRUDCore.Models.MyModels;

namespace CRUDCore.Pages.UsersAdministration
{
    public class CreateModel : PageModel
    {
        private readonly CRUDCore.Models.CRUDAPPContext _context;

        public CreateModel(CRUDCore.Models.CRUDAPPContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Role"] = new SelectList(_context.CtRoles, "Id", "Role");
            return Page();
        }

        [BindProperty]
        public CtUsers CtUsers { get; set; }
        [BindProperty]
        public string txtPassword { get; set; }



        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Encrypto Crypt = new Encrypto();

            if (!ModelState.IsValid)
            {
                return Page();
            }
            CtUsers.CreationDate= Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
            CtUsers.Password = Crypt.Encrypt(txtPassword);
            _context.CtUsers.Add(CtUsers);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
