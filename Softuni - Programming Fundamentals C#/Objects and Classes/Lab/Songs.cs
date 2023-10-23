using System;
using System.Collections.Generic;
using System.Linq;

namespace Songs
{
    class Songs
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("_");
                string typeList = input[0];
                string name = input[1];
                string time = input[2];
                Song song = new Song(typeList, name, time);
                songs.Add(song);
            }
            string list = Console.ReadLine();
            if (list!="all")
            {
                songs = songs.Where(x => x.TypeList == list).ToList(); 
            }
            foreach (Song item in songs)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
    public class Song
    {
        private string typeList;
        private string name;
        private string time;
        public Song(string typeList,string name,string time)
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
