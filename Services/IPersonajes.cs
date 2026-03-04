using System;
using System.Collections.Generic;
using System.Text;

namespace TheSimpsons.Services
{
    public interface IPersonajes
    {
        Task<List<Result>> GetPersonajesAsync();

        Task<Personaje> GetPersonajeAsync(int id);
    }
}
