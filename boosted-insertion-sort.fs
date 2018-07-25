\ galope/boosted-insertion-sort.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Last modified: 201807251750
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

It's a kind of boosted insertion sort. On my machine/compiler the results
are rather dramatic - compared to a vanilla insertion sort. Please clarify
if you can. As usual, compatible with Wil Baden's QSORT:
Hans Bezemer

Message-Id: <534bec3d$0$2942$e4fe514c@news2.news.xs4all.nl>
From: Hans Bezemer
Subject: Re: Does anyone know this sorting routine??
Newsgroups: comp.lang.forth
Date: Mon, 14 Apr 2014 16:10:38 +0200

[then]

\ ==============================================================
\ Requirements

require ./insertion-sort.fs    \ `insertion-sort`
require ./package.fs           \ `package`
require ./precedes-question.fs \ `precedes?`

\ ==============================================================

package galope-boosted-insertion-sort

variable #swaps

: (circle-sort) ( a len --)
  dup 1 > if
    2dup                          ( a len)
    1- cells over + swap          ( 'end 'begin)
    begin
      2dup > \ if we didn't pass the middle
    while    \ check and swap opposite elements
      over @ over @ precedes? \ if swapped, increment #swaps
      if 2dup over @ over @ swap rot ! swap ! 1 #swaps +! then
      swap cell- swap cell+
    repeat
    2drop 2dup 2/ recurse \ sort 1st partition
    dup 2/ cells rot + swap dup 2/ - recurse exit \ sort 2nd partition
  then 2drop ;

public

: boosted-insertion-sort ( a len --)
  begin 0 #swaps ! 2dup (circle-sort) #swaps @ over 2* <
  until
  insertion-sort ;

  \ doc{
  \
  \ boosted-insertion-sort ( a len --)
  \
  \ Sort cells stored in memory zone _a len_, using a boosted, faster
  \ version of `insertion-sort`.
  \
  \ The sorting is configurable with `precedes?`.
  \
  \ }doc

end-package

\ ==============================================================
\ Change log

\ 2018-07-23: Begin to adapt the code to Galope. Optimize stack
\ operations. Improve names.
\
\ 2018-07-24: Move `precedes?` and `insertion-sort` to their own
\ modules. Use `package` to hide the internal words. Document. Fix
\ recent bug introduced in the benchmark.
\
\ 2018-07-25: Move the benchmark to <boosted-insertion-sort.demo.fs>.
