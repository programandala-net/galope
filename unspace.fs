\ galope/unspace.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

require ./package.fs

package galope-unspace

variable spaces?  \ flag: does the current char belongs to a HTML tag?
variable destination  \ address to store the next valid char into
: keep  ( c -- )
  \ Keep the given char and update 'spaces?'.
  dup bl = spaces? !
  destination @ c!  1 chars destination +!
  ;
: extra_space?  ( c -- f )
  \ Is the given current char and extra space?
  \ Also, update 'spaces?'.
  bl = dup spaces? @ and  swap spaces? !
  ;
: (unspace)  ( c -- )
  \ Ignore or keep the given current char.
  dup extra_space? if  drop  else  keep  then
  ;

public

: unspace  ( ca len -- ca len' )
  \ Remove double spaces from a string.
  over dup >r destination !
  bounds ?do  i c@ (unspace)  loop
  r> dup destination @ swap -
  ;

end-package

\ ==============================================================
\ Change log

\ 2014-11-16: Written.
\
\ 2017-08-17: Update change log layout.  Update stack notation.
\
\ 2017-08-18: Use `package` instead of `module:`.
