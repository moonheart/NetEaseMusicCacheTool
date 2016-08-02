using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace NetEaseMusicCacheTool
{
    public class Music163HttpRequest
    {
        public static Song Request(int songId)
        {
            var url = string.Format("http://music.163.com/api/song/detail/?ids=[{0}]", songId);
            var request = (HttpWebRequest)WebRequest.Create(url);
            var cc = new CookieContainer();
            cc.Add(new Cookie("appver", "1.5.0.75771", "", "163.com"));
            request.CookieContainer = cc;
            request.Referer = "http://music.163.com/";

            var response = request.GetResponse();
            var rs = response.GetResponseStream();
            var sr = new StreamReader(rs);
            var res = sr.ReadToEnd();
            var m = JObject.Parse(res).ToObject<Music163>();
            return m.songs.FirstOrDefault();
        }


    }
}
