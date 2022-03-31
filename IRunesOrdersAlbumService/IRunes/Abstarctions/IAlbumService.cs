using IRunes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRunes.Abstarctions
{
   public interface IAlbumService
    {
        bool Create(string name,  string cover, decimal price);
        bool Update(int albumId, string name, string cover, decimal price);
        List<Album> GetAlbums();
        Album GetAlbumById(int albumId);
        bool RemoveById(int albumId);
    }
}
