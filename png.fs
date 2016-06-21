\ galope/png.fs

\ This file is part of Galope

\ Copyright (C) 2008,2014 Marcos Cruz (programandala.net)

\ --------------------------------------------------------------
\ History

\ 2013-02-28: Code copied from a previous unfinished tool by the same
\ author (<http://programandala.net/en.program.fpng.html>), written in
\ 2008.  Changes: 'base' removed; 'bounds' used; 'default-of' used;
\ 'throw' instead of several 'abort"'; one value converted to a local;
\ new names; updated stack notations and code layout.

\ --------------------------------------------------------------

0 [if]

89 50 4E 47 0D 0A 1A 0A \ main identifier: ".PNG...."
00 00 00 0D \ first chunk size
49 48 44 52 \ name of the firstchunk: "IHDR"
00 00 00 00 \ width, little endian
00 00 00 00 \ height, little endian
00 \ bits per pixel

[then]


\ ---------------------------------------------

require ./module.fs
require ./buffer-colon.fs

module: galope-png-module

: @le  ( ca -- n )
  \ Fetch a little-endian 32-bit value.
  dup c@ [ 0xff 0xff 0xff * * ] literal *
  over 1+ c@ [ 0xff 0xff * ] literal * +
  over 2 + c@ 0xff * +
  swap 3 + c@ +
  ;

export

25 constant /png-buffer  \ enough to hold the first PNG chunk
/png-buffer buffer: png-buffer

: not-png?  ( -- f )
  \ Is the current file not a PNG?
  \ The first bytes in the buffer must be:
  \ 89 50 4E 47 0D 0A 1A 0A
  png-buffer @ 0x474e5089 <>
  png-buffer cell+ @ 0x0a1a0a0d <>  or
  ;
: png-load  ( fid -- )
  \ Fill the buffer with the beginning of the PNG image file,
  \ to make it the current one.
  png-buffer /png-buffer  2dup erase
  rot read-file throw drop
  not-png? abort" Not a PNG image file."
  ;
variable png-fid
: png-open  ( ca len -- )
  \ Open a PNG image file and make it the current one.
  r/o bin open-file throw  dup png-fid !  png-load
  ;
: png-close  ( -- )
  \ Close the current PNG image.
  png-fid @ close-file throw
  ;
: png-size  ( -- width height )
  \ Return the size of the current PNG file.
  png-buffer 16 + dup @le  swap 4 + @le
  ;

\ ---------------------------------------------
\ Debug

0 [if] \ test code

: png-test  ( c-addr u -- )

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

