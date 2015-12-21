\ galope/question-error-bye.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ History
\ 2015-12-17: Added to the library, after code by Anton Ertl:
\ http://lists.gnu.org/archive/html/gforth/2015-12/msg00004.html
\ http://www.mail-archive.com/gforth@gnu.org/msg00540.html

require ./typecr.fs

: ?error-bye ( f ca len -- )
  rot if
    ['] typecr stderr outfile-execute 1 (bye)
  then  2drop  ;

\ Usage example:
\
\ ----
\ : ?size  ( f -- )
\   s" Wrong size for the card type." ?error-exit  ;
\ ----
