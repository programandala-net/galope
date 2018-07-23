\ galope/boosted-insertion-sort.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Authors:
\   Hans Bezemer, 2014
\   Marcos Cruz (programandala.net) adapted the code to Galope, 2018.

\ XXX UNDER DEVELOPMENT

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

[UNDEFINED] cell- [IF]
: cell- 1 cells - ;
[THEN]

defer precedes                         \ compatible with QSORT

: (insert) ( start end -- start )
  dup @ >r                             \ v = a[i] ( r: v )
  begin
    over over <                        \ j>0
  while
    r@ over cell- @ precedes           \ a[j-1] > v
  while
    cell-                              \ j--
    dup @ over cell+ !                 \ a[j] = a[j-1]
  repeat
[UNDEFINED] 4TH# [IF] then [THEN]
  r> swap ! ;                          \ a[j] = v

: insertion-sort ( a len -- )
  dup 2 < if 2drop exit then
  1 ?do dup i cells + (insert) loop drop ;

variable (swaps)

: (circlesort) ( a len )
  dup 1 > if
    over over                          ( array len)
    1- cells over + swap               ( 'end 'begin)
    begin
      over over >                      \ if we didn't pass the middle
    while                              \ check and swap opposite elements
      over @ over @ precedes           \ if swapped, increment (swaps)
      if over over over @ over @ swap rot ! swap ! 1 (swaps) +! then
      swap cell- swap cell+
    repeat
    drop drop over over 2/ recurse     \ sort first partition
    dup 2/ cells rot + swap dup 2/ - recurse exit
  then                                 \ sort second partition
  drop drop                            \ nothing to sort
;

: boosted-insertion-sort ( a len --)
  begin 0 (swaps) ! over over (circlesort) (swaps) @ over 2* <
  until
  insertion-sort ;

:noname < ; is precedes

\ ==============================================================
\ Benchmark

false [if]

: array create cells allot ;
: th cells + ;

variable seed                         \ seed variable
32767 constant max-rand               \ maximum random number
                                      ( -- n)
: (random) seed @ * + dup seed ! 16 rshift max-rand and ;
: random 12345 1103515245 (random) ;
: randomize random seed ! ;             ( -- )
: CHOOSE random * max-rand 1+ / ;

randomize

100000 constant /size
/size array example

: array! /size 0 do max-rand choose example i th ! loop ;
: .array /size 0 do example i th ? loop cr ;

array!


\ cr ." Boosted insertion sort:"
\ utime example /size boosted-insertion-sort utime 2swap d- d. ." microseconds" cr
\ cr ." Insertion sort:"
\ utime example /size insertion-sort utime 2swap d- d. ." microseconds" cr
\ cr ." Circle sort:"
\ utime example /size (circlesort) utime 2swap d- d. ." microseconds" cr

\ .Benchmark results (in microseconds)
\ |===
\ | Date       | insertion-sort | boosted-insertion-sort | Notes
\
\ | 2014       |    112 448 573 |                502 108 | (1)
\ | 2018-07-23 |    538 090 404 |              3 124 079 | (2)
\ |===

\ Notes:
\
\ (1) By Hans Bezemer. Running on 4tH. Unknown machine.
\ (2) Running on Gforth 0.7.9_20171005 on a Raspberry Pi 2.

[then]

\ ==============================================================
\ Change log

\ 2018-07-23: Begin to adapt the code to Galope.
