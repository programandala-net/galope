\ galope/jpeg.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2006, 2007, 2009,
\ 2013, 2014, 2017.

\ ==============================================================

require ./package.fs
require ./buffer-colon.fs
require ./default-of.fs

package galope-jpeg

: 16@ ( ca -- n )
  dup c@ 256 * swap 1+ c@ + ;
  \ Fetch a little-endian 16-bit value.

public

65536 constant /jpeg-buffer \ enough to hold any JPEG header
  \ XXX TODO -- use a growing header buffer

/jpeg-buffer buffer: jpeg-buffer

: jpeg-load ( fid -- )
  jpeg-buffer /jpeg-buffer 2dup erase rot read-file throw
  drop jpeg-buffer @ 0xffff and 0xd8ff <> abort" Not a JPEG image file." ;
  \ Fill the buffer with the beginning of the a JPEG image
  \ file.  This make the image the current one all other words
  \ work with.

variable jpeg-fid

: jpeg-open ( ca len -- )
  r/o bin open-file throw dup jpeg-fid ! jpeg-load ;
  \ Open a JPEG image file and make it the current one.

: jpeg-close ( -- )
  jpeg-fid @ close-file throw ;
  \ Close the current JPEG image.

: jpeg-data ( ca1 -- ca2 len2 )
  dup 4 + swap 2 + 16@ 2 - ;
  \ ca1 = address of a JPEG marker
  \ ca2 len2 = data region of the JPEG header

: jpeg-marker+ ( ca -- +n )
  2 + 16@ 2 + ;
  \ ca = address of a JPEG marker
  \ +n = byte offset from ca to the next JPEG marker

: jpeg-data. ( ca len -- )
  cr ." [d]ump? [a]bort? Any other key to continue." cr
  key case
    'd' of
        cr dump
        ." [a]bort? Any other key to continue." cr
        key 'a' = if abort then
      endof
    'a' of abort endof
    default-of 2drop endof
  endcase ;
  \ XXX TODO -- rewrite
  \ Dump the data of a JPEG header.

: jpeg-header. ( ca -- +n )
  dup jpeg-data 2dup
  ." , " . ." bytes from " . ." :"
  jpeg-data. jpeg-marker+ ;
  \ Show a JPEG header.
  \ ca = address of a JPEG marker
  \ +n = byte offset from ca to the next marker

: jpeg-size@ ( ca -- width height )
  7 + dup 16@ swap 2 - 16@ ;
   \ ca = address of the proper JPEG marker

: jpeg-size. ( ca -- )
  jpeg-size@ swap ."  width=" . ." height=" . ;
  \ Show the JPEG image size.
  \ ca = address of the proper JPEG marker

: jpeg-header ( ca -- +n )
  dup 1+ c@ dup . ." marker: "
  case \ marker id
    0xc0 of ." frame" dup jpeg-size. jpeg-header. endof
    0xc1 of ." unknown (frame?)" dup jpeg-size. jpeg-header. endof \ xxx debug 2007-10-19
    0xc2 of ." unknown (frame?)" dup jpeg-size. jpeg-header. endof
    0xc3 of ." unknown (frame?)" dup jpeg-size. jpeg-header. endof \ xxx debug 2007-10-19
    0xc4 of ." define huffman table" jpeg-header. endof
    \ from 0xe0 to 0xef are reserved for applications:
    0xe0 of ." jfif" jpeg-header. endof
    0xe1 of ." exim" jpeg-header. endof
    0xd8 of ." start of image" drop 2 endof
    0xd9 of ." end of image" drop 0 endof
    0xda of ." start of scan" jpeg-header. endof
    0xdb of ." define quantization" jpeg-header. endof
    0xfe of ." comment" jpeg-header. endof
    default-of ." unknown" jpeg-header. endof
  endcase ;
  \ Identify and show a new JPEG header.
  \ ca = address of the JPEG marker
  \ +n = byte offset to the next marker, or 0 if the marker found was the end of image
  \
  \ XXX TODO -- better name

: jpeg-size ( -- width height )
  jpeg-buffer /jpeg-buffer bounds 2 + do
    i 16@ case
      0xffc0 of i jpeg-size@ leave endof
      0xffc2 of i jpeg-size@ leave endof
    endcase i jpeg-marker+
  +loop ;
  \ Size of the current JPEG file.

: jpeg-dump ( -- )
  jpeg-buffer /jpeg-buffer bounds do
    i dup cr . ." : " dup c@ dup .
    0xff = if jpeg-header else drop 1 then
    dup 0= abort" End of JPEG image in jpeg-dump."
  +loop ;
  \ Dump the content of the current JPEG image, header after
  \ header, until the buffer end.  Written to learn about the
  \ JPEG format and write the other words.

: jpeg-search {: byte -- :}
  jpeg-buffer /jpeg-buffer bounds do
    '.' emit
    i c@ byte = if
      cr byte . ."  found at " i .
      i 16 - 32 jpeg-data.
    then
  loop ;
  \ Search a byte in the current JPEG file.
  \ Written to find out where the image width and height are stored.

\ ==============================================================
\ Testing and debugging

false [if]

0 value jpeg-searched2 \ byte
defer jpeg-found2

: (jpeg-found2) ( ca -- )
  32 jpeg-data. ;
  \ Default action after a successful search of two bytes.

' (jpeg-found2) is jpeg-found2

: jpeg-search2 ( b1 b2 -- )
  to jpeg-searched2 to jpeg-searched cr
  /jpeg-buffer jpeg-buffer + jpeg-buffer
  do
    '.' emit
    i c@ jpeg-searched =
    i 1+ c@ jpeg-searched2 = and
    if jpeg-found2 then
  loop ;
  \ Search the current JPEG file for two bytes.

: jpeg-search-size ( -- )
  ' jpeg-size is jpeg-found2
  0xff 0xc0 jpeg-searched2
  ' (jpeg-found2) is jpeg-found2 ;
  \ Search and show any possible frame header in the current JPEG file.


: jpeg-test ( ca len -- )
  jpeg-open jpeg-dump jpeg-close ;
  \ Test an image

[then]

end-package

\ ==============================================================
\ Change log

\ 2014-02-24: Code copied from a previous tool by the same author
\ (<http://programandala.net/en.program.fjpg.html>). Changes: 'base'
\ removed; 'bounds' used; 'default-of' used; 'throw' instead of
\ several 'abort"'; one value converted to a local; new names; updated
\ stack notations and code layout.
\
\ 2014-02-28: Typo fixed in comment.
\
\ 2017-08-17: Update change log layout. Update header. Update
\ section rulers.
\
\ 2017-08-18: Use `package` instead of `module:`.
\
\ 2017-08-23: Update source style.
