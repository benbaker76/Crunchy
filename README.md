# Crunchy

This is a UI tool that will pack a list of images (png or bmp) or sprites (Aseprite format) into a single or series of larger image(s).

It exports an extended crch ([crunch](https://github.com/benbaker76/crunch)) format that was originally designed for [Celeste](http://www.celestegame.com/).

Some of the extensions added to the crch format include per-frame animation data from an Aseprite file.

![sample](/.github/img/screenshot0.png?raw=true)

## Features

- Export XML, JSON, binary, or Unity .meta data
- Trim excess transparency
- Control atlas size and padding
- Premultiply pixel values
- Add multiple folders
- Multi-image atlas when the sprites don't fit
- Support for indexed pngs'
- Support for using palette file for indexed format (act, JASC, MS pal, GIMP, Paint.net and png)
- Support for Aseprite format

## Palette Format

For indexed png's the supported palette formats supported are act, jasc, mspal, gimp, paint.net and png.

## Binary Format

```text
crch (0x68637263 in hex or 1751347811 in decimal (little endian))
[int16] version (current version is 0)
[byte] --trim enabled
[byte] --rotate enabled
[byte] string type (0: null-termainated, 1: prefixed (int16), 2: 7-bit prefixed, 3: fixed 16 bytes)
[int16] num_textures (below block is repeated this many times)
    [string] name
    [int16] tex_width
    [int16] tex_height
    [int16] tex_format
    [int16] num_images (below block is repeated this many times)
        [int16] img_frame_index
        [string] img_name
        [string] img_label
        [byte] img_loop_direction
        [int16] img_duration
        [int16] img_x
        [int16] img_y
        [int16] img_width
        [int16] img_height
        [int16] img_frame_x         (if --trim enabled)
        [int16] img_frame_y         (if --trim enabled)
        [int16] img_frame_width     (if --trim enabled)
        [int16] img_frame_height    (if --trim enabled)
        [byte] img_rotated          (if --rotate enabled)
        [byte] img_palette_slot
```

## Credits
* [Ben Baker](https://github.com/benbaker76) - Creator and maintainer of Crunchy
* [Chevy Ray Johnston](https://github.com/ChevyRay) - [crunch](https://github.com/ChevyRay/crunch)
* [Noel Berry](https://github.com/NoelFB) - [ugly C# .ase (aseprite) parser](https://gist.github.com/NoelFB/778d190e5d17f1b86ebf39325346fcc5)
