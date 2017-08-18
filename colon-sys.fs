\ galope/colon-sys.fs
\ colon-sys tools

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

\ ==============================================================

require ./package.fs

package galope-colon-sys

variable tmp

public

: colon-sys>r  ( colon-sys -- ; R: a -- colon-sys )
  \ Move a colon-sys to the return stack.
  r> tmp !  2>r 2>r  tmp @ >r
  ;
: r>colon-sys  ( -- colon-sys ; R: colon-sys a -- )
  \ Move a colon-sys from the return stack.
  r> tmp !  2r> 2r>  tmp @ >r
  ;

end-package

\ ==============================================================
\ Change log

\ 2012-12-01: First version, needed for the Finto project
\ (<http://programandala.net/en.program.finto>).
\
\ 2014-11-17: Module name updated.
\
\ 2017-08-17: Update change log layout. Update header.
\
\ 2017-08-18: Use `package` instead of `module:`.
