\ galope/xy.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Krishna Myeni, 1999-2004
\
\ Modified by: Marcos Cruz (programandala.net), 2012, 2013, 2014, 2017

\ ==============================================================
\ Credits

\ Original code extracted from:

\ --------------------------------------------------------------
\ ansi.4th
\ ANSI Terminal words for kForth
\ Copyright (c) 1999--2004 Krishna Myneni
\ Creative Consulting for Research and Education
\ This software is provided under the terms of the GNU
\ General Public License.
\ --------------------------------------------------------------

\ ==============================================================

require ./package.fs

package galope-xy

: number<c>  ( c -- n )
  >r 0 begin  key dup r@ <>
       while  swap #10 * swap '0' - +
       repeat r> 2drop ;
  \ Read a decimal numeric entry delimited by character c.
  \
  \ XXX TODO -- Move this word to its own file.
  \
  \ XXX TODO -- Choose a better name:
  \ number/c
  \ keys/c>decimal
  \ keys>#
  \ keys>number
  \ keys>#number
  \
  \ XXX TODO -- No final char: finish at the first non-digit instead.

public

: xy ( -- u1 u2 )
  esc[ ." 6n"
  key key 2drop \ erase: <esc> [
  ';' number<c> 'R' number<c>
  1- swap 1- ;

  \ doc{
  \
  \ xy ( -- u1 u2 )
  \
  \ Return the current cursor coordinates _u1 u2_. _u1_ is the X
  \ coordinate; _u2_ is the Y coordinate.
  \
  \ See: `row`, `column`.
  \
  \ }doc

end-package

\ ==============================================================
\ Change log

\ 2012-04: Extracted from a program of mine.
\
\ 2012-04-29: Added 'at-x' and 'at-y'.
\
\ 2012-05-08: 'at-x' and 'at-y' moved to their own files.
\
\ 2013-06-26: Fixed some comments.
\
\ 2013-06-26: Gforth's 'esc[' used instead of 'ansi_escape'.
\
\ 2014-11-17: Module name updated.
\
\ 2017-08-17: Update change log layout. Update header.
\
\ 2017-08-18: Use `package` instead of `module:`. Fix: Move the `base`
\ backup and restore outside the package. Update source style.
\
\ 2017-10-25: Improve documentation.
