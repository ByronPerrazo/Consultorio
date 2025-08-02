﻿namespace ConsultorioWebApp.Models.ViewModel
{
    public class RolVM
    {
        public int Secuencial { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public ulong? EsActivo { get; set; }
        public PermisosrolVM oPermisosRol { get; set; }
    }
}
