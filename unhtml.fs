\ galope/unhtml.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

require ./package.fs

package galope-unhtml

variable tag?
  \ Flag: does the current char belong to a HTML tag?

variable destination
  \ Address where the next valid character is stored.

: ignore ( c -- ) '>' <> tag? ! ;
  \ Ignore _c_, because it's in a HTML tag. Update `tag?`.

: keep ( c -- ) destination @ c! 1 chars destination +! ;
  \ Keep _c_.

: ?keep ( c -- )
  dup '<' = dup tag? ! \ start of tag?
  if drop else keep then ;
  \ If _c_ is not the start of a new HTML tag, keep it.

: (unhtml) ( c -- ) tag? @ if ignore else ?keep then ;
  \ Handle _c_: Ignore it or keep it.

public

: unhtml ( ca len -- ca len' )
  over dup >r destination !
  bounds ?do i c@ (unhtml) loop
  r> dup destination @ swap - ;

  \ doc{
  \
  \ unhtml ( ca len -- ca len' )
  \
  \ Remove the HTML tags from a string _ca len_, resulting string
  \ _ca len'_. If _ca len_ does not contain any HTML tag, _len'_ is
  \ equal to _len_.
  \
  \ WARNING: Note the output string overwrites the input string.
  \
  \ }doc

end-package

\ ==============================================================
\ Change log

\ 2014-11-07: Added.
\
\ 2017-08-17: Update change log layout.
\
\ 2017-08-18: Use `package` instead of `module:`.
\
\ 2017-11-28: Update source layout. Rename some words. Improve
\ documentation.
