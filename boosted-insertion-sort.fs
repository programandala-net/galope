\ galope/boosted-insertion-sort.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Last modified: 201807231851
\ See change log at the end of the file.

\ Authors:
\   Hans Bezemer, 2014
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

defer precedes? ( x1 x2 -- f )

' < ' precedes? defer!

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

: insertion-sort ( a len -- )
  dup 2 < if 2drop exit then
  1 ?do dup i cells + (insert) loop drop ;

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

: boosted-insertion-sort ( a len --)
  begin 0 #swaps ! 2dup (circle-sort) #swaps @ over 2* <
  until
  insertion-sort ;

\ ==============================================================
\ Benchmark

false [if]

[undefined] th [if]
  : th ( a1 u -- a2 ) cells + ;
[then]

variable seed                         \ seed variable
32767 constant max-rand               \ maximum random number
                                      ( -- n)
: (random) seed @ * + dup seed ! 16 rshift max-rand and ;
: random 12345 1103515245 (random) ;
: randomize random seed ! ;             ( -- )
: CHOOSE random * max-rand 1+ / ;

randomize

100000 constant /size
/size buffer: example

: array! ( -- )
  /size 0 do max-rand choose example i th ! loop ;

: .array ( -- )
  /size 0 do example i th ? loop cr ;

array! cr ." Insertion sort:"
utime example /size insertion-sort utime 2swap d- d. ." microseconds" cr
array! cr ." Boosted insertion sort:"
utime example /size boosted-insertion-sort utime 2swap d- d. ." microseconds" cr
\ array! cr ." Circle sort:"
\ utime example /size (circlesort) utime 2swap d- d. ." microseconds" cr

\ .Benchmark results (in microseconds)
\ |===
\ | Date       | insertion-sort | boosted-insertion-sort | Notes
\
\ | 2014       |    112 448 573 |                502 108 | (1)
\ | 2018-07-23 |    538 090 404 |              3 124 079 | (2)
\ | 2018-07-23 |    478 182 675 |              2 658 325 | (2) Stack operations optimized
\ |===

\ Notes:
\
\ (1) By Hans Bezemer. Running on 4tH. Unknown machine.
\ (2) Running on Gforth 0.7.9_20171005 on a Raspberry Pi 2.

[then]

\ ==============================================================
\ Change log

\ 2018-07-23: Begin to adapt the code to Galope. Optimize stack
\ operations. Improve names.
