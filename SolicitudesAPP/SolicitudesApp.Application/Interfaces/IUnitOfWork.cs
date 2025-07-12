using System.Threading.Tasks;

namespace SolicitudesApp.Application.Interfaces
{
    public interface IUnitOfWork
    {
        ISolicitudRepository Solicitudes { get; }
        Task<int> SaveChangesAsync();
    }
}