using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AdotadosAPI.Data;
using AdotadosDTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AdotadosAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AdotadosAPIContext _context;
        private readonly IConfiguration _configuration;

        public LoginController(AdotadosAPIContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            //procurar pelo usuario no banco
            ClienteDTO? cliente = _context.ClienteDTO.FirstOrDefault(user => user.Email == login.Email && user.Senha == login.Senha);
            FuncionarioDTO? funcionario = _context.FuncionarioDTO.FirstOrDefault(user => user.Email == login.Email && user.Senha == login.Senha);

            if (cliente != null)
            {
                var claims = new[]
                {
                   new Claim("IdCliente", cliente.IdCliente.ToString()),
                   new Claim(ClaimTypes.Name, cliente.Nome ?? ""),
                   new Claim(ClaimTypes.Role, "Admin")
                };

                return Ok(new { token = GerarToken(claims), IdCliente = cliente.IdCliente });
            }
            else if (funcionario != null)
            {
                var claims = new[]
                {
                   new Claim("IdFuncionario", funcionario.IdFuncionario.ToString()),
                   new Claim(ClaimTypes.Name, funcionario.Nome ?? ""),
                   new Claim(ClaimTypes.Role, "Admin")
                };

                return Ok(new { token = GerarToken(claims) });
            }
            else
            {
                return Unauthorized("Credenciais inválidas");
            }
        }

        // Gera o JWT usando a chave configurada (Jwt:SecretKey), a mesma validada no Program.cs
        private string GerarToken(Claim[] claims)
        {
            string secretKey = _configuration["Jwt:SecretKey"]
                ?? throw new InvalidOperationException("Jwt:SecretKey não configurada.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "*",
                audience: "*",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
