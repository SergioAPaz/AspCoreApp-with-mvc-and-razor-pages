using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using CRUDCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRUDCore.Pages.Reportes
{
    public class ReportsModel : PageModel
    {

        public string   ApiPassword { get; set; }
        public IList<CtUsers> CtUsers { get; set; }
        public bool UsersResponse { get; set; }
       

        private readonly CRUDCore.Models.CRUDAPPContext _context;
        public ReportsModel(CRUDCore.Models.CRUDAPPContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            UsersResponse = false;
        }

        public async Task OnPostUsuarios()
        {
            var session1 = HttpContext.Session.GetString("UsuarioLogued")  ;
            UsersResponse = true;
            CtUsers = await _context.CtUsers.Where(x => x.UserName== session1) .ToListAsync();

        }
    }
}