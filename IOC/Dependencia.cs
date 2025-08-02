﻿using BLL.Implementacion;
using BLL.Interfaces;
using DAL.DBContext;
using DAL.Implementacion;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencia(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<ConsultoriodbContext>(options =>
                {
                    options
                    .UseMySql(configuration.GetConnectionString("ConexionDBAWS"),
                              Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.37-mysql"));
                });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddSingleton<IDatosGlobalesServices, DatosGlobalesServicio>();

            services.AddScoped<IUsuarioServices, UsuarioServices>();
            services.AddScoped<IRolServices, RolServices>();
            services.AddScoped<IStorageServices, StorageServices>();
            services.AddScoped<IUtilidadesServices, UtilidadesServices>();
            services.AddScoped<ICorreoServices, CorreoServices>();
            services.AddScoped<ISmtpClientWrapper, SmtpClientWrapper>();
            services.AddScoped<IEmpresaStorageServices, EmpresaStorageServices>();
            services.AddScoped<IEmpresaServices, EmpresaServices>();
            services.AddScoped<IMenuServices, MenuServices>();
            services.AddScoped<IProvinciaServices, ProvinciaServices>();
            services.AddScoped<ICantonServices, CantonServices>();
            services.AddScoped<IParroquiaServices, ParroquiaServices>();
            services.AddScoped<ICatalogoServices, CatalogoServices>();
            services.AddScoped<IPermisosRolServices, PermisosRolServices>();
            services.AddScoped<IRolMenuServices, RolMenuServices>();
            services.AddScoped<IValidacionServices, ValidacionServices>();
            services.AddScoped<IMenusHijosDesplegables, MenusHijosDesplegables>();
            services.AddScoped<AutorizacionService>();



        }
    }
}
