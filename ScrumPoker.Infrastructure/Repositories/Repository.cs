using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using ScrumPoker.Application.Interfaces;

namespace ScrumPoker.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> CreateAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();

        // "Id" özelliği var mı diye kontrol et
        var idProperty = typeof(T).GetProperty("Id");
        if (idProperty == null)
        {
            throw new InvalidOperationException($"Entity of type {typeof(T).Name} does not have an 'Id' property.");
        }

        // "Id" property'sinin değerini al
        var idValue = idProperty.GetValue(entity);
        if (idValue == null)
        {
            throw new InvalidOperationException("The 'Id' property was not set after saving the entity.");
        }

        return (int)idValue; // ID değeri döndürülüyor
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task RemoveAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

}
