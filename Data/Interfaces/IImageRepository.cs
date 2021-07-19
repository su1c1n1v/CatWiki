using CatWiki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatWiki.Data
{
    public interface IImageRepository
    {
        Image GetImageById(string id);

    }
}
