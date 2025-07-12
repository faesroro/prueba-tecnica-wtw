using SolicitudesApp.Application.Interfaces;
using SolicitudesApp.Infrastructure.Data;

namespace SolicitudesApp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public ISolicitudRepository Solicitudes { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Solicitudes = new SolicitudRepository(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}