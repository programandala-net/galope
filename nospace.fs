\ galope/nospace.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014.

\ ==============================================================

require ./module.fs

module: galope-nospace-module

variable destination  \ address to store the next valid char into

: keep ( c -- )
  destination @ c!  1 chars destination +! ;
  \ Keep the given char and update 'spaces?'.

: (nospace) ( c -- )
  dup bl = if drop else keep then ;
  \ Ignore or keep the given current char.

export

: nospace ( ca len -- ca len' )
  over dup >r destination !
  bounds ?do i c@ (nospace) loop
  r> dup destination @ swap - ;
  \ Remove all spaces from a string.

;module

\ ==============================================================
\ Change log

\ 2014-12-01: Written, based on <galope/unspace.fs>.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
