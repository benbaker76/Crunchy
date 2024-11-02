using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crunchy
{
    public interface IFileSource
    {
        string Name { get; }
        Stream OpenReadStream(long maxAllowedSize = 512000);
        string ContentType { get; }
    }
}
