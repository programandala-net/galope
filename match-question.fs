\ match-question.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ History
\ 2014-11-16: Added.

\ Author: Hans Bezemer
\ Source:

\ Message-Id: <543bfa10$0$2928$e4fe514c@news2.news.xs4all.nl>
\ From: Hans Bezemer <the.beez.speaks@gmail.com>
\ Subject: Tiny regular expressions code
\ Newsgroups: comp.lang.forth
\ Date: Mon, 13 Oct 2014 18:15:14 +0200

\ Message-Id: <543bfacc$0$2928$e4fe514c@news2.news.xs4all.nl>
\ From: Hans Bezemer <the.beez.speaks@gmail.com>
\ Subject: Re: Tiny regular expressions code
\ Newsgroups: comp.lang.forth
\ Date: Mon, 13 Oct 2014 18:18:22 +0200
\ References: <543bfa10$0$2928$e4fe514c@news2.news.xs4all.nl>

\ Regular Expressions by Brian W. Kernighan and Rob Pike
\ Believed to be in the public domain

defer (matchhere)

: (match*)                             ( a n ra rn c --f)
  begin
    >r 2over 2over (matchhere) if r> drop 2drop 2drop true exit then
    2over if c@ dup [char] . = swap r@ = or else dup xor then r> swap
  while                                \ character equals text?
    >r 2>r 1 /string 2r> r>            \ if so, match again
  repeat
  drop 2drop 2drop false               \ clean up, return false
;

: (match?)                             ( a n ra rn c --f)
  >r 2over 2over (matchhere) if r> drop 2drop 2drop true exit then
   2over if c@ dup [char] . = swap r> = or else r> drop dup xor then
  if 2>r 1 /string 2r> (matchhere) else 2drop 2drop false then
;                                      \ character equals text?
:noname                                ( a n ra rn -- f)
  dup if                               \ regular expression a null string?
    over char+ c@ dup [char] * =       \ if not, does it equal a '*'
    if                                 \ if so, call (match*)
      drop over c@ >r 2 /string r> (match*) exit
    else                               \ otherwise, does it equal a '?'
      [char] ? =
      if                               \ if so, call (match?)
        over c@ >r 2 /string r> (match?) exit
      else                             \ otherwise does it equal a '$'
        over c@ [char] $ = over 1 = and
        if                             \ and is it the last character?
          2drop nip 0= exit            \ is so, check length of text
        else                           \ finally, check if it char matches
          2over 0<> >r c@ >r over c@ dup
          [char] . = swap r> = or r> and
          if 1 /string 2>r 1 /string 2r> recurse exit then false
        then                           \ if so recurse, otherwise quit
      then
    then
  else
    true                               \ zero length regular expression
  then >r 2drop 2drop r>               \ clean up and exit
; is (matchhere)                       \ assign to DEFER (we got 'em)

: match?                                ( a n ra rn  --f)
  dup if over c@ [char] ^ =  if 1 /string (matchhere) exit then then
  begin                                \ if caret, chop it
    2over 2over (matchhere) if 2drop 2drop true exit then
    >r over r> swap                    \ match characters
  while                                \ until no more text
    2>r 1 /string 2r>                  \ chop text
  repeat 2drop 2drop false             \ clean up
;

true [if]  \ usage examples

 s" 0,9"   s" ^0,?9$" match? . .s cr
 s" 0:9"   s" ^0,?9$" match? . .s cr
 s" 09"    s" ^0,?9$" match? . .s cr
 s" 009"   s" ^0,?9$" match? . .s cr
 s" 0,,9"  s" ^0,?9$" match? . .s cr cr

[then]
