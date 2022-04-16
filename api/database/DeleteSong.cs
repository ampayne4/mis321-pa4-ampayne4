using MySql.Data.MySqlClient;
using api.Interfaces;
//using repos.mis321_pa4_ampayne4.Models;
using api.Models;

namespace api.database
{
    public class DeleteSong : IDeleteSongs
    {
        
        public static void DropSongTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DROP TABLE IF EXISTS songs";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();

        }

        public void Delete(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @$"UPDATE songs SET deleted = @deleted WHERE id = {id}";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@deleted", "y");
            
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}