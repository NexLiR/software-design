using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern.ImageLoadStrategy
{
    public class FileImageLoadStrategy : IImageLoadStrategy
    {
        public bool CanHandle(string source)
        {
            return File.Exists(source) || Path.IsPathRooted(source);
        }

        public string LoadImage(string source)
        {
            if (!Validate(source))
            {
                throw new FileNotFoundException($"Image file does not exist: {source}");
            }

            return Path.GetFullPath(source);
        }

        public bool Validate(string source)
        {
            return File.Exists(source);
        }
    }
}
