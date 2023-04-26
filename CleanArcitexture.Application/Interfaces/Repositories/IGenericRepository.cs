using CleanArcitexture.Domain.Common.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArcitexture.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class,IEntity
    {
        IQueryable<T> Entities { get; }
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllASync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
