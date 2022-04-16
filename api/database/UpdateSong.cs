using MySql.Data.MySqlClient;
using api.Interfaces;
//using api.Models;
using api.Models;

namespace api.database
{
    public class UpdateSong : IUpdateSongs
    {
        public void Update(Song song)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @$"UPDATE songs SET title = @title WHERE id = {song.SongID}";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@title", song.SongTitle);
            
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}