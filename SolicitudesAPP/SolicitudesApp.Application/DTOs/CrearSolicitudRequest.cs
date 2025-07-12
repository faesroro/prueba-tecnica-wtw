using SolicitudesApp.Domain.Enums;

namespace SolicitudesApp.Application.DTOs
{
    public class CrearSolicitudRequest
    {
        public string Tipo { get; set; } = null!;
        public object Datos { get; set; } = null!;
        public EstadoSolicitud Estado { get; set; }
    }
}