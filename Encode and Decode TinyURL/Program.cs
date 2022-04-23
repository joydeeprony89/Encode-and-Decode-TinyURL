using System;
using System.Collections.Generic;

namespace Encode_and_Decode_TinyURL
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
    // Base url
    public const string TINY_BASE_URL = "https://tinyurl.com/";
    // container to check if we have received the same long url before, return the same shorturl agaist the long url.
    Dictionary<string, string> originalUrlMapping = new Dictionary<string, string>();
    // container for tinyurl and original url
    Dictionary<string, string> tinyUrlMapping = new Dictionary<string, string>();

    public string Encode(string longUrl)
    {
      // always first check the longurl we have, we have already generated a short url for it, if yes return the existing value.
      if (originalUrlMapping.ContainsKey(longUrl))
      {
        return originalUrlMapping[longUrl];
      }
      // create a new guid.
      string guid = Guid.NewGuid().ToString();
      // create the new key using the baseurl + newGuid
      string key = TINY_BASE_URL + guid;
      // if the generated key already is used
      if (tinyUrlMapping.ContainsKey(key))
      {
        // re generate the key
        guid = Guid.NewGuid().ToString();
        key = TINY_BASE_URL + guid;
      }
      // add into mapping table bw new short url and original url.
      tinyUrlMapping.Add(key, longUrl);
      // add the original url and short url mapping , here key is longUrl, why ? to find an existing lonhurl if we have received any before in O(1) time.
      originalUrlMapping.Add(longUrl, key);
      return key;
    }

    public string Decode(string shortUrl)
    {
      if (!tinyUrlMapping.ContainsKey(shortUrl)) return "";
      return tinyUrlMapping[shortUrl];
    }
  }
}
