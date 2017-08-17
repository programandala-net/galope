\ galope/unhtml.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014.

\ ==============================================================

require ./module.fs

module: galope-unhtml-module

variable tag?  \ flag: does the current char belongs to a HTML tag?
variable destination  \ address to store the next valid char into
: ignore  ( c -- )
  \ Ignore the given char, because it's in a HTML tag.
  [char] > <> tag? !  \ end of tag?
  ;
: (keep)  ( c -- )
  \ Keep the given char.
  destination @ c!  1 chars destination +!
  ;
: keep  ( c -- )
  \ Keep the given char, if it's not the start of a new HTML tag.
  dup [char] < = dup tag? !  \ start of tag?
  if  drop  else  (keep)  then
  ;
: (unhtml)  ( c -- )
  \ Ignore or keep the given current char.
  tag? @ if  ignore  else  keep  then
  ;

export

: unhtml  ( ca len -- ca len' )
  \ Remove the HTML tags from a string.
  over dup >r destination !
  bounds ?do  i c@ (unhtml)  loop
  r> dup destination @ swap -
  ;

;module

\ ==============================================================
\ Change log

\ 2014-11-07: Added.
\
\ 2017-08-17: Update change log layout.
