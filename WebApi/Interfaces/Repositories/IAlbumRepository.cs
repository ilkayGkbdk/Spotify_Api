using System;
using WebApi.Entities;

namespace WebApi.Interfaces.Repositories;

public interface IAlbumRepository
{
    List<Album> GetAll();
    Album? GetById(int id);
    void Add(Album album);

}
