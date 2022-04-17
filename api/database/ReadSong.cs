using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using api.Interfaces;
//using repos.mis321_pa4_ampayne4.Models;
using api.Models;
using System.Data.SqlClient;

namespace api.database

{
    public class ReadSong : IReadSongs
    {
        public List<Song> GetAll()
        {
            List<Song> songs = new List<Song>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * from songs";

            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Song temp = new Song() {SongID = reader.GetInt32(0), SongTitle = reader.GetString(1), SongTimestamp = reader.GetDateTime(2), Deleted = reader.GetString(3), Favorited = reader.GetString(4)};
                songs.Add(temp);
            }
            return songs;
        }

        public Song GetOne(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @$"SELECT * from songs WHERE id = {id}";

            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader reader = cmd.ExecuteReader();

            reader.Read();

            return new Song(){SongID = reader.GetInt32(0), SongTitle = reader.GetString(1), SongTimestamp = reader.GetDateTime(2), Deleted = reader.GetString(3), Favorited = reader.GetString(4)};
        }
    }
}