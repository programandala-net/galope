\ galope/time-and-date-to-iso.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017, 2018.

\ ==============================================================

require ./iso-8601.fs
require ./date-to-iso.fs
require ./time-to-iso.fs

: time&date>iso  ( +n1 +n2 +n3 +n4 +n5 n6 -- ca len )
  date>iso iso-8601-t$ s+ 2>r time>iso 2r> 2swap s+ ;

  \ doc{
  \
  \ time&date>iso  ( +n1 +n2 +n3 +n4 +n5 n6 -- ca len )
  \
  \ Convert second _+n1_, minute _+n2_, hour _+n3_, day _+n4_, month
  \ _+n5_ and year _n6_ into ISO date _ca len_.
  \
  \ The format can be configured by `extended-iso-8601` and
  \ `iso-8601-t`.
  \
  \ See: `extended-iso-8601`, `time>iso`, `date>iso`,
  \ `>yyyymmddhhmmss`, `iso-date>extended`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2014-07-13: Written. Inspired by code from fhp ("Forth HTML
\ Preprocessor") version B-00-201206, in file <fhp-date.fs>
\ (http://programandala.net/es.programa.fhp.html).
\
\ 2014-11-02: Change: stack notation, comment.
\
\ 2017-08-17: Update change log layout. Update header.
\
\ 2017-11-13: Rename secondary words after notation ">iso". Split the
\ module: Move `time>d` `date>iso` and `time>iso` to their own
\ modules. Improve documentation.
\
\ 2018-07-22: Improve documentation.
