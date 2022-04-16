using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.AspNetCore.Cors;
using api.database;
using api.Interfaces;
using api.Utilities;


namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        // GET: api/Songs
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        // public IEnumerable<string> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }

        //above is original copy in comments, below is my attempt at a get

        // public List<Song> Get()
        // {
        //     List<Song> mySongs = new List<Song>();
        //     mySongs.Add(new Song{SongID = 1, SongTitle = "TNT", SongTimestamp = DateTime.Now, Deleted = "false"});
        //     return mySongs;
        // }

        public List<Song> Get()
        {
            ReadSong read = new ReadSong();
            
            List<Song> mySongs = read.GetAll();

            return mySongs;
        }


        // GET: api/Songs/5

        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Songs
        [HttpPost]
        // public void Post([FromBody] Song song)
        public void Post([FromBody] Song song)
        {
            // CreateSong create = new CreateSong();

            // Song newSong = create.Create(song);

            // return newSong;

        }

        // PUT: api/Songs/5
        [HttpPut("{id}")]
        //public void Put(int id, [FromBody] Song song)
        public void Put(int id, [FromBody] Song song)
        {
            //UpdateSong update = new UpdateSong();
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
