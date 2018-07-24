\ galope/ud-to-str.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2015, 2017, 2018.

\ ==============================================================

: ud>str ( ud -- ca len ) <# #s #> ;

  \ doc{
  \
  \ ud>str ( ud -- ca len )
  \
  \ Convert _ud_ to string _ca len_.
  \
  \ See: `d>str`, `n>str`, `c>str`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2015-10-14: First version.
\
\ 2015-10-22: Renamed file.
\
\ 2017-08-17: Update change log layout and source style.
\
\ 2018-07-24: Improve documentation.
