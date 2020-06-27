using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUDCore.Models;
using System.Security.Cryptography.X509Certificates;

namespace CRUDCore.Pages.UsersAdministration
{
    public class IndexModel : PageModel
    {
        private readonly CRUDCore.Models.CRUDAPPContext _context;

        [BindProperty]
        public string search { get; set; }

        public IndexModel(CRUDCore.Models.CRUDAPPContext context)
        {
            _context = context;
        }

        public IList<CtUsers> CtUsers { get;set; }

        public async Task OnGetAsync()
        {
            CtUsers = await _context.CtUsers.Include(c => c.RoleNavigation).ToListAsync();
        }

        [BindProperty]
        public string txtBusqueda { get; set; }
        public async Task<IActionResult> OnPostRequestInfo(string txtBusqueda)
        {
            CtUsers = await _context.CtUsers.Include(c => c.RoleNavigation).Where(x=> x.Nombres.Contains(txtBusqueda)).ToListAsync();


            // return RedirectToPage(); redirecciona a pagina pero primero pasa por el get natural
            return Page();
        }

    }
}
