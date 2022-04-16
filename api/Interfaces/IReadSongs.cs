using System.Collections.Generic;
//using repos.mis321_pa4_ampayne4.Models;
using api.Models;

namespace api.Interfaces
{
    public interface IReadSongs
    {
        public List<Song> GetAll();
        public Song GetOne(int id);
         
    }
}