\ galope/buffer-colon.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Taken from Wil Baden's ToolBelt 2002.

\ ==============================================================

[undefined] buffer: [if]

: buffer: ( u "name" -- ; -- a ) create allot ;

[then]

\ ==============================================================
\ Change log

\ 2012-05-19: Added. 'buffer:' is common use.
\
\ 2013-05-18: Conditional compilation, because 'buffer:' has been
\ included in the Forth-2012 Standard, and eventually will be part of
\ Gforth. Stack notation modified.
\
\ 2015-01-25: Typo.
\
\ 2017-08-17: Update change log layout. Update header. Update code
\ style.
