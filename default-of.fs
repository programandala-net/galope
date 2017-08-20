\ galope/default-of.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ ==============================================================

: default-of \ Compilation: ( -- )
  postpone dup postpone of ; immediate compile-only

\ ==============================================================
\ Change log

\ 2014-02-04 Written, based on code by Mark Willis posted to
\ <lang.comp.forth>: Message-ID:
\ <64b90787-344c-4ee0-a0e4-4e2c12b3dec3@googlegroups.com>; Date: Fri,
\ 24 Jan 2014 02:08:22 -0800 (PST).
\
\ 2017-08-17: Update change log layout, header, source style; fix
\ stack comment.
