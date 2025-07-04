﻿using MiPrimerWebApi.Model;

namespace MiPrimerWebApi.Bussiness
{
    public interface IAutoresService
    {
        Task<Autor> CreateAutor(Autor autor);
        Task DeleteAutor(int id);
        Task<Autor?> GetAutor(int id);
        Task<IEnumerable<Autor>> GetAutores();
        Task UpdateAutor(int id, Autor autor);
    }
}