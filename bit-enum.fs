\ galope/bit-enum.fs
\ `bit-enum`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016.

\ ==============================================================

: bit-enum  (  n1 "name" -- n2 )
  dup constant  1 lshift dup 0= -11 and throw  ;
  \ Create a constant _name_ with value _n1_. Then get _n2_ by
  \ shifting _n1_ 1 bit to the left. If _n2_ is zero, throw an error
  \ "Result out of range", else return _n2_.

\ ==============================================================
\ Usage example

\ 1
\ bit-enum first-bit
\ bit-enum second-bit
\ bit-enum third-bit
\ bit-enum fourth-bit
\ drop

\ ==============================================================
\ History

\ 2016-07-11: Write.
