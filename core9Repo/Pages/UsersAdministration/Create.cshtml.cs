using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CRUDCore.Models;
using CRUDCore.Models.MyModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace CRUDCore.Pages.UsersAdministration
{
    public class CreateModel : PageModel
    {
        private readonly CRUDCore.Models.CRUDAPPContext _context;
        private IHostingEnvironment _environment;
        public CreateModel(CRUDCore.Models.CRUDAPPContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public IFormFile Upload { get; set; }
       
      

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
            else
            {
                var FileName = string.Concat((DateTime.Now - new DateTime(2010, 01, 01)).TotalMilliseconds.ToString(), ".jpg");
                
                CtUsers.CreationDate = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
                CtUsers.Password = Crypt.Encrypt(txtPassword);
                CtUsers.ImgPath = FileName;
                _context.CtUsers.Add(CtUsers);
                await _context.SaveChangesAsync();

                
                var file = Path.Combine(_environment.WebRootPath, "images/users", FileName);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await Upload.CopyToAsync(fileStream);
                }
            }
           

            return RedirectToPage("./Index");
        }
    }
}
