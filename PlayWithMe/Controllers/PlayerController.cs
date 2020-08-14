using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayWithMe.Context;
using PlayWithMe.Models;
using PlayWithMe.Service;
using PlayWithMe.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayWithMe.Controllers
{
    [Route("")]
    public class PlayerController : ControllerBase
    {
        private readonly DataContext _context;

        public PlayerController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("v1/player")]
        public async Task<ActionResult<List<Player>>> Get()
        {
            try
            {
                var players = await _context.Player.AsNoTracking().ToListAsync();

                if (players == null)
                {
                    return NotFound("Nenhum player encontrado!");
                }

                return players;

            }
            catch
            {
                return BadRequest(new { Erro = "Não foi possível encontrar os players!" });
            }
        }

        [HttpPost]
        [Route("v1/player")]
        public async Task<ActionResult<dynamic>> Login([FromBody] Player model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Erro = "Por favor verifique os dados digitados!" });
            }

            try
            {
                model.Password = PasswordService.Encrypt(model.Password);
                _context.Player.Add(model);
                await _context.SaveChangesAsync();
                model.Password = "";

                return new
                {
                    player = model,
                    mensagem = "Player criado com sucesso!",
                };
            }
            catch
            {
                return BadRequest(new { Erro = "Não foi possível criar o player!" });
            }
        }



        //Autenticação
        [HttpPost]
        [Route("/v1/login")]
        public async Task<ActionResult<dynamic>> Login([FromBody] PlayerLoginModel model)
        {
            try
            {
                var user = await _context.Player
                    .AsNoTracking()
                    .Where(x => x.Email == model.Email)
                    .FirstOrDefaultAsync();

                if (user == null)
                    return NotFound(new { Erro = "Player não encontrado!" });

                else
                {
                    if (PasswordService.Compare(model.Password, user.Password))
                    {
                        var token = TokenService.GenerateToken(user);
                        user.Password = "";

                        return new
                        {
                            user = user,
                            token = token,
                            mesangem = "Autenticado com sucesso!"
                        };
                    }

                    else
                    {
                        return NotFound(new { Erro = "Senha inválida!" });
                    }
                }



            }
            catch (Exception)
            {
                return BadRequest(new { Erro = "Não foi possível realizar o login" });
            }
        }

    }
}
