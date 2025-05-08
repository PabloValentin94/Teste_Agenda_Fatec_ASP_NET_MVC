using Teste_Agenda_Fatec.Data;

using Microsoft.AspNetCore.Mvc;

using Teste_Agenda_Fatec.Models;

using Microsoft.EntityFrameworkCore;

namespace Teste_Agenda_Fatec.Controllers
{

    public class AuthController : Controller
    {

        private ApplicationDBContext _context;

        public AuthController(ApplicationDBContext context)
        {

            _context = context;

        }

        /*
 
            GET: /Auth/Cadastro

        */

        public async Task<IActionResult> Cadastro()
        {

            ViewBag.Cargos = await _context.Cargos.ToListAsync();

            return View();

        }

        /*
         
            POST: /Auth/Cadastro

        */

        [HttpPost]
        public async Task<IActionResult> Cadastro([Bind("Id,Nome,Email,Senha,Administrador,Ativo,CargoId")] Models.Usuario usuario, string confirmacao_senha)
        {

            if (ModelState.IsValid)
            {

                if (usuario.Senha == confirmacao_senha)
                {

                    _context.Add(usuario);

                    await _context.SaveChangesAsync();

                    return RedirectToAction("Login");

                }

                else
                {

                    // Erro!

                }

            }

            return View(usuario);

        }

        /*
         
            POST: /Auth/Login

        */

        public IActionResult Login()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Nome,Email,Senha")] Models.Usuario usuario)
        {

            if (ModelState.IsValid)
            {

                var login = await _context.Usuarios.FirstOrDefaultAsync(u => u.Nome == usuario.Nome && u.Senha == usuario.Senha);

                if (login != null)
                {

                    RedirectToAction("Index", "Home");

                }

                else
                {

                    return NotFound();

                }

            }

            return View(usuario);

        }

        private bool UsuarioExists(int id)
        {

            return _context.Usuarios.Any(usuario => usuario.Id == id);

        }

    }

}