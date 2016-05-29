// Write a program that replaces in a HTML document given as string all the tags <a href="URL">TEXT</a> with corresponding markdown notation [TEXT](URL).

//using System;
//using System.Text;
//using System.Text.RegularExpressions;

//class ReplaceTags
//{
//    private static Regex regex;

//    private static string ExtractUrl(string anchor)
//    {
//        string pattern = "href[ ]*=[ ]*\"([^ \"]*)\"";
//        regex = new Regex(pattern);
//        Match match = regex.Match(anchor);
//        string url = match.Value;
//        return url;
//    }

//    private static string ExtractContent(string htmlElement)
//    {
//        int contentStartIndex = htmlElement.IndexOf(">") + 1;
//        int contentEndIndex = htmlElement.IndexOf("</a>");
//        string content = htmlElement.Substring(contentStartIndex, contentEndIndex - contentStartIndex);
//        return content;
//    }

//    static void Main()
//    {
//        const string OpenAnchorTag = "<a";
//        const string CloseAnchorTag = "</a>";

//        string html = Console.ReadLine();

//        StringBuilder builder = new StringBuilder(html);
//        int anchorStartIndex = html.IndexOf(OpenAnchorTag);
//        while (anchorStartIndex > -1)
//        {
//            int anchorEndIndex = html.IndexOf(CloseAnchorTag, anchorStartIndex + 1);
//            string anchor = html.Substring(anchorStartIndex, anchorEndIndex + CloseAnchorTag.Length - anchorStartIndex);

//            string url = ExtractUrl(anchor);
//            string content = ExtractContent(anchor);
//            string replacement = "[" + content + "]" + "(" + url + ")";
//            builder.Replace(anchor, replacement);

//            anchorStartIndex = html.IndexOf(OpenAnchorTag, anchorEndIndex);
//        }

//        Console.WriteLine(builder.ToString());
//    }
//}


using System;
using System.Text;

class ReplaceTags
{
    private const string Href = "href=\"";
    private const string AnchorCloseTag = "</a>";

    // <p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>
    // <p>Please visit [our site](http://academy.telerik.com) to choose a training course. Also visit [our forum](www.devbg.org) to discuss the courses.</p>
    private static string ParseTags(string html)
    {
        int linkStartIndex = 0;
        bool inAnchor = false;
        bool inLink = false;
        StringBuilder markDown = new StringBuilder();
        StringBuilder link = new StringBuilder();
        for (int i = 0; i < html.Length; i++)
        {
            if (inAnchor)
            {
                if (inLink)
                {
                    if (html[i] != '"')
                    {
                        link.Append(html[i]);
                    }
                    else
                    {
                        link.Append(")");
                        inLink = false;
                        i = html.IndexOf('>', i);
                        markDown.Append('[');
                    }
                }

                // In content
                else
                {
                    if (html[i] == '<' && html[i + 1] == '/' && html[i + 2] == 'a')
                    {
                        markDown.Append(']' + link.ToString());
                        inAnchor = false;
                        i += AnchorCloseTag.Length - 1;

                        // Ready for a new link.
                        link.Clear();
                    }
                    else
                    {
                        markDown.Append(html[i]);
                    }
                }
            }
            else if (html[i] == '<' && html[i + 1] == 'a')
            {
                inAnchor = true;
                inLink = true;
                linkStartIndex = html.IndexOf(Href, i) + Href.Length - 1;
                i = linkStartIndex;
                link.Append('(');
            }
            else
            {
                markDown.Append(html[i]);
            }

        }

        return markDown.ToString();
    }

    static void Main()
    {
        string html = Console.ReadLine();

        string markDown = ParseTags(html);
        Console.WriteLine(markDown);
    }
}
