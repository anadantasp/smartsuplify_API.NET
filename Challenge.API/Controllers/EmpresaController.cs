using Challenge.API.Data;
using Challenge.API.Dto;
using Challenge.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Barbearia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        public readonly ApplicationDbContext _dbContext;

        public EmpresaController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var empresas = await _dbContext.Empresas.ToListAsync();
            return Ok(empresas);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _dbContext.Empresas.FindAsync(id);
            if(cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmpresaDto empresaDto)
        {
            if (ModelState.IsValid)
            {
                Empresa empresa = new Empresa();
                empresa.Nome = empresaDto.Nome;

                _dbContext.Empresas.Add(empresa);
                await _dbContext.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = empresa.EmpresaId }, empresa);

            }
            return BadRequest();

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Edit(int id, EmpresaDto empresaDto)
        {
            if (ModelState.IsValid)
            {
                var empresa = await _dbContext.Empresas.FindAsync(id);
                if (empresa == null)
                {
                    return NotFound();
                }

                empresa.Nome = empresaDto.Nome;

                _dbContext.Update(empresa);
                await _dbContext.SaveChangesAsync();
                return Ok(empresa);
            }

            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id) 
        { 
            var empresa = await _dbContext.Empresas.FindAsync(id);
            if(empresa == null)
            {
                return NotFound();
            }

            _dbContext.Empresas.Remove(empresa);
            await _dbContext.SaveChangesAsync();
            return Ok(empresa);
        }


    }
}
