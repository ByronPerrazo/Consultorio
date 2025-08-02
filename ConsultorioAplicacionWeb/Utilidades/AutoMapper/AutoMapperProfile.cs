using AutoMapper;
using Entity;
using ConsultorioWebApp.Models.ViewModel;

namespace ConsultorioWebApp.Utilidades.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Rol, RolVM>().ReverseMap();
            CreateMap<Empresa, EmpresaVM>()
                .ForMember(destino =>
                           destino.EstaActivo,
                                   opt =>
                                   opt.MapFrom(origen =>
                                               origen.EstaActivo));

            CreateMap<EmpresaVM, Empresa>()
                .ForMember(destino =>
                           destino.EstaActivo,
                                   opt =>
                                   opt.MapFrom(origen =>
                                                      origen.EstaActivo == 1));

            #region Usuario
            CreateMap<Usuario, UsuarioVM>()
                .ForMember(destino =>
                           destino.EsActivo,
                                   opt =>
                                   opt.MapFrom(origen =>
                                               origen.EsActivo))
                .ForMember(destino =>
                           destino.NombreRol,
                                    opt =>
                                    opt.MapFrom(origen =>
                                                origen.SecRolNavigation.Descripcion));

            CreateMap<UsuarioVM, Usuario>()
                .ForMember(destino =>
                           destino.EsActivo,
                                   opt =>
                                   opt.MapFrom(origen =>
                                                      origen.EsActivo == 1))
                .ForMember(destino =>
                           destino.SecRolNavigation,
                                   opt =>
                                   opt.Ignore());
            #endregion usuario

            #region Menu

            CreateMap<Menu, MenuVM>()
                           .ForMember(destino => destino.SubMenu,
                                      opt => opt.MapFrom(origen => origen.InverseSecMenuPadreNavigation))
                           ;

            CreateMap<MenuVM, Menu>()
                .ForMember(destino =>
                    destino.InverseSecMenuPadreNavigation,
                    opt => opt.Ignore()
                );
            #endregion

            CreateMap<Provincia, ProvinciaVM>().ReverseMap();
            CreateMap<Canton, CantonVM>().ReverseMap();
            CreateMap<Parroquia, ParroquiaVM>().ReverseMap();

            CreateMap<Catalogo, CatalogoVM>()
                .ForMember(destino =>
                           destino.EstaActivo,
                                   opt =>
                                   opt.MapFrom(origen =>
                                               origen.EstaActivo));

            CreateMap<CatalogoVM, Catalogo>()
                .ForMember(destino =>
                           destino.EstaActivo,
                                   opt =>
                                   opt.MapFrom(origen =>
                                                      origen.EstaActivo == 1));

            CreateMap<Permisosrol, PermisosrolVM>().ReverseMap();

            CreateMap<RolMenu, RolMenuVM>()
                .ForMember(destino =>
                           destino.DescripcionRol,
                                   opt =>
                                   opt.MapFrom(origen =>
                                               origen.SecRolNavigation.Descripcion))
                .ForMember(destino =>
                           destino.DescripcionMenu,
                                   opt =>
                                   opt.MapFrom(origen =>
                                               origen.SecMenuNavigation.Descripcion));

            CreateMap<RolMenuVM, RolMenu>()
                .ForMember(destino =>
                           destino.SecRolNavigation,
                                   opt =>
                                   opt.Ignore())
                .ForMember(destino =>
                           destino.SecMenuNavigation,
                                   opt =>
                                   opt.Ignore());
        }
    }
}