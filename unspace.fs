\ galope/unspace.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017, 2018.

\ ==============================================================

require ./package.fs

package galope-unspace

variable spaces?
  \ Flag: does the current char belongs to a HTML tag?

variable destination
  \ Address where the next valid char will be stored.

: keep ( c -- ) dup bl = spaces? !
                destination @ c!
                1 chars destination +! ;
  \ Keep char _c_ and update 'spaces?'.

: extra-space? ( c -- f )
  bl = dup spaces? @ and swap spaces? ! ;
  \ Is the current char _c_ and extra space?
  \ Also, update 'spaces?'.

: (unspace) ( c -- )
  dup extra-space? if drop else keep then ;
  \ Ignore or keep the current char _c_.

public

: unspace ( ca len -- ca len' )
  over dup >r destination !
  bounds ?do i c@ (unspace) loop
  r> dup destination @ swap - ;

  \ doc{
  \
  \ unspace ( ca len -- ca len' )
  \
  \ Remove double spaces from string _ca len_, returning the result
  \ _ca len'_.
  \
  \ See: `nospace`, `trim`, `-leading`.
  \
  \ }doc

end-package

\ ==============================================================
\ Change log

\ 2014-11-16: Written.
\
\ 2017-08-17: Update change log layout.  Update stack notation.
\
\ 2017-08-18: Use `package` instead of `module:`.
\
\ 2018-07-24: Update source style. Improve documentation.
