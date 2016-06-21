\ galope/unspace.fs

\ This file is part of Galope

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ History
\ 2014-11-16: Written.

require ./module.fs

module: galope-unspace-module

variable spaces?  \ flag: does the current char belongs to a HTML tag?
variable destination  \ address to store the next valid char into
: keep  ( c -- )
  \ Keep the given char and update 'spaces?'.
  dup bl = spaces? !
  destination @ c!  1 chars destination +!
  ;
: extra_space?  ( c -- wf )
  \ Is the given current char and extra space?
  \ Also, update 'spaces?'.
  bl = dup spaces? @ and  swap spaces? !
  ;
: (unspace)  ( c -- )
  \ Ignore or keep the given current char.
  dup extra_space? if  drop  else  keep  then
  ;

export

: unspace  ( ca len -- ca len' )
  \ Remove double spaces from a string.
  over dup >r destination !
  bounds ?do  i c@ (unspace)  loop
  r> dup destination @ swap -
  ;

;module

