using MySql.Data.MySqlClient;
using api.Interfaces;
//using repos.mis321_pa4_ampayne4.Models;
using api.Models;


namespace api.database
{
    public class CreateSong : ICreateSongs
    {
        public static void CreateSongTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE songs(id INTEGER PRIMARY KEY AUTO_INCREMENT, title TEXT, time_added DATETIME, deleted TEXT)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();

        }
        public void Create(Song song)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT into songs(title, time_added, deleted) VALUES(@title, @time_added, @deleted)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@title", song.SongTitle);
            cmd.Parameters.AddWithValue("@time_added", song.SongTimestamp);
            cmd.Parameters.AddWithValue("@deleted", song.Deleted);
            
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}