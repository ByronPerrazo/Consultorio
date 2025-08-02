﻿namespace ConsultorioWebApp.Models.ViewModel
{
    public class MenuVM
    {
        public string? Descripcion { get; set; }

        public int Secuencial { get; set; }

        public string? DescripcionMenuPadre { get; set; }

        public int? SecMenuPadre { get; set; }

        public string? Icono { get; set; }

        public string? Controlador { get; set; }

        public string? PaginaAccion { get; set; }

        public short? EsActivo { get; set; }

        public virtual ICollection<MenuVM>? SubMenu { get; set; }


    }
}
