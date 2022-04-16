using System.Collections.Generic;
//using repos.mis321_pa4_ampayne4.Models;
using api.Models;

namespace api.Interfaces
{
    public interface ISongUtilities
    {
        public List<Song> playlist { get; set; }
         public void AddSong();
         public void DeleteSong();
         public void EditSong();
         public void PrintPlaylist();
    }
}