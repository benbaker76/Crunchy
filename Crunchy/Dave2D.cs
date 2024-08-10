using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crunchy
{
    public class Dave2D
    {
        [Flags]
        public enum D2Format : ushort
        {
            Alpha8 = 0,
            Rgb565 = 1,
            Argb8888 = 2,
            Argb4444 = 3,
            Argb1555 = 4,
            Ai44 = 5,
            Rgba8888 = 6,
            Rgba4444 = 7,
            Rgba5551 = 8,
            I8 = 9,
            I4 = 10,
            I2 = 11,
            I1 = 12,
            Alpha4 = 13,
            Alpha2 = 14,
            Alpha1 = 15,
            // following additional flags can be ored together with previous modes:
            Rle = 16,    // RLE decoder is used
            Clut = 32    // CLUT 256 is used
        };

        public static D2Format BitsToD2Format(int bitsPerPixel)
        {
            switch (bitsPerPixel)
            {
                case 1:
                    return D2Format.I1;
                case 2:
                    return D2Format.I2;
                case 4:
                    return D2Format.I4;
                case 8:
                    return D2Format.I8;
                case 16:
                    return D2Format.Rgb565;
                case 32:
                    return D2Format.Argb8888;
            }

            return D2Format.Argb8888;
        }
    }
}
