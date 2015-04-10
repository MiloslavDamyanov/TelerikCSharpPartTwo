using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ParseURL
{
    static void Main()
    {
        string url = "http://www.devbg.org/forum/index.php";
        StringBuilder parseUrl = new StringBuilder();
        string protocol = string.Empty;
        string server = string.Empty;
        string resource = string.Empty;

        // parse protocol
        for (int i = 0; i < url.IndexOf("://"); i++)
        {
            parseUrl.Append(url[i]);
        }

        protocol = parseUrl.ToString();
        parseUrl.Clear();

        // parse server
        for (int i = url.IndexOf("www"); i < url.Length; i++)
        {
            parseUrl.Append(url[i]);
            if (url[i] == '/')
            {
                server = parseUrl.ToString().TrimEnd('/', '\0');
                parseUrl.Clear();
                break;
            }
        }

        // parse resources
        for (int i = url.IndexOf("www"); i < url.Length; i++)
        {
            if (url[i] == '/')
            {
                for (int j = i; j < url.Length; j++)
                {
                    parseUrl.Append(url[j]);
                }
            }
        }

        resource = parseUrl.ToString();
        
        Console.WriteLine("[protocol] = \"{0}\"\n[server] = \"{1}\"\n[resources] = \"{2}\"", protocol, server, resource);        
    }
}
