using System;
using System.Collections.Generic;
using System.Numerics;

namespace Objects_tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Song> songs = new List<Song>();

            int songsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < songsCount; i++)
            {
                string[] songProperties = Console.ReadLine().Split('_');

                Song song = new Song(songProperties[0], songProperties[1], songProperties[2]);
                /* {
                   TypeList = songProperties[0],
                   Name = songProperties[1],
                   Time = songProperties[2]
                   };

                BOTH IF NO CONSTRUCTOR IS CRETED
                
                 song.TypeList = songProperties[0];
                 song.Name = songProperties[1];
                 song.Time = songProperties[2];
                */

                songs.Add(song);
            }

            string typeList = Console.ReadLine();

            if (typeList == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (Song song in songs)
                {
                    if (song.TypeList == typeList)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }

    class Song
    {
        public Song(string typeList, string name, string time)
        {
            this.TypeList = typeList;
            this.Name = name;
            this.Time = time;
        }
        public string TypeList { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }
    }
}
