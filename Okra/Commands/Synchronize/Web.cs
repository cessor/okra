using System;
using System.IO;
using System.Net;

namespace Okra.Commands.Synchronize
{
    internal class Web : IGet
    {
        #region IGet Members

        public string Get(string url)
        {
            var uri = new Uri(url);
            WebRequest request = WebRequest.Create(uri);
            using (WebResponse response = request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (var reader = new StreamReader(responseStream))
            {
                return reader.ReadToEnd();
            }
        }

        #endregion

        //  TODO: Make this more robust. It keeps failing for empty values of invalid urls - JH, 20.12.2012
    }
}