using System.Collections.Generic;

namespace ConsultorioWebApp.Models.ViewModel
{
    public class UsuarioEditarVM
    {
        public UsuarioVM Usuario { get; set; }
        public List<RolVM> ListaRoles { get; set; }
    }
}
