\ galope/ruler.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

: ruler ( c len -- ca len )
  dup allocate throw swap 2dup 2>r rot fill 2r> ;

  \ doc{
  \
  \ ruler ( c len -- ca len )
  \
  \ Create a string _ca len_, in data space allocated by ``allocate``,
  \ out of character _c_.
  \
  \ See: `emits`, `s+`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2014-02-19: Written.
\
\ 2015-10-15: Renamed filename.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
\
\ 2017-08-19: Rename from `c>rule` to `ruler`, which is a better name,
\ and already used in Solo Forth
\ (http://programandala.net/en.program.solo_forth.html).  Document.
