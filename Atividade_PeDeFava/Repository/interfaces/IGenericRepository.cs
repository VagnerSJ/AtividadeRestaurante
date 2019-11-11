﻿using Atividade_PeDeFava.Models.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atividade_PeDeFava.Repository.interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> Create(T item);
        Task<T> Update(T item);
        Task Delete(int id);
        Task<ICollection<T>> FindAll();
        Task<T> FindById(int id);
    }
}
