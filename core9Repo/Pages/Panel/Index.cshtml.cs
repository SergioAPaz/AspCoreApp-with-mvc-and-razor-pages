using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUDCore.Pages.Panel
{
    public class IndexModel : PageModel
    {
        public string MessageBody { get; set; }
        public string MessageTitle { get; set; }


        public void OnGet()
        {
            //if (HttpContext.Session.GetString("UsuarioLogued") == null)
            //{
            //    return RedirectToPage("../Login/Index");
            //}
            //else
            //{
            //    return Page();
            //}
           
        }
    }
}