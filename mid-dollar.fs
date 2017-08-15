\ galope/mid-dollar.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ ==============================================================

: mid$  ( ca1 len1 from len2 -- ca2 len3 )
  >r /string r> min ;

  \ doc{
  \
  \ mid$  ( ca1 len1 from len2 -- ca2 len3 )
  \
  \ Return a string _ca2 len3_ out of the _len2_ characters
  \ at the left of string _ca1 len1_, starting at _from_.
  \
  \ See: `left$`, `right$`.
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
