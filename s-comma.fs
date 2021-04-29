\ galope/s-comma.fs
\ `,s`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2021.

\ ==============================================================

[undefined] s, [if]

: s, ( ca len -- ) string, align ;

[then]

\ doc{
\
\ s, ( ca len -- )
\
\ Allocate a string _ca len_.
\
\ NOTE: If ``s,`` is already defined in the current search order, the
\ definition provided by the Galope module is ignored. This word was
\ added when it was removed from Gforth, between Gforth versions
\ 0.7.9_20201231 and 0.7.9_20210422. Its definition in Galope is
\ specific to Gforth. 
\
\ }doc

\ ==============================================================
\ Change log

\ 2021-04-29: Added, because it was removed from Gforth between
\ versions 0.7.9_20201231 and 0.7.9_20210422.
