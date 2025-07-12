using SolicitudesApp.Application.DTOs;
using SolicitudesApp.Application.Interfaces;
using SolicitudesApp.Domain.Entities;
using SolicitudesApp.Domain.Enums;
using System.Text.Json;

namespace SolicitudesApp.Application.Services
{
    public class SolicitudService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SolicitudService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SolicitudDto>> GetAllAsync()
        {
            var solicitudes = await _unitOfWork.Solicitudes.GetAllAsync();

            return solicitudes.Select(MapToDto);
        }

        public async Task<IEnumerable<SolicitudDto>> GetFilteredAsync(string? tipo, DateTime? fecha, int? estado)
        {
            var solicitudes = await _unitOfWork.Solicitudes.GetFilteredAsync(tipo, fecha, estado);
            return solicitudes.Select(MapToDto);
        }

        public async Task<SolicitudDto?> GetByIdAsync(Guid id)
        {
            var solicitud = await _unitOfWork.Solicitudes.GetByIdAsync(id);
            return solicitud is null ? null : MapToDto(solicitud);
        }

        public async Task<Guid> CreateAsync(string tipo, EstadoSolicitud estado, object datos)
        {
            var nueva = new Solicitud
            {
                Tipo = tipo,
                Estado = estado,
                Datos = JsonSerializer.Serialize(datos)
            };

            await _unitOfWork.Solicitudes.AddAsync(nueva);
            await _unitOfWork.SaveChangesAsync();

            return nueva.Id;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var solicitud = await _unitOfWork.Solicitudes.GetByIdAsync(id);
            if (solicitud == null) return false;

            _unitOfWork.Solicitudes.Remove(solicitud);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        private SolicitudDto MapToDto(Solicitud solicitud)
        {
            return new SolicitudDto
            {
                Id = solicitud.Id,
                Tipo = solicitud.Tipo,
                Estado = solicitud.Estado.ToString(),
                FechaCreacion = solicitud.FechaCreacion,
                Datos = JsonSerializer.Deserialize<object>(solicitud.Datos) ?? new { }
            };
        }
    }
}