\ galope/bit-field-colon.fs
\ `bitfield:`
\ Bit fields for data structures.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ By Marcos Cruz (programandala.net)

\ 2016-06-23: Extract from the project "Asalto y castigo"
\ (http://programandala.net/es.programa.asalto_y_castigo.forth.html)
\ in order to reuse it in other projects. Improve with some name
\ changes. Translate comments.

require ./module.fs

module: galope-bit-field-colon-module

variable bitfield-mask
  \ Bitmask counter.

: ?bitfield-mask  ( -- u )
  bitfield-mask @  dup 0= abort" Too many bits in the field"  ;
  \ XXX FIXME this check depends on the cell width, thus the amount of
  \ contiguous bit fields defined in one data structure depends on the
  \ machine.  Make the system smarter: use additional cells when
  \ needed.

: next-bit  ( -- )  bitfield-mask @ 1 lshift bitfield-mask !  ;

export

: bitfields  ( -- )  1 bitfield-mask !  ;
  \ Mark the start of the bit fields in a data structure.

\ : begin-structure  ( "name" -- )  init-bitfields begin-structure  ;
  \ XXX TODO

: bitfield:  ( n "name" -- n )
  create  ?bitfield-mask over 2, next-bit
  does>  ( a -- u a' )  ( a pfa ) 2@ rot +  ;
  \ Create a bit field _name_, with offset _n_ from the start of the
  \ structure (the field that holds the bit fields must be created
  \ with `field:` after the last `bitfield:`.
  \ When executed, `name` will return its address _a'_ and bitmask
  \ _u_.

: bit-on  ( u a -- )  dup @ rot or swap !  ;
  \ Turn a bit field on (address _a_ and bitmask _u_).

: bit-off  ( u a -- )  dup @ rot invert and swap !  ;
  \ Turn a bit field off (address _a_ and bitmask _u_).

: bit!  ( f u a -- )  rot if  bit-on  else  bit-off  then  ;
  \ Store _f_ in a bit field (address _a_ and bitmask _u_).

: bit@  ( u a -- f )  @ and 0<>  ;
  \ Fetch _f_ from a bit field (address _a_ and bitmask _u_).

\ Usage example:
\
\ 0
\   2field: thing>name  \ string
\   bitfields
\     bitfield: thing>portable
\     bitfield: thing>fast
\     bitfield: thing>automatic
\   field: thing>bitfields  \ actual field that holds the bit fields
\ constant /thing

\ XXX TODO -- Make this syntax possible:
\
\ ----
\ 0
\   2field: thing>name  \ string
\   begin-bitfields
\     bitfield: thing>portable
\     bitfield: thing>fast
\     bitfield: thing>automatic
\   end-bitfields
\ constant /thing
\ ----
\
\ `end-bitfields` would reserve as much cells as needed to hold all
\ bit fields. This way the code will be portable among 8-bit and
\ 32-bit platforms. `begin-bitfield` must preserve the initial offset
\ and `bitfield:` must increase it when needed.

;module
