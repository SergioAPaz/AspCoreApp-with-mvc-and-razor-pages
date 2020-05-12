using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDCore.Models;


namespace CRUDCore.Pages.Login
{
    public class IndexModel : PageModel
    {
        public bool showListUsers { get; set; }

        private readonly CRUDCore.Models.CRUDAPPContext _context;

        public IndexModel(CRUDCore.Models.CRUDAPPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CtUsers CtUsers { get; set; }

        [BindProperty]
        public string UsuarioSelected { get; set; }
        public List<SelectListItem> CategoryItems { set; get; }

       
       
        public void OnGet()
        {

        }


        public IActionResult OnPost(string txtUsuario, string txtPassword)
        {
            showListUsers = false;
            if (txtUsuario=="spaz")
            {
                CategoryItems = _context.CtUsers.Select(a => new SelectListItem
                               {
                                   Value = a.UserName,
                                   Text = a.UserName
                               })
                    .ToList();

                showListUsers = true;
              
            }
           
            return Page();
        }
    }
}