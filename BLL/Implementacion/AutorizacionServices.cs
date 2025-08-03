using DAL.DBContext;

namespace BLL.Implementacion
{
    public class AutorizacionService
    {
        private readonly ConsultoriodbContext _context;

        public AutorizacionService(ConsultoriodbContext context)
        {
            _context = context;
        }

        public async Task<bool> TienePermiso(int secRol, string accion)
        {
            await Task.CompletedTask;

            var rolPermisos =
                _context
                .Permisosrols
                .FirstOrDefault(x =>
                                x.SecRol == secRol &&
                                x.EstaActivo == 1);

            if (rolPermisos == null) return false;

            return accion switch
            {
                "Consultar" => rolPermisos.Consultar == 1,
                "Modificar" => rolPermisos.Modificar == 1,
                "Eliminar" => rolPermisos.Eliminar == 1,
                _ => false,
            };
        }
    }
}
