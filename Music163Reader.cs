using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json.Linq;

namespace NetEaseMusicCacheTool
{
    public class Music163Reader
    {
        public delegate void ReadLogDelegate(ReadLogEventArgs e);

        public event ReadLogDelegate ReadLogEvent;

        public class ReadLogEventArgs : EventArgs
        {
            public string Title { get; set; }
            public string Artist { get; set; }
            public string Album { get; set; }

            public ReadLogEventArgs(string title, string artist, string album)
            {
                this.Title = title;
                this.Album = album;
                this.Artist = artist;
            }
        }

        private string _path;
        public Music163Reader(string path)
        {
            _path = path;
        }

        Dictionary<string, Thread> taskList = new Dictionary<string, Thread>();


        private enum ListOperation
        {
            Add,
            Remove,
            Get
        }

        private object lockObj = new object();

        private KeyValuePair<string, Thread> Opp(string idx, Thread th, ListOperation op)
        {
            KeyValuePair<string, Thread> kv = new KeyValuePair<string, Thread>();
            lock (lockObj)
            {
                switch (op)
                {
                    case ListOperation.Add:
                        taskList.Add(idx, th);
                        break;
                    case ListOperation.Remove:
                        taskList.Remove(idx);
                        break;
                    case ListOperation.Get:
                        kv = taskList.FirstOrDefault();
                        break;
                }
            }
            return kv;
        }

        private int max = 50;
        private int current = 0;

        public void Start()
        {
            new Thread(() =>
            {
                var files = Directory.GetFiles(_path, "*idx!", SearchOption.TopDirectoryOnly);
                TagLib.File file = null;
                foreach (var idx in files)
                {
                    //var th = new Thread(() =>
                    //{
                    //    current++;
                    var uc = idx.Replace(".idx!", "");
                    if (!File.Exists(uc))
                    {
                        File.Delete(idx);
                        continue;
                    }
                    var comment = File.ReadAllText(idx);
                    var comment163 = JObject.Parse(comment).ToObject<Comment163>();
                    var song163 = Music163HttpRequest.Request(comment163.musicId);
                    if (song163 == null)
                    {
                        continue;
                    }
                    file = TagLib.File.Create(uc);

                    file.Tag.Album = song163.album?.name;
                    file.Tag.AlbumArtists = song163.album?.artists?.Select(d => d.name).ToArray();
                    file.Tag.Genres = new[] { song163.album?.type ?? "" };
                    file.Tag.Title = song163.name;
                    //file.Tag.Comment = string.Format("163 key(Don't modify):{0}");
                    file.Save();

                    var artist = file.Tag.FirstAlbumArtist;
                    var title = file.Tag.Title;
                    file.Dispose();
                    var path = _path + "\\" + new string($"{artist} - {title} {song163.id}.mp3".ToCharArray().Where(d => !Path.GetInvalidFileNameChars().Contains(d)).ToArray());
                    //path = Path.GetInvalidPathChars().Aggregate(path, (current, c) => current.Replace(c.ToString(), ""));
                    //path = Path.GetInvalidFileNameChars().Aggregate(path, (s, c) => s.Replace(c.ToString(), ""));
                    File.Move(uc, path);
                    File.Delete(idx);
                    ReadLogEvent?.Invoke(new ReadLogEventArgs(file.Tag.Title, file.Tag.FirstAlbumArtist, file.Tag.Album));
                    //file.Tag.Comment;
                    //    current--;
                    //})
                    //{ IsBackground = true };
                    //Opp(idx, th, ListOperation.Add);
                }
            }).Start();

            //new Thread(() =>
            //{
            //    for (;;)
            //    {
            //        if (current >= max)
            //        {
            //            Thread.Sleep(100);
            //            continue;
            //        }
            //        var th = Opp("", null, ListOperation.Get);
            //        if (th.Key != null)
            //        {
            //            Opp(th.Key, null, ListOperation.Remove);
            //            th.Value.Start();
            //        }
            //    }


            //}).Start();
        }
    }
}
