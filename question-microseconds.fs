\ galope/question-microseconds.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016, 2017.

\ ==============================================================

require ./package.fs

package galope-question-microseconds

: past? ( d -- f ) utime d< ;

public

: ?microseconds ( u -- )
  s>d utime d+
  begin 2dup past? key? 0= or until
  begin 2dup past? key?    or until
  2drop ;

  \ doc{
  \
  \ ?microseconds ( u -- )
  \
  \ Wait at least _u_ microseconds or until a key is pressed.
  \
  \ See: `?ms`, `?seconds`, `microseconds`.
  \
  \ }doc

end-package

\ ==============================================================
\ Change log

\ 2012-06-18: Taken from the Autohipnosis program
\ (http://programandala.net/es.programa.autohipnosis).
\
\ 2012-09-24: 'time?' renamed to 'overtime?'.
\
\ 2013-11-06: Changed the stack notation of flag.
\
\ 2014-11-17: Module name updated.
\
\ 2016-01-16: Updated header and layout.
\
\ 2017-08-17: Update change log layout. Update header.  Update stack
\ notation.
\
\ 2017-08-18: Use `package` instead of `module:`.
\
\ 2017-12-04: Rename `microseconds` `?microseconds`.
