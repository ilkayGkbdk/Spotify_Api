using System;
using WebApi.Contexts;
using WebApi.Entities;
using WebApi.Interfaces.Repositories;

namespace WebApi.Repositories;

public class AlbumRepository : IAlbumRepository
{

    private readonly AppDbContext _context;

    public AlbumRepository(AppDbContext context)
    {
        _context = context;
        
    }

    public void Add(Album album)
    {
        _context.Albums.Add(album);
        _context.SaveChanges();
    }

    public List<Album> GetAll()
    {
        return _context.Albums.ToList();
    }

    public Album? GetById(int id)
    {
        return _context.Albums.FirstOrDefault(a => a.Id == id);
    }
}
