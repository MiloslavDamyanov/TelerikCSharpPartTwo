using System;
using System.ComponentModel;
using System.Net;

class WrongLinkException : ArgumentException
{
}

class Downloader
{
    static void DownloadFile(string url)
    {
        string saveTo = "../../Logo-BASD.jpg";
        using (WebClient client = new WebClient())
        {
            client.DownloadFile(url, saveTo);
        }
    }

    static string CheckLink(string url)
    {
        if (url.Contains("http://www."))
        {
            return "ok";
        }
        else
        {
            return "err";
        }
    }

    static void Main()
    {
        Console.Write("Enter url to download image: ");
        string url = Console.ReadLine();
        try
        {
            if (CheckLink(url) == "ok")
            {
                DownloadFile(url);
                Console.WriteLine("Download complete! ");
            }
            else
            {
                throw new WrongLinkException();
            }
        }        
        catch (WrongLinkException)
        {
            Console.WriteLine("invalid URL");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("invalid URL");
        }
        catch (WebException)
        {
            Console.WriteLine("Check your internet connection");
        }
    }
}

// TESTS
//                                                 
// if link does not start with http://www. or contoins spaces => invalid URL
// if you don't have internet connection   => Check your internet connection
// http://www.devbg.org/img/Logo-BASD.jpg