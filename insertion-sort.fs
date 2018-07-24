\ galope/insertion-sort.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Last modified: 201807241422
\ See change log at the end of the file.

\ Authors:
\   Hans Bezemer (?), 2014
\   Marcos Cruz (programandala.net) adapted the code to Galope, 2018.

\ ==============================================================
\ Credit

0 [if]

Message-Id: <534a86b9$0$2853$e4fe514c@news2.news.xs4all.nl>
From: Hans Bezemer
Subject: Does anyone know this sorting routine??
Newsgroups: comp.lang.forth
Date: Sun, 13 Apr 2014 14:45:13 +0200

Message-Id: <534bec3d$0$2942$e4fe514c@news2.news.xs4all.nl>
From: Hans Bezemer
Subject: Re: Does anyone know this sorting routine??
Newsgroups: comp.lang.forth
Date: Mon, 14 Apr 2014 16:10:38 +0200

[then]

\ ==============================================================
\ Requirements

require ./package.fs           \ `package`
require ./precedes-question.fs \ `precedes?`

\ ==============================================================

package galope-insertion-sort

: (insert) ( start end -- start )
  dup @ >r                             \ v = a[i] ( r: v )
  begin
    2dup <                             \ j>0
  while
    r@ over cell- @ precedes?          \ a[j-1] > v
  while
    cell-                              \ j--
    dup @ over cell+ !                 \ a[j] = a[j-1]
  repeat then
  r> swap ! ;                          \ a[j] = v

public

: insertion-sort ( a len -- )
  dup 2 < if 2drop exit then
  1 ?do dup i cells + (insert) loop drop ;

  \ doc{
  \
  \ insertion-sort ( a len --)
  \
  \ Sort cells stored in memory zone _a len_.
  \
  \ The sorting is configurable with `precedes?`.
  \
  \ See: `boosted-insertion-sort`.
  \
  \ }doc

end-package

\ ==============================================================
\ Change log

\ 2018-07-24: Extract from <boosted-insertion-sort.fs>.  Use `package`
\ to hide the internal words. Document.
