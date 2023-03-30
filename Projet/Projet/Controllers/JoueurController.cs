using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Projet.Models;
using Projet.Services.JoueurService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class JoueurController : ControllerBase
    {
        private readonly IJoueurService _joueurService;

        public JoueurController(IJoueurService joueurService)
        {
            _joueurService = joueurService;
        }
        // GET: api/<JoueurController>
        [HttpGet]
        public async Task<IEnumerable<Joueur>> Get()
        {
            return await _joueurService.GetJoueurs();
        }

        // GET api/<JoueurController>/5
        [HttpGet("{id}")]
        public async Task<Joueur> Get(int id)
        {
            return await _joueurService.GetJoueur(id); ;
        }

        // POST api/<JoueurController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Joueur value)
        {
            try
            {
                //await _joueurService.Create(value);
                return Ok(await _joueurService.Create(value));
            }
            catch (Exception e)
            {

                return BadRequest();
            }
             
        }

        // PUT api/<JoueurController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Joueur value)
        {
            try
            {
                await _joueurService.Update(id, value);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
            return Ok();
        }

        // DELETE api/<JoueurController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _joueurService.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
            
        }
    }
}
