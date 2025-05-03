using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern.ImageLoadStrategy
{
    public class NetworkImageLoadStrategy : IImageLoadStrategy
    {
        public bool CanHandle(string source)
        {
            return Uri.TryCreate(source, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        public string LoadImage(string source)
        {
            if (!Validate(source))
            {
                throw new Exception($"Cannot access image from URL: {source}");
            }

            return source;
        }

        public bool Validate(string source)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Head, source);
                    var response = client.Send(request);
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}