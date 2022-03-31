using IRunes.Abstarctions;
using IRunes.Data;
using IRunes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRunes.Servers
{
    public class AlbumService : IAlbumService
    {
        private readonly ApplicationDbContext _context;

        public AlbumService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(string name, string cover, decimal price)
        {
            Album item = new Album
            {
                Name = name,
                Cover = cover,
                Price = price,
            };

            _context.Albums.Add(item);
            return _context.SaveChanges() != 0;
        }

        public Album GetAlbumById(int albumId)
        {
            return _context.Albums.Find(albumId);
        }

        public List<Album> GetAlbums()
        {
            List<Album> albums = _context.Albums.ToList();
            return albums;
        }

        public bool RemoveById(int albumId)
        {
            var album = GetAlbumById(albumId);
            if (album == default(Album))
            {
                return false;
            }
            _context.Remove(album);
            return _context.SaveChanges() != 0;
        }

        public bool Update(int albumId, string name, string cover, decimal price)
        {
            var album = GetAlbumById(albumId);
            if (album == default(Album))
            {
                return false;
            }
            album.Name = name;
            album.Cover = cover;
            album.Price = price;
            _context.Update(album);
            return _context.SaveChanges() != 0;
        }
    }
}
