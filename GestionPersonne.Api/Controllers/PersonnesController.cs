using AutoMapper;
using GestionPersonne.Api.Models;
using GestionPersonne.Api.Parameters;
using GestionPersonne.Core.Interfaces;
using GestionPersonne.Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPersonne.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnesController : ControllerBase
    { 
        private readonly IPersonneRepository _repo;
        private readonly IMapper _mapper;

        public PersonnesController(IPersonneRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: api/Personne
        [HttpGet]
        //documentation pour swagger
        [Produces("application/json", Type = typeof(IEnumerable<Personne>))]
        public async Task<IActionResult> Get([FromQuery] PersonneParameters parameters)
        {
            try
            {
                IEnumerable<Personne> entity = await _repo.Get(parameters.Nom, parameters.Prenom);
                if (entity == null)
                {
                    return NotFound();
                }
                IEnumerable<PersonneApi> entityApis = _mapper.Map<IEnumerable<PersonneApi>>(entity);

                return Ok(entityApis);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return NotFound();
        }

        // GET: api/Personne
        [HttpGet]
        [Route("ByBegin")]
        //documentation pour swagger
        [Produces("application/json", Type = typeof(IEnumerable<Personne>))]
        public async Task<IActionResult> GetByBegin([FromQuery] PersonneParameters parameters)
        {
            try
            {
                IEnumerable<Personne> entity = await _repo.GetByBegin(parameters.Nom, parameters.Prenom);
                if (entity == null)
                {
                    return NotFound();
                }
                IEnumerable<PersonneApi> entityApis = _mapper.Map<IEnumerable<PersonneApi>>(entity);

                return Ok(entityApis);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return NotFound();
        }

        // GET: api/Personne
        [HttpGet]
        [Route("ByEnd")]
        //documentation pour swagger
        [Produces("application/json", Type = typeof(IEnumerable<Personne>))]
        public async Task<IActionResult> GetByEnd([FromQuery] PersonneParameters parameters)
        {
            try
            {
                IEnumerable<Personne> entity = await _repo.GetByEnd(parameters.Nom, parameters.Prenom);
                if (entity == null)
                {
                    return NotFound();
                }
                IEnumerable<PersonneApi> entityApis = _mapper.Map<IEnumerable<PersonneApi>>(entity);

                return Ok(entityApis);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return NotFound();
        }

        // GET api/Personne/5
        [HttpGet("{id}")]
        //documentation pour swagger
        [Produces("application/json", Type = typeof(Personne))]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                Personne tmpentity = await _repo.GetOne(id);

                if (tmpentity == null)
                {
                    return NotFound();
                }

                PersonneApi tmpentityApi = _mapper.Map<PersonneApi>(tmpentity);

                return Ok(tmpentityApi);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return NotFound();
        }

        // POST api/Personne
        [HttpPost]
        //documentation pour swagger
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> Post([FromBody] PersonneApi value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Personne tmpentity = _mapper.Map<Personne>(value);

            if (tmpentity == null)
            {
                return BadRequest();
            }
            try
            {
                await _repo.Post(tmpentity);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                throw;
            }
            return NoContent();
        }

        // PUT api/Personne/5
        [HttpPut("{id}")]
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> Put(Guid id, [FromBody] PersonneApi value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != value.Id || value == null)
            {
                return BadRequest();
            }

            try
            {
                Personne entity = _mapper.Map<Personne>(value);
                await _repo.Put(id, entity);
            }
            catch
            {
                throw;
            }
            return NoContent();
        }

        // DELETE api/Personne/5
        [HttpDelete("{id}")]
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _repo.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}