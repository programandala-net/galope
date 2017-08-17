\ galope/unslurp-file.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2014, 2017.

\ ==============================================================

: unslurp-file  ( ca1 len1 ca2 len2 -- )
  w/o create-file throw dup >r write-file throw
                            r> close-file throw ;

  \ doc{
  \
  \ unslurp-file  ( ca1 len1 ca2 len2 -- )
  \
  \ Write the string _c1 len1_ to the file named in the string _ca2
  \ len2_.  If a file with the same name already exists, overwrite it.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-11-28: First version, 'unslurp', after Gforth's 'slurp-file'.
\ 2014-02-21: Renamed to 'unslurp-file'.
\ 2017-07-14: Update layout. Improve documentation.
