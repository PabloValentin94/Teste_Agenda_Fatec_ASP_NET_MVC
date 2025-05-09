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

        // GET: /Auth/Cadastro

        public async Task<IActionResult> Cadastro()
        {

            ViewBag.Cargos = await _context.Cargos.ToListAsync();

            return View(new Usuario());

        }

        // POST: /Auth/Cadastro

        [HttpPost]
        public async Task<IActionResult> Cadastro([Bind("Id,Nome,Email,Senha,Administrador,Ativo,CargoId")] Models.Usuario usuario, string Confirmacao_Senha)
        {

            if (ModelState.IsValid)
            {

                if (_context.Usuarios.Any(u => u.Email == usuario.Email))
                {

                    ViewBag.Alerta = "O e-mail passado já está em uso!";

                }

                else if (usuario.Senha != Confirmacao_Senha)
                {

                    ViewBag.Alerta = "As senhas passadas divergem!";

                }

                else
                {

                    usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);

                    _context.Add(usuario);

                    await _context.SaveChangesAsync();

                    return RedirectToAction("Login");

                }

            }

            ViewBag.Cargos = await _context.Cargos.ToListAsync();

            return View(usuario);

        }

        // GET: /Auth/Login

        public IActionResult Login()
        {

            return View();

        }

        // POST: /Auth/Login

        [HttpPost]
        public async Task<IActionResult> Login(string Email, string Senha)
        {

            bool login_valido = false;

            foreach (Usuario usuario in (await _context.Usuarios.ToListAsync()))
            {

                if (Email == usuario.Email && BCrypt.Net.BCrypt.Verify(Senha, usuario.Senha))
                {

                    login_valido = true;

                    break;

                }

            }

            if (login_valido)
            {

                return RedirectToAction("Index", "Home");

            }

            else
            {

                ViewBag.Alerta = "Erro ao efetuar o login! Revise seus dados.";

            }

            return View();

        }

        private bool UsuarioExists(int id)
        {

            return _context.Usuarios.Any(u => u.Id == id);

        }

    }

}