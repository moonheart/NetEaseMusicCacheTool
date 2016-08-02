using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEaseMusicCacheTool
{
    //注：主类名默认Root,可修改.

    public class Artist
    {
        public int img1v1Id { get; set; }
        public int musicSize { get; set; }
        public IList<object> alias { get; set; }
        public string briefDesc { get; set; }
        public int picId { get; set; }
        public int albumSize { get; set; }
        public string img1v1Url { get; set; }
        public string picUrl { get; set; }
        public string trans { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }
    public class Album
    {
        public IList<object> songs { get; set; }
        public bool paid { get; set; }
        public bool onSale { get; set; }
        public string tags { get; set; }
        public int status { get; set; }
        public IList<Artist> artists { get; set; }
        public IList<object> alias { get; set; }
        public int copyrightId { get; set; }
        public Artist artist { get; set; }
        public string briefDesc { get; set; }
        public string company { get; set; }
        public long picId { get; set; }
        public long publishTime { get; set; }
        public string commentThreadId { get; set; }
        public string picUrl { get; set; }
        public string description { get; set; }
        public object subType { get; set; }
        public string blurPicUrl { get; set; }
        public int companyId { get; set; }
        public long pic { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public string type { get; set; }
        public int size { get; set; }
    }
    public class HMusic
    {
        public int sr { get; set; }
        public int bitrate { get; set; }
        public int playTime { get; set; }
        public long dfsId { get; set; }
        public double volumeDelta { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public int size { get; set; }
        public string extension { get; set; }
    }
    public class MMusic
    {
        public int sr { get; set; }
        public int bitrate { get; set; }
        public int playTime { get; set; }
        public long dfsId { get; set; }
        public double volumeDelta { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public int size { get; set; }
        public string extension { get; set; }
    }
    public class LMusic
    {
        public int sr { get; set; }
        public int bitrate { get; set; }
        public int playTime { get; set; }
        public long dfsId { get; set; }
        public double volumeDelta { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public int size { get; set; }
        public string extension { get; set; }
    }
    public class BMusic
    {
        public int sr { get; set; }
        public int bitrate { get; set; }
        public int playTime { get; set; }
        public long dfsId { get; set; }
        public double volumeDelta { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public int size { get; set; }
        public string extension { get; set; }
    }
    public class Song
    {
        public bool starred { get; set; }
        public int popularity { get; set; }
        public int starredNum { get; set; }
        public int playedNum { get; set; }
        public int dayPlays { get; set; }
        public int hearTime { get; set; }
        public string mp3Url { get; set; }
        public IList<object> rtUrls { get; set; }
        public int status { get; set; }
        public object audition { get; set; }
        public string ringtone { get; set; }
        public string disc { get; set; }
        public int no { get; set; }
        public IList<Artist> artists { get; set; }
        public IList<object> alias { get; set; }
        public int copyrightId { get; set; }
        public Album album { get; set; }
        public int score { get; set; }
        public HMusic hMusic { get; set; }
        public MMusic mMusic { get; set; }
        public LMusic lMusic { get; set; }
        public int mvid { get; set; }
        public int fee { get; set; }
        public int ftype { get; set; }
        public int rtype { get; set; }
        public object rurl { get; set; }
        public string commentThreadId { get; set; }
        public string copyFrom { get; set; }
        public int position { get; set; }
        public object rtUrl { get; set; }
        public int duration { get; set; }
        public object crbt { get; set; }
        public BMusic bMusic { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }
    public class Equalizers
    {
    }
    public class Music163
    {
        public IList<Song> songs { get; set; }
        public Equalizers equalizers { get; set; }
        public int code { get; set; }
    }


    public class Comment163
    {
        public int duration { get; set; }
        public int filesize { get; set; }
        public int musicId { get; set; }
        public string filemd5 { get; set; }
        public int version { get; set; }
        public IList<string> parts { get; set; }
        public int bitrate { get; set; }
        public string md5 { get; set; }
    }
}
