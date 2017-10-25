\ match-question.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Hans Bezemer, 2014
\
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

\ Thread link in Google Groups:
\ https://groups.google.com/d/msg/comp.lang.forth/zFRCXnlY2jY/6EuW6C7UZb8J

\ Code based on an article by Brian W. Kernighan and Rob Pike, 1999:
\ http://www.drdobbs.com/architecture-and-design/regular-expressions/184410904

\ Regular expressions by Brian W. Kernighan and Rob Pike
\ believed to be in the public domain.

\ ==============================================================

include ./package.fs

package galope-match-question

defer (matchhere)

: (match*) ( ca1 len1 ca2 len2 c -- f )
  begin
    >r 2over 2over (matchhere) if r> drop 2drop 2drop true exit then
    2over if   c@ dup '.' = swap r@ = or
          else dup xor
          then r> swap
  while                                \ character equals text?
    >r 2>r 1 /string 2r> r>            \ if so, match again
  repeat
  drop 2drop 2drop false ;             \ clean up, return false

: (match?) ( ca1 len1 ca2 len2 c -- f )
  >r 2over 2over (matchhere) if r> drop 2drop 2drop true exit then
  2over if   c@ dup '.' = swap r> = or
        else r> drop dup xor
        then
  if   2>r 1 /string 2r> (matchhere)   \ character equals text?
  else 2drop 2drop false
  then ;

:noname ( ca1 len1 ca2 len2 -- f )
  dup if                               \ regular expression a null string?
    over char+ c@ dup '*' =            \ if not, does it equal a '*'
    if                                 \ if so, call (match*)
      drop over c@ >r 2 /string r> (match*) exit
    else                               \ otherwise, does it equal a '?'
      '?' =
      if                               \ if so, call (match?)
        over c@ >r 2 /string r> (match?) exit
      else                             \ otherwise does it equal a '$'
        over c@ '$' = over 1 = and
        if                             \ and is it the last character?
          2drop nip 0= exit            \ is so, check length of text
        else                           \ finally, check if it char matches
          2over 0<> >r c@ >r over c@ dup
          '.' = swap r> = or r> and
          if 1 /string 2>r 1 /string 2r> recurse exit then false
        then                           \ if so recurse, otherwise quit
      then
    then
  else
    true                               \ zero length regular expression
  then >r 2drop 2drop r> ;             \ clean up and exit

is (matchhere)                         \ assign to DEFER (we got 'em)

public

: match? ( ca1 len1 ca2 len2  -- f )
  dup if over c@ '^' =  if 1 /string (matchhere) exit then then
  begin                                \ if caret, chop it
    2over 2over (matchhere) if 2drop 2drop true exit then
    >r over r> swap                    \ match characters
  while                                \ until no more text
    2>r 1 /string 2r>                  \ chop text
  repeat 2drop 2drop false ;           \ clean up

  \ doc{
  \
  \ match? ( ca1 len1 ca2 len2  -- f )
  \
  \ Does regular expression _ca2 len2_ match string _ca1 len1_? If so,
  \ return _true_. Otherwise return _false_.
  \
  \ The regular expression accepts the following special characters:
  \ '^', '.', '?', '*' and '$'.
  \
  \ Usage examples:
  \
  \ ----

  \ s" 0,9"   s" ^0,?9$" match? . .s cr
  \ s" 0:9"   s" ^0,?9$" match? . .s cr
  \ s" 09"    s" ^0,?9$" match? . .s cr
  \ s" 009"   s" ^0,?9$" match? . .s cr
  \ s" 0,,9"  s" ^0,?9$" match? . .s cr cr

  \ ----
  \
  \ }doc

end-package

\ ==============================================================
\ Change log

\ 2014-11-16: Added.
\
\ 2017-08-17: Update change log layout. Update header.
\
\ 2017-10-25: Use `package` to hide the inner words. Replace `[char]`
\ with Forth-2012 notation. Update code layout and stack notation.
\ Improve documentation, header and references.
