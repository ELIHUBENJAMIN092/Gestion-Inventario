using GestorInventario.Backend.Data;
using GestorInventario.Shared.Entitis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorInventario.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedorController : ControllerBase
    {
        private readonly DataContext _datacontext;

        public ProveedorController(DataContext context)
        {
            _datacontext = context;
        }

        // Método HttpPost: Agregar un nuevo Proveedor
        [HttpPost]
        public async Task<IActionResult> AddProveedor([FromBody] Proveedor proveedores)
        {
            _datacontext.Add(proveedores);
            await _datacontext.SaveChangesAsync();
            return Ok();
        }

        // Método HttpGet: Obtener todos los Proveedores
        [HttpGet]
        public async Task<IActionResult> GetProveedor()
        {
            var proveedores = await _datacontext.proveedores.ToListAsync();
            return Ok(proveedores);
        }

        // Método HttpPatch: Actualizar parcialmente un Proveedor por ID
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProveedor(int id, [FromBody] Proveedor updatedproveedores)
        {
            var existingproveedores = await _datacontext.proveedores.FindAsync(id);
            if (existingproveedores == null)
            {
                return NotFound($"No se encontró el Proveedor con ID = {id}");
            }

            //Actualizar solo los campos necesarios
            if (!string.IsNullOrEmpty(updatedproveedores.nombre))
                existingproveedores.nombre = updatedproveedores.nombre;

            await _datacontext.SaveChangesAsync();
            return Ok(existingproveedores);
        }

        // Método HttpDelete: Eliminar un Proveedor por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProveedor(int id)
        {
            var proveedores = await _datacontext.proveedores.FindAsync(id);
            if (proveedores == null)
            {
                return NotFound($"No se encontró el Proveedor con ID = {id}");
            }

            _datacontext.proveedores.Remove(proveedores);
            await _datacontext.SaveChangesAsync();
            return Ok($"Proveedores con ID = {id} eliminado correctamente");
        }
    }
}