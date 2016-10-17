using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using JSONProcessingTAFedd.Models;
using System;

namespace JSONProcessingTAFedd
{
    public class Startup
    {
        private static void Main()
        {
            const string taRssUrl = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
            const string taRssAsXmlPath = "../../Files/ta-youtube-rss.xml";
            const string taRssAsJsonPath = "../../Files/ta-youtube-rss.json";

            DownloadFile(taRssUrl, taRssAsXmlPath);
            ParseXmlToJson(taRssAsXmlPath, taRssAsJsonPath);

            var rssJson = File.ReadAllText(taRssAsJsonPath);

            var videosTitles = GetVideosTitles(rssJson);
            Console.WriteLine(string.Join(", ", videosTitles));

            var videos = ParseVideosJsonToPOCO(rssJson);
            var html = GetHTMLContent(videos);
            File.WriteAllText("../../Files/index.html", html);
        }

        private static string GetHTMLContent(IEnumerable<Video> videos)
        {
            var html = @"<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset = ""UTF-8""> 
     <title>Telerik Academy Youtube Videos</title>
    </head>
    <body>    
        <div class=""videos"">";

            var builder = new StringBuilder();
            foreach (var video in videos)
            {
                var videoHtml = @"<div class=""video"">";
                videoHtml += $@"<h4><a href=""{video.Link.Href}"" rel=""{video.Link.Rel}"">{video.Title}</a></h4>";
                videoHtml += $@"<iframe src=""http://www.youtube.com/embed/{video.Id}"" width=""400"" height=""300"">";
                videoHtml += "<p>Your browser does not support iframes.</p>";
                videoHtml += "</iframe>";
                videoHtml += "</div>";

                builder.AppendLine(videoHtml);
            }

            html += builder.ToString();
            html += @"</div>
</body>
</html>";

            return html;
        }

        private static IEnumerable<Video> ParseVideosJsonToPOCO(string json)
        {
            var jsonObject = JObject.Parse(json);
            var feed = jsonObject["feed"];
            var videos = feed["entry"]
                .Select(v => JsonConvert.DeserializeObject<Video>(v.ToString()));

            return videos;
        }

        private static IEnumerable<string> GetVideosTitles(string json)
        {
            var jsonObject = JObject.Parse(json);
            var feed = jsonObject["feed"];
            var videos = feed["entry"]
                .Select(v => v["title"].ToString());

            return videos;
        }

        private static void ParseXmlToJson(string xmlPath, string jsonPath)
        {
            var document = XDocument.Load(xmlPath);
            string jsonFromXml = JsonConvert.SerializeXNode(document, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(jsonPath, jsonFromXml);
        }

        private static void DownloadFile(string url, string filePath)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(url, filePath);
            }
        }
    }
}
