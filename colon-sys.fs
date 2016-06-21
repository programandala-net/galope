\ galope/colon-sys.fs
\ colon-sys tools
 
\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ History

\ 2012-12-01: First version, needed for the Finto project
\ (<http://programandala.net/en.program.finto>).
\ 2014-11-17: Module name updated.

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

require ./module.fs

module: galope-colon-sys-module

variable tmp

export

: colon-sys>r  ( colon-sys -- ; R: a -- colon-sys )
  \ Move a colon-sys to the return stack.
  r> tmp !  2>r 2>r  tmp @ >r
  ; 
: r>colon-sys  ( -- colon-sys ; R: colon-sys a -- )
  \ Move a colon-sys from the return stack.
  r> tmp !  2r> 2r>  tmp @ >r
  ; 

;module
