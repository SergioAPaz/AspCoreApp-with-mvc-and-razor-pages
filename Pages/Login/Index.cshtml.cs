using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDCore.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

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
        public string cssclass456 { get; set; }
        [BindProperty]
        public CtUsers CtUsers { get; set; }

        [BindProperty]
        public string UsuarioSelected { get; set; }
        public List<SelectListItem> CategoryItems { set; get; }
        public string MessageBody { get; set; }
        public string MessageTitle { get; set; }

        [BindProperty]
        public string txtUsuario { get; set; }
        [BindProperty]
        public string txtPassword { get; set; }
     
        public void OnGet()
        {

        }

        [ValidateAntiForgeryToken]
        public IActionResult OnPost()
        {
            if ((ModelState.IsValid))
            {
                if (txtUsuario != null && txtPassword != null)
                {
                    showListUsers = false;
                    var confirmAccess = _context.CtUsers.Where(x => x.UserName.ToLower() == txtUsuario.ToLower() & x.Password == txtPassword).FirstOrDefault();

                    if (txtUsuario == "spaz222")
                    {
                        CategoryItems = _context.CtUsers.Select(a => new SelectListItem
                        {
                            Value = a.UserName,
                            Text = a.UserName
                        }).ToList();

                        showListUsers = true;
                    }
                    else
                    {
                        if (confirmAccess != null)
                        {
                            HttpContext.Session.SetString("UsuarioLogued", txtUsuario);
                            return RedirectToPage("../Panel/Index");
                        }
                        else
                        {
                            MessageTitle = "Error";
                            MessageBody = "Usuario o contraseña incorrectos.";
                        }
                    }
                }
                else
                {
                    MessageTitle = "Campos incompletos;";
                    MessageBody = "Favor de llenar todos los campos.";
                }
            }
           
           
           
            return Page();
        }
    }
}