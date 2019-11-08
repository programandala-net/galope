\ galope/png.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2008, 2014, 2017,
\ 2019.

\ ==============================================================

require ./package.fs
require ./buffer-colon.fs

package galope-png

: @le ( ca -- n )
  dup c@ [ 0xff 0xff 0xff * * ] literal *
  over 1+ c@ [ 0xff 0xff * ] literal * +
  over 2 + c@ 0xff * +
  swap 3 + c@ + ;
  \ Fetch a little-endian 32-bit value.

25 constant /png-buffer
  \ Size of the PNG buffer, enough to hold the first PNG chunk.

/png-buffer buffer: png-buffer

: png? ( -- f )
  png-buffer 8 s\" \x89\x50\x4E\x47\x0D\x0A\x1A\x0A" str= ;
  \ Is the current file a PNG?
  \ The first 8 bytes of the buffer must be:
  \ 0x89 0x50 0x4E 0x47 0x0D 0x0A 0x1A 0x0A.

variable png-fid

: png-load ( fid -- )
  png-buffer /png-buffer  2dup erase
  rot read-file throw drop
  png? 0= abort" Not a PNG image file." ;
  \ Fill the buffer with the beginning of the PNG image file,
  \ to make it the current one.

public

: png-open ( ca len -- )
  r/o bin open-file throw dup png-fid ! png-load ;

  \ doc{
  \
  \ png-open ( ca len -- )
  \
  \ Open a PNG image file _ca len_ to be used by `png-size`.
  \
  \ See: `png-close`, `jpeg-open`.
  \
  \ }doc

: png-close ( -- )
  png-fid @ close-file throw ;

  \ doc{
  \
  \ png-close ( -- )
  \
  \ Close the current PNG file, which was opened by `png-open`.
  \
  \ See: `png-size`, `jpeg-open`.
  \
  \ }doc

: png-size ( -- width height )
  \ Return the size of the current PNG file.
  png-buffer 16 + dup @le swap 4 + @le ;

  \ doc{
  \
  \ png-size ( -- width height )
  \
  \ Return the size _width height_ of the current PNG file, which was
  \ opened by `png-open`.
  \
  \ See: `jpeg-size`.
  \
  \ }doc

end-package

\ ==============================================================
\ Reference

0 [if]

89 50 4E 47 0D 0A 1A 0A \ main identifier: ".PNG...."
00 00 00 0D \ first chunk size
49 48 44 52 \ name of the firstchunk: "IHDR"
00 00 00 00 \ width, little endian
00 00 00 00 \ height, little endian
00 \ bits per pixel

[then]

\ ==============================================================
\ Debug

0 [if] \ test code

: png-test ( c-addr u -- )

  2dup cr type cr
  png-open
  png-xy swap
  ." x=" . ."  y=" .
  close-file abort" Closing PNG error"

  ;

s" c:\tmp\UniEncWhiteBord.png" sconstant img1

s" c:\tmp\copyleft_16.png" sconstant img2

img1 png-test
img2 png-test

[then]

\ ==============================================================
\ Change log

\ 2013-02-28: Code copied from a previous unfinished tool by the
\ same author (<http://programandala.net/en.program.fpng.html>),
\ written in 2008.  Changes: 'base' removed; 'bounds' used;
\ 'default-of' used; 'throw' instead of several 'abort"'; one
\ value converted to a local; new names; updated stack notations
\ and code layout.
\
\ 2017-08-17: Update change log layout. Update header. Update
\ section rulers.
\
\ 2017-08-18: Add missing `;module`.
\
\ 2017-08-18: Use `package` instead of `module:`.
\
\ 2017-10-25: Reorganize public and private words of the
\ package: Now only `png-open`, `png-size` and `png-close` are
\ public.  Improve code layout and documentation.
\
\ 2019-11-09: Convert `not-png?` to `png?` and make its PNG file
\ type check independent from the cell size of the system (32 or
\ 64 bits).
