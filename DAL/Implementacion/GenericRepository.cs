﻿using DAL.DBContext;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Implementacion
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ConsultoriodbContext _dbContext;

        public GenericRepository(ConsultoriodbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<TEntity?> Obtener(Expression<Func<TEntity, bool>> filtro, string? incluirPropiedades = null)
        {
            try
            {
                IQueryable<TEntity> query = _dbContext.Set<TEntity>();
                if (incluirPropiedades != null)
                {
                    foreach (var propiedad in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(propiedad);
                    }
                }
                return await query.FirstOrDefaultAsync(filtro);
            }
            catch
            {
                throw;
            }
        }
        public async Task<TEntity> Crear(TEntity entidad)
        {
            try
            {
                _dbContext.Set<TEntity>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {

                throw;
            }
        }

        public async Task<bool> Eliminar(TEntity entidad)
        {
            try
            {
                _dbContext.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {

                throw;
            }
        }

        public async Task<bool> Editar(TEntity entidad)
        {
            try
            {
                _dbContext.Update(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {

                throw;
            }
        }

        public async Task<IQueryable<TEntity>> Consultar(Expression<Func<TEntity, bool>> filtro = null)
        {
            await Task.CompletedTask;

            IQueryable<TEntity> queryEntidad = filtro == null
                                              ? _dbContext.Set<TEntity>()
                                              : _dbContext.Set<TEntity>()
                                              .Where(filtro);
            return queryEntidad;
        }

    }

}
