using System;
using WebApi.Entities;
using WebApi.Interfaces.Repositories;
using WebApi.Interfaces.Services;

namespace WebApi.Services;

public class MusicService : IMusicService
{
    private readonly IAlbumRepository _albumRepository;

    public MusicService(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }

    public void CreateAlbum(Album album)
    {
        if (string.IsNullOrEmpty(album.Name))
        {
            throw new Exception("Albüm adı boş bırakılamaz");
        }
        
        if (album.Name.Length > 15)
        {
            throw new Exception("Albüm adı 15 karakterden uzun olamaz! ");
        }

        if (album.ReleaseDate.Year > DateTime.UtcNow.Year) 
        {
            throw new Exception("Tarih yanlış girildi!");
        }

        _albumRepository.Add(album);
    }

    public List<Album> GetAllAlbums()
    {
       return _albumRepository.GetAll();
        
    }

    public Album? GetAlbumById(int id)
    {
        
        if (id <= 0)
        {
            throw new Exception("ID değeri 0 veya 0'dan küçük olamaz! ");
        }
        return _albumRepository.GetById(id);
    }
}
