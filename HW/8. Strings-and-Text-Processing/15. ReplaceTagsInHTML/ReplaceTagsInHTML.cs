using System;
using System.Text;

class ReplaceTagsInHTML
{
    static void Main()
    {
        string text = "<p>Please visit <a href=\"http://academy.telerik.com\"> our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\"> our forum</a> to discuss the courses.</p>";
        StringBuilder newText = new StringBuilder();
        newText.Append(text);
        newText.Replace("<a href=\"", "[URL=");
        newText.Replace("\">", "]");
        newText.Replace("</a>", "/URL]");
        Console.WriteLine(newText);
    }
}