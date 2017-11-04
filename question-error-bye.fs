\ galope/question-error-bye.fs
\ `?error-bye`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Authors:
\   Anton Ertl, 2015.
\   Marcos Cruz (programandala.net), 2015, 2017.

\ ==============================================================

require ./typecr.fs

: ?error-bye ( f ca len -- )
  rot if
    ['] typecr stderr outfile-execute 1 (bye)
  then 2drop ;

  \ doc{
  \
  \ ?error-bye ( f ca len -- )
  \
  \ If _f_ is zero remove _f ca len_ from the stack.
  \
  \ If _f_ is non-zero send the character string _ca len_ to the
  \ standard error output, followed by a carriage return, and then
  \ exit the Forth system, returning error code 1 to the host system.
  \
  \ See: `typecr`.
  \
  \ }doc

\ ==============================================================
\ Usage example

\ ----
\ : ?size  ( f -- )
\   s" Wrong size for the card type." ?error-bye  ;
\ ----

\ ==============================================================
\ Change log

\ 2015-12-17: Add to the library, after code by Anton Ertl:
\ http://lists.gnu.org/archive/html/gforth/2015-12/msg00004.html
\ http://www.mail-archive.com/gforth@gnu.org/msg00540.html
\
\ 2016-07-04: Fix typo.
\
\ 2016-07-11: Update source layout and file header.
\
\ 2017-11-04: Improve documentation.
