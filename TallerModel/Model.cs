using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
namespace TallerModel
{

    public class TallerContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TallerMecanicoDB");
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Taller;Trusted_Connection=True;");
        }

    }

    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string? Nombre { get; set; } 
        public string? Apellido { get; set; } 
        public string? Contraseña { get; set; }
        public string? Email { get; set; }
        public string? Dni { get; set; }
        public string? Cuil { get; set;} 
        public string? Telefono { get; set; }
        public Rango? Puesto { get; set; }
    }

    public enum Rango
    {
        Gerente,
        Administrativo,
        DT,
        Mecanico
    }

    public class UsuarioServices
    {
        private TallerContext _context;

        public UsuarioServices()
        {
            _context = new TallerContext();
        }

        public async Task<Usuario> Create(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return(usuario);
        }

        public async Task<List<Usuario>> GetAll()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> GetById(int id)
        {
            return await _context.Usuarios.SingleOrDefaultAsync(u => u.UsuarioId == id);
        }

        public async Task<List<Usuario>> GetByNombreyAp(string aBuscar)
        {
            return await _context.Usuarios
                .Where(u => u.Nombre.Contains(aBuscar) || u.Apellido.Contains(aBuscar))
                .ToListAsync();
        }

        public async Task<Usuario> Update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<int?> Delete(int id)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.UsuarioId == id);
            if (usuario == null)
            {
                return null;
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return id;
        }
    }
}
