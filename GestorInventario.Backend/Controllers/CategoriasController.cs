using GestorInventario.Backend.Data;
using GestorInventario.Shared.Entitis;
using MathNet.Numerics.Distributions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorInventario.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly DataContext _datacontext;

        public CategoriasController(DataContext context)
        {
            _datacontext = context;
        }

        // Método HttpPost: Agregar un nueva Categoria
        [HttpPost]
        public async Task<IActionResult> AddCategorias([FromBody] Categoria categorias)
        {
            _datacontext.Add(categorias);
            await _datacontext.SaveChangesAsync();
            return Ok();
        }

        // Método HttpGet: Obtener las Categorias
        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            var categorias = await _datacontext.categorias.ToListAsync();
            return Ok(categorias);
        }

        // Método HttpPatch: Actualizar parcialmente una Categoria por ID
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCategorias(int id, [FromBody] Categoria updatedcategorias)
        {
            var existingcategorias = await _datacontext.categorias.FindAsync(id);
            if (existingcategorias == null)
            {
                return NotFound($"No se encontró la Categoria con ID = {id}");
            }

            //Actualizar solo los campos necesarios
            if (!string.IsNullOrEmpty(updatedcategorias.Name))
                existingcategorias.Name = updatedcategorias.Name;

            await _datacontext.SaveChangesAsync();
            return Ok(existingcategorias);
        }

        // Método HttpDelete: Eliminar una Categoria por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecategorias(int id)
        {
            var categorias = await _datacontext.categorias.FindAsync(id);
            if (categorias == null)
            {
                return NotFound($"No se encontró la Categoria con ID = {id}");
            }

            _datacontext.categorias.Remove(categorias);
            await _datacontext.SaveChangesAsync();
            return Ok($"Categoria con ID = {id} eliminado correctamente");
        }
    }
}