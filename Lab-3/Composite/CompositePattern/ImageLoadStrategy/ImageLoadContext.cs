using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern.ImageLoadStrategy
{
    public class ImageLoadContext
    {
        private readonly List<IImageLoadStrategy> _strategies;

        public ImageLoadContext()
        {
            _strategies = new List<IImageLoadStrategy>
            {
                new FileImageLoadStrategy(),
                new NetworkImageLoadStrategy()
            };
        }

        public string LoadImage(string source)
        {
            foreach (var strategy in _strategies)
            {
                if (strategy.CanHandle(source))
                {
                    return strategy.LoadImage(source);
                }
            }

            throw new NotSupportedException($"No strategy can handle this source: {source}");
        }

        public bool CanLoadImage(string source)
        {
            return _strategies.Any(s => s.CanHandle(source));
        }
    }
}
