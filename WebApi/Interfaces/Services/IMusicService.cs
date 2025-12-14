using System;
using WebApi.Entities;

namespace WebApi.Interfaces.Services;

public interface IMusicService
{
    List<Album> GetAllAlbums();
    Album? GetAlbumById(int id);
    void CreateAlbum(Album album);

}
