\ galope/nospace.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017, 2018.

\ ==============================================================

require ./package.fs

package galope-nospace

variable destination  \ address to store the next valid char into

: keep ( c -- )
  destination @ c!  1 chars destination +! ;
  \ Keep the given char and update 'spaces?'.

: (nospace) ( c -- )
  dup bl = if drop else keep then ;
  \ Ignore or keep the given current char.

public

: nospace ( ca len -- ca len' )
  over dup >r destination !
  bounds ?do i c@ (nospace) loop
  r> dup destination @ swap - ;

  \ doc{
  \
  \ nospace ( ca len -- ca len' )
  \
  \ Remove all spaces from string _ca len_, returning the result
  \ _ca len'_.
  \
  \ See: `unspace`, `trim`, `-leading`.
  \
  \ }doc

end-package

\ ==============================================================
\ Change log

\ 2014-12-01: Written, based on <galope/unspace.fs>.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
\
\ 2017-08-18: Use `package` instead of `module:`.
\
\ 2018-07-24: Improve documentation.
