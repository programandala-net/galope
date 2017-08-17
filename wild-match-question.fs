\ wild-match-question.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014.

\ Message-Id: <54414f47$0$2922$e4fe514c@news2.news.xs4all.nl>
\ From: Hans Bezemer <the.beez.speaks@gmail.com>
\ Subject: Re: Tiny regular expressions code
\ Newsgroups: comp.lang.forth
\ Date: Fri, 17 Oct 2014 19:20:12 +0200

\ ==============================================================

require ./chop.fs
require ./four-drop.fs

: wild-match?  ( ca1 len1 ca2 len2 -- wf )
  \ ca1 len1 = string
  \ ca2 len2 = match string (wildcard expression)
  begin
    dup                                \ exit when match string is exhausted
  while
    over c@ [char] ? =                 \ match any character
    if                                 \ except empty string
      >r over r> swap 0= if  4drop false exit  then
      2>r chop 2r> chop                \ okay, next one please
    else
      over c@ [char] * =               \ match zero or more characters
      if                               \ because we eat one character
        2over 2over chop recurse if  4drop true exit  then
        >r over r> swap if  2over chop 2over recurse  else  false  then
        >r 4drop r> exit               \ from match string, recursion stops
      else                             \ nothing worked with this wildcard
        2over if                       \ not an empty string?
          c@ >r over c@ r> =           \ if so, compare both characters
          if  2>r chop 2r> chop  else  4drop false exit  then
        else                           \ otherwise, it's no use going on
          drop 4drop false exit
        then
      then
    then
  repeat  \ get next character
  >r drop nip r> or 0=  \ only a match if both are at the end
  ;

\ ==============================================================
\ Change log

\ 2014-11-16: Added.
\
\ 2017-08-17: Update change log layout.
