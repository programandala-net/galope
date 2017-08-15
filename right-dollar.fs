\ galope/right-dollar.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ ==============================================================

: right$ ( ca1 len1 len2 -- ca2 len3 )
  over swap - /string ;

  \ doc{
  \
  \ right$ ( ca1 len1 len2 -- ca2 len3 )
  \
  \ Return a string _ca2 len3_ out of the _len2_ or _len1_ characters
  \ at the right of string _ca1 len1_ (whichever is smaller).
  \
  \ See: `left$`, `mid$`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-09-13 Added, after Anton Ertl's examples in <nntp://comp.lang.forth>:
\   Message-ID: <2013Sep5.105647@mips.complang.tuwien.ac.at>
\   Newsgroups: comp.lang.forth
\   Subject: Re: Awk/Forth like mini language, advice
\   Date: Thu, 05 Sep 2013 08:56:47 GMT
\
\ 2017-08-16: Update source style and file header. Document.

