using System;

namespace WebApi.Entities;

public class Song
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Duration { get; set; }
    public int AlbumId { get; set; }
    public string Category {get; set;}
    public Album Album { get; set; }

}
