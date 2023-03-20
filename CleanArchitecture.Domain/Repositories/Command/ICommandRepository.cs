﻿using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Repositories.Command
{
    public interface ICommandRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
