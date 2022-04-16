using System;
using System.IO;
using System.Collections.Generic;
//using repos.mis321_pa4_ampayne4.Models;
using api.Models;
//using repos.mis321_pa4_ampayne4.FileHandleing;
using api.Interfaces;
using api.database;

namespace api.Utilities
{
    public class SongUtilDatabase : ISongUtilities
    {
        public CreateSong Create = new CreateSong();
        public DeleteSong Delete = new DeleteSong();
        public UpdateSong Update = new UpdateSong();



        public List<Song> playlist { get; set; }
         public void PrintPlaylist() { // display all items in the playlist to the console
            Console.Clear();
            playlist.Sort();
            foreach (Song song in playlist) { // for every song in the playlist, write the song's ToString to the console
                if(song.Deleted != "y"){
                    Console.WriteLine(song.ToString());
                }
            }
            Console.WriteLine();
        }

        public void AddSong() { // allow the user to add a new song to the playlist
            int newID;

            if (playlist.Count != 0) { // sort the playlist so that the newest song added has the highest SongID
                playlist.Sort();
                newID = playlist[0].SongID + 1;
            }
            else {
                newID = 1;
            }

            Song mySong = new Song(){SongID = newID, SongTitle = PromptSongDetails(), SongTimestamp = DateTime.Now, Deleted = "n"};
            playlist.Add(mySong);    
            Create.Create(mySong);
        }

        public string PromptSongDetails() { // Ask user for title of the song to add
            Console.Clear();
            Console.WriteLine("What is the title of your song?");
            return Console.ReadLine();
        }

        public void DeleteSong() { // remove a song from the playlist given the SongID
            int index;
            
            do {
                // find index
                int IDToDelete = PromptSongToDelete(playlist);
            
                index = playlist.FindIndex(currentSong => currentSong.SongID == IDToDelete); // iterate through songs in playlist and compare their IDs to the ID the user wants to delete 

            } while (!CheckValidIndex(index)); // make sure the song ID exists - if playlist.FindIndex returns -1, the ID was not found in the list


            // remove song at index found
            string titleToDelete = playlist[index].SongTitle;
            playlist[index].Deleted = "y";
            Delete.Delete(playlist[index].SongID);
            // playlist.RemoveAt(index);
            
            Console.Clear();
            Console.WriteLine("{0} has been removed.", titleToDelete);
            
        }

        public int PromptSongToDelete(List<Song> playlist) { // ask the user the ID of the song they want to delete
            
            string userInput;
            
            do {

                Console.Clear();
                PrintPlaylist();
                Console.WriteLine("What is the ID of the song you want to delete?");
                userInput = Console.ReadLine();

            } while (!CheckValidInput(userInput)); // ID entered must be an integer
            
            return int.Parse(userInput);
        }

        public int PromptSongToEdit(List<Song> playlist) { // ask the user the ID of the song they want to delete
            
            string userInput;
            
            do {

                Console.Clear();
                PrintPlaylist();
                Console.WriteLine("What is the ID of the song you want to edit?");
                userInput = Console.ReadLine();

            } while (!CheckValidInput(userInput)); // ID entered must be an integer
            
            return int.Parse(userInput);
        }

        public bool CheckValidIndex(int index) {
            if (index == -1) { // if playlist.FindAt returns -1, the ID was not found in the list
                Console.WriteLine("\nID does not exist in the current playlist. Press any key to continue");
                Console.ReadKey();
                return false;
            }
            return true;
        }

        public bool CheckValidInput(string userInput) { // check to see if user's input is an integer
            int parsedInput;

            if (!int.TryParse(userInput, out parsedInput)) {
                Console.WriteLine("Invalid input. Try again.");
                Console.ReadKey();
                return false;
            }

            return true;
        }

        public void EditSong()
        {
            int index;
            
            do {
                // find index
                int IDToDelete = PromptSongToEdit(playlist);
            
                index = playlist.FindIndex(currentSong => currentSong.SongID == IDToDelete); // iterate through songs in playlist and compare their IDs to the ID the user wants to delete 

            } while (!CheckValidIndex(index)); // make sure the song ID exists - if playlist.FindIndex returns -1, the ID was not found in the list


            // remove song at index found
            string titleToEdit = playlist[index].SongTitle;
            Console.WriteLine($"What would you like to change {titleToEdit} to?");
            string newTitle = Console.ReadLine();
            playlist[index].SongTitle = newTitle;
            Update.Update(playlist[index]);
            
            Console.Clear();
            Console.WriteLine("{0} has been changed to {1}.", titleToEdit, newTitle);
        }

    }
}