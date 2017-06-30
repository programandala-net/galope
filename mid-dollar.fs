\ galope/mid-dollar.fs
\ mid$

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ History
\ 2013-09-13 Added, after Anton Ertl's examples in <nntp://comp.lang.forth>:
\   Message-ID: <2013Sep5.105647@mips.complang.tuwien.ac.at>
\   Newsgroups: comp.lang.forth
\   Subject: Re: Awk/Forth like mini language, advice
\   Date: Thu, 05 Sep 2013 08:56:47 GMT

: mid$  ( ca1 len1 from len2 -- ca2 len2 )
  >r /string r> min
  ;


