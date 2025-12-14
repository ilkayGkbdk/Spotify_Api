using System;

namespace WebApi.Entities;

public class Album
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Artist { get; set; }
    public DateTime ReleaseDate { get; set; }
    public List<Song> Songs { get; set; }

}
