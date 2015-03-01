\ galope/nospace.fs

\ This file is part of Galope

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ History
\ 2014-12-01: Written, based on <galope/unspace.fs>.

require ./module.fs

module: galope_nospace_module 

variable destination  \ address to store the next valid char into
: keep  ( c -- )
  \ Keep the given char and update 'spaces?'.
  destination @ c!  1 chars destination +!
  ;
: (nospace)  ( c -- )
  \ Ignore or keep the given current char.
  dup bl = if  drop  else  keep  then
  ;

export

: nospace  ( ca len -- ca len' )
  \ Remove all spaces from a string.
  over dup >r destination !
  bounds ?do  i c@ (nospace)  loop
  r> dup destination @ swap - 
  ;

;module

