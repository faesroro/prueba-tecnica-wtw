using Microsoft.EntityFrameworkCore;
using SolicitudesApp.Application.Interfaces;
using SolicitudesApp.Domain.Entities;
using SolicitudesApp.Infrastructure.Data;

namespace SolicitudesApp.Infrastructure.Repositories
{
    public class SolicitudRepository : ISolicitudRepository
    {
        private readonly AppDbContext _context;

        public SolicitudRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Solicitud solicitud)
        {
            await _context.Solicitudes.AddAsync(solicitud);
        }

        public async Task<IEnumerable<Solicitud>> GetAllAsync()
        {
            return await _context.Solicitudes.ToListAsync();
        }

        public async Task<Solicitud?> GetByIdAsync(Guid id)
        {
            return await _context.Solicitudes.FindAsync(id);
        }

        public void Remove(Solicitud solicitud)
        {
            _context.Solicitudes.Remove(solicitud);
        }

        public async Task<IEnumerable<Solicitud>> GetFilteredAsync(string? tipo, DateTime? fecha, int? estado)
        {
            var query = _context.Solicitudes.AsQueryable();

            if (!string.IsNullOrEmpty(tipo))
                query = query.Where(s => s.Tipo == tipo);

            if (fecha.HasValue)
                query = query.Where(s => s.FechaCreacion.Date == fecha.Value.Date);

            if (estado.HasValue)
                query = query.Where(s => (int)s.Estado == estado.Value);

            return await query.ToListAsync();
        }
    }
}