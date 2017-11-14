\ galope/default-of.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Mark Willis, 2014.
\ Adapted by: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

: default-of \ Compilation: ( -- )
             \ Run-time:    ( x -- )
  postpone dup postpone of ; immediate compile-only

  \ doc{
  \
  \ default-of \ Compilation: ( -- )
  \            \ Run-time:    ( x -- )
  \
  \ An explicit default for ``case``.
  \
  \ Usage example:
  \
  \ ----

  \ : test ( x -- )
  \   case
  \     10      of ." ten!"  endof
  \     20      of ." ten!"  endof
  \     default-of ." other" endof
  \   endcase ;

  \ ----
  \
  \ See: `less-of`, `greater-of`, `between-of`, `within-of`, `or-of`,
  \ `any-of`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2014-02-04 Written, based on code by Mark Willis posted to
\ <lang.comp.forth>: Message-ID:
\ <64b90787-344c-4ee0-a0e4-4e2c12b3dec3@googlegroups.com>; Date: Fri,
\ 24 Jan 2014 02:08:22 -0800 (PST).
\
\ 2017-08-17: Update change log layout, header, source style; fix
\ stack comment.
\
\ 2017-10-24: Improve documentation.
\
\ 2017-11-14: Update documentation.
