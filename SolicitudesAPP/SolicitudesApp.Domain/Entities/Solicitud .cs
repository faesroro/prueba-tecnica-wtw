using System;
using SolicitudesApp.Domain.Enums;

namespace SolicitudesApp.Domain.Entities
{
    public class Solicitud
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Tipo { get; set; } = null!; // Ej: "Vacaciones", "Permiso"
        public EstadoSolicitud Estado { get; set; } = EstadoSolicitud.Pendiente;
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Datos específicos de la solicitud, como JSON serializado
        /// </summary>
        public string Datos { get; set; } = null!;
    }
}
