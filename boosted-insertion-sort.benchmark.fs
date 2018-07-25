\ galope/boosted-insertion-sort.benchmark.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Last modified: 201807251834
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

require ./boosted-insertion-sort.fs \ `boosted-insertion-sort`
require ./insertion-sort.fs         \ `insertion-sort`

\ ==============================================================

[undefined] th [if]
  : th ( a1 u -- a2 ) cells + ;
[then]

variable seed

32767 constant max-rand
  \ Maximum random number.

: (random) ( n1 n2 -- n3 )
  seed @ * + dup seed ! 16 rshift max-rand and ;

: random ( -- n ) 12345 1103515245 (random) ;

: randomize ( -- ) random seed ! ;

: choose ( n1 n2 -- n3 ) random * max-rand 1+ / ;

randomize

1000 constant /array

/array cells buffer: array

: fill-array ( -- )
  /array 0 do max-rand choose array i th ! loop ;

: .array ( -- )
  /array 0 do array i th ? loop cr ;

synonym ticks utime

: elapsed ( ud1 -- ud2 ) ticks 2swap d- ;

: timer ( ud -- ) elapsed ud. ;

fill-array cr ." Insertion sort:"
ticks array /array insertion-sort timer cr

fill-array cr ." Boosted insertion sort:"
ticks array /array boosted-insertion-sort timer cr

\ array! cr ." Circle sort:"
\ ticks array /array (circle-sort) timer cr

\ .Benchmark results (in microseconds) with 100000 items
\ |===
\ | Date       | items   | insertion-sort | boosted-insertion-sort | Notes
\
\ | 2014       | 100 000 | 112 448 573    |   502 108              | (1)
\ | 2018-07-23 | 100 000 | 538 090 404    | 3 124 079              | (2)
\ | 2018-07-23 | 100 000 | 478 182 675    | 2 658 325              | (2) Stack operations optimized
\ | 2018-07-24 |   1 000 |      46 858    |     8 275              | (2)
\ |===

\ Notes:
\
\ (1) By Hans Bezemer. Running on 4tH. Unknown machine.
\ (2) Running on Gforth 0.7.9_20171005 on a Raspberry Pi 2.

\ ==============================================================
\ Change log

\ 2018-07-25: Extract from <boosted-insertion-sort.fs>. Simplify the
\ timer.
