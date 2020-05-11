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
    public class IndexModel : PageModel
    {
        private readonly CRUDCore.Models.CRUDAPPContext _context;

        public IndexModel(CRUDCore.Models.CRUDAPPContext context)
        {
            _context = context;
        }

        public IList<CtUsers> CtUsers { get;set; }

        public async Task OnGetAsync()
        {
            CtUsers = await _context.CtUsers
                .Include(c => c.RoleNavigation).ToListAsync();
        }
    }
}
