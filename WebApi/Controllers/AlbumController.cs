using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces.Services;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IMusicService _musicService;

        public AlbumController(IMusicService musicService)
        {
            _musicService = musicService;
        }

        [HttpGet("albumler")]
        public IActionResult GetAll()
        {
            var albums = _musicService.GetAllAlbums();
            return Ok(albums);
        }
    }
}
