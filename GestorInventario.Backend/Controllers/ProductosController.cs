using GestorInventario.Backend.Data;
using GestorInventario.Shared.Entitis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorInventario.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly DataContext _datacontext;

        public ProductosController(DataContext context)
        {
            _datacontext = context;
        }

        // Método HttpPost: Agregar un nuevo producto
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Producto productos)
        {
            _datacontext.Add(productos);
            await _datacontext.SaveChangesAsync();
            return Ok();
        }

        // Método HttpGet: Obtener todos los Productos
        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var productos = await _datacontext.Productos.ToListAsync();
            return Ok(productos);
        }

        // Método HttpPatch: Actualizar parcialmente un Producto por ID
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProductos(int id, [FromBody] Producto updatedProductos)
        {
            var existingProductos = await _datacontext.Productos.FindAsync(id);
            if (existingProductos == null)
            {
                return NotFound($"No se encontró el Producto con ID = {id}");
            }

            //Actualizar solo los campos necesarios
            if (!string.IsNullOrEmpty(updatedProductos.Name))
                existingProductos.Name = updatedProductos.Name;

            await _datacontext.SaveChangesAsync();
            return Ok(existingProductos);
        }

        // Método HttpDelete: Eliminar un Producto por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductos(int id)
        {
            var productos = await _datacontext.Productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound($"No se encontró el Producto con ID = {id}");
            }

            _datacontext.Productos.Remove(productos);
            await _datacontext.SaveChangesAsync();
            return Ok($"Producto con ID = {id} eliminado correctamente");
        }
    }
}