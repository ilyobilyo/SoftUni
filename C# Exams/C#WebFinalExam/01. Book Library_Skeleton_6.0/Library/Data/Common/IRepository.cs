﻿namespace Library.Data.Common
{
    public interface IRepository
    {
        Task AddAsync<T>(T entity) where T : class;

        IQueryable<T> All<T>() where T : class;

        Task<int> SaveChangesAsync();

        int SaveChanges();
    }
}
