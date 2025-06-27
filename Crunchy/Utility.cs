using Baker76.Pngcs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crunchy
{
    internal class Utility
    {
        public static Size ResizeImage(Size oldSize, Size newSize)
        {
            if (oldSize.Width >= oldSize.Height)
            {
                if (oldSize.Width > newSize.Width)
                    return new Size(newSize.Width, (int)((float)oldSize.Height * ((float)newSize.Width / (float)oldSize.Width)));
                else if (oldSize.Height > newSize.Height)
                    return new Size((int)((float)oldSize.Width * ((float)newSize.Height / (float)oldSize.Height)), newSize.Height);
            }
            else
            {
                if (oldSize.Height > newSize.Height)
                    return new Size((int)((float)oldSize.Width * ((float)newSize.Height / (float)oldSize.Height)), newSize.Height);
                else if (oldSize.Width > newSize.Width)
                    return new Size(newSize.Width, (int)((float)oldSize.Height * ((float)newSize.Width / (float)oldSize.Width)));
            }

            return oldSize;
        }

        public static Size GetNearestPower2Size(Size source, Size max)
        {
            Size ret = new Size(1, 1);

            while (ret.Width < source.Width)
                ret.Width <<= 1;
            while (ret.Height < source.Height)
                ret.Height <<= 1;

            if (ret.Width > max.Width)
                ret.Width = max.Width;
            if (ret.Height > max.Height)
                ret.Height = max.Height;

            return ret;
        }

        public static bool IsPowerOfTwo(int x)
        {
            return (x & (x - 1)) == 0;
        }
    }
}
