﻿using Patterns.DataAccess.Models;

namespace Patterns.DataAccess;

public interface IRepository<T> where T : IEntity
{
    T? GetById(int id);
    List<T?> GetAll();
    void Insert(T item);
    void Update(T item);
    void Delete(T item);
}