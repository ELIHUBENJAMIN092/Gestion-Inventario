using GestorInventario.Backend.Data;
using GestorInventario.Shared.Entitis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorInventario.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Entrada_InventarioController : ControllerBase
    {
        private readonly DataContext _datacontext;

        public Entrada_InventarioController(DataContext context)
        {
            _datacontext = context;
        }

        // Método HttpPost: Agregar Stock
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Entrada_Inventario entrada_stock)
        {
            _datacontext.Add(entrada_stock);
            await _datacontext.SaveChangesAsync();
            return Ok();
        }

        // Método HttpGet: Obtener Stock
        [HttpGet]
        public async Task<IActionResult> GetEntrada_Inventario()
        {
            var entrada_stock = await _datacontext.entrada_stock.ToListAsync();
            return Ok(entrada_stock);
        }

        // Método HttpPatch: Actualizar parcialmente el Stock
        [HttpPatch("{id}")]
        public async Task<IActionResult> Updateentrada_stock(int id, [FromBody] Entrada_Inventario updatedentrada_stock)
        {
            var existingentrada_stock = await _datacontext.Productos.FindAsync(id);
            if (existingentrada_stock == null)
            {
                return NotFound($"No se encontró el Stock con ID = {id}");
            }

            //Actualizar solo los campos necesarios
            if (updatedentrada_stock.Cantidad != 0) // Verifica si se ha proporcionado un valor válido
            {
                existingentrada_stock.Cantidad = updatedentrada_stock.Cantidad;
            }

            await _datacontext.SaveChangesAsync();
            return Ok(existingentrada_stock);
        }

        // Método HttpDelete: Eliminar el Stock
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteentrada_stock(int id)
        {
            var entrada_stock = await _datacontext.entrada_stock.FindAsync(id);
            if (entrada_stock == null)
            {
                return NotFound($"No se encontró el Stock con ID = {id}");
            }

            _datacontext.entrada_stock.Remove(entrada_stock);
            await _datacontext.SaveChangesAsync();
            return Ok($"Producto con ID = {id} eliminado correctamente");
        }
    }
}