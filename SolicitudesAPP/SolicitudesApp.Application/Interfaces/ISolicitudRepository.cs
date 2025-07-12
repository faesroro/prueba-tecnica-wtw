using SolicitudesApp.Domain.Entities;

namespace SolicitudesApp.Application.Interfaces
{
    public interface ISolicitudRepository
    {
        Task<Solicitud?> GetByIdAsync(Guid id);
        Task<IEnumerable<Solicitud>> GetAllAsync();
        Task<IEnumerable<Solicitud>> GetFilteredAsync(string? tipo, DateTime? fecha, int? estado);
        Task AddAsync(Solicitud solicitud);
        void Remove(Solicitud solicitud);
    }
}