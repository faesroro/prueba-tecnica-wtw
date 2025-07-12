using System;

namespace SolicitudesApp.Application.DTOs
{
    public class SolicitudDto
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public object Datos { get; set; } = null!;
    }
}