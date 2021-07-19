using CatWiki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatWiki.Data
{
    public interface ICatsRepository
    {
        Task<List<Cats>> GetCatByName(string name);

        Task<List<Cats>> GetAllCats();

        Task<List<Cats>> GetCatById(string id);
    }
}
