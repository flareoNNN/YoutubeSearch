using System;
using System.Collections.Generic;
using RestSharp;

namespace YoutubeSearch
{
    public class VideoSearch
    {
        List<VideoInformation> items;
        string satir;
        string title;
        string author;
        int viewcount;
        int duration;
        string url;
        string thumbnail;

        public List<VideoInformation> Search(string query)
        {
            items = new List<VideoInformation>();

            var client = new RestClient($"https://www.youtube.com/results?search_query={query}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            satir = response.Content;

            for (int i = 1; i < 11; i++)
            {
                title = IsimDuzelt(GetBetween(satir, "\"title\":{\"runs\":[{\"text\":\"", "\"}]", i));
                url = $"https://www.youtube.com/watch?v={IsimDuzelt(GetBetween(satir, "{\"videoRenderer\":{\"videoId\":\"", "\"", i))}";
                viewcount = Convert.ToInt32(IsimDuzelt(GetBetween(satir, "\"viewCountText\":{\"simpleText\":\"", " ", i)).Replace(".", ""));
                author = IsimDuzelt(GetBetween(satir, "\"longBylineText\":{\"runs\":[{\"text\":\"", "\"", i));
                thumbnail = $"https://i.ytimg.com/vi/{IsimDuzelt(GetBetween(satir, "{\"videoRenderer\":{\"videoId\":\"", "\"", i))}/maxresdefault.jpg";

                string first = IsimDuzelt(GetBetween(satir, "\"lengthText\":{", "\"},\"", i)) + "\"";
                string second = IsimDuzelt(GetBetween(first, "\"simpleText\":\"", "\"", 1));
                duration = TimeTransform(second);

                items.Add(new VideoInformation() { Title = title, Author = author, ViewCount = viewcount, Duration = duration, Url = url, Thumbnail = thumbnail, });
            }

            return items;
        }

        private string GetBetween(string source, string start, string end, int nth)
        {
            var startPos = IndexOfOccurence(source, start, nth);
            if (startPos < 0) return null;
            startPos += start.Length;
            var endPos = source.IndexOf(end, startPos, StringComparison.Ordinal);
            return endPos < 0 ? null : source.Substring(startPos, endPos - startPos);
        }

        private int IndexOfOccurence(string s, string match, int occurence)
        {
            int i = 1;
            int index = 0;

            while (i <= occurence && (index = s.IndexOf(match, index + 1)) != -1)
            {
                if (i == occurence)
                    return index;

                i++;
            }

            return -1;
        }

        private string IsimDuzelt(string str)
        {
            try
            {
                str = str.Replace("&amp;", "&")
                        .Replace("&quot;", "\"")
                        .Replace("\\\"", "\"")
                        .Replace("&#39;", "'")
                        .Replace("\\u0026", "&")
                        .Replace("\\/", "/")
                        .Replace("\\r", "")
                        .Replace("\\\\\\", "")
                        .Replace("\\n", Environment.NewLine);
                return str;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private int TimeTransform(string str)
        {
            int sure = 0;

            if (strcount(str, ':') == 1)
            {
                var sayilar = str.Split(':');
                sure += Convert.ToInt32(sayilar[0]) * 60;
                sure += Convert.ToInt32(sayilar[1]);
            }
            else if (strcount(str, ':') == 2)
            {
                var sayilar = str.Split(':');
                sure += Convert.ToInt32(sayilar[0]) * 3600;
                sure += Convert.ToInt32(sayilar[1]) * 60;
                sure += Convert.ToInt32(sayilar[2]);
            }

            return sure;
        }

        private int strcount(string str, char delimeter)
        {
            int deger = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == delimeter)
                {
                    deger++;
                }
            }
            return deger;
        }
    }
}