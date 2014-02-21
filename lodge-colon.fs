\ galope/lodge-colon.fs

\ This file is part of Galope

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ --------------------------------------------------------------
\ About

\ This code provides words that create and manage self-growing buffers
\ that hold variables, values or any kind of data space.  The
\ variables and values work as the ordinary ones, but they store in
\ their own body an offset to the actual data in the buffer.  This
\ makes it possible to save a whole buffer to a binary file and
\ restore it later (e.g.  game sessions), even if the actual absolute
\ address of the buffer changes.

\ There's a simpler version with only one buffer.  See the file
\ <galope/lodge.fs>.  Both versions can not be loaded at the same time
\ because most of the word names are the same.  <galope/lodge.fs>
\ should be a bit faster because of the simpler inner calculations.

\ --------------------------------------------------------------
\ History

\ 2014-02-21: Forked from <galope/lodge.fs>, in order to make
\   an improved version that can create different named buffers.
\ 2014-02-21: Improvement: Several named lodges can be created.
\   'get-lodge' and 'set-lodge' manage the current one.
\ 2014-02-21: Change: Some core words are renamed.
\ 2014-02-21: New: 'lodge-,' and 'lodge-2,'.
\ 2014-02-21: Fix: 'lodge-resize' now can be used directly by the
\   application. Solved by moving the trailing code of
\   'lodge-allocate' to 'lodge-resize'.

\ --------------------------------------------------------------
\ To-do

\ 2014-02-21: Update 'lodge-,' and 'lodge-2,' to the new system.

\ --------------------------------------------------------------
\ Buffer

variable current-lodge  \ data field address of the current lodge
: lodge-address  ( -- a )
  \ Address of the start address of the current lodge space.
  current-lodge @
  ;
: lodge-length  ( -- a )
  \ Address of the length of the current lodge.
  current-lodge @ cell+
  ;

: lodge+  ( +n -- a )
  \ Current absolute address of a lodge offset. 
  lodge-address @ +
  ;
: lodge-update  ( u a -- +n )
  \ u = additional address units already allocated in the lodge
  \ a = new address of the lodge
  \ +n = offset to the new free space
  \      (it's the same than the previous length of the lodge)
  lodge-address !  lodge-length @  swap lodge-length +!
  ;
: lodge-resize  ( u -- +n wior )
  \ u = new size of the lodge
  \ +n = lodge offset to the additional free space
  lodge-address @ swap resize >r lodge-update r>
  ;
: lodge-allocate  ( u -- +n wior )
  \ u = additional address units required in the lodge
  \ +n = lodge offset to the additional free space
  dup lodge-length @ + lodge-resize 
  ;
: (lodge-erase)  ( u +n -- )
  \ Erase u address units from a lodge offset.
  lodge+ swap erase
  ;
: lodge-erase  ( +n u -- )
  \ Erase u address units from a lodge offset.
  swap (lodge-erase)
  ;

: get-lodge  ( -- dfa )
  \ Return the current lodge.
  current-lodge @
  ;
: set-lodge  ( dfa -- )
  \ Set a lodge as current.
  current-lodge ! 
  ;
: lodge:  ( "name" -- )
  \ Create a new empty lodge and make it the current one.
  \ When executed, a lodge returns the address of its body
  \ (data field address), like an ordinary variable.
  \ The body holds the address and length of the allocated space.
  create  0 allocate throw , 0 ,
  latestxt >body set-lodge
  ;

\ --------------------------------------------------------------
\ Variables

: body>lodge  ( dfa -- a )
  \ Convert the body of a lodge-variable or a lodge-value
  \ to the lodge address they point to.
  \ The body (data field address) holds two cells:
  \   0     = The address of the lodge's body
  \           (that holds the actual address of the lodge).
  \   cell+ = The offset in the lodge.
  dup @ @ swap cell+ @ +
  ;

: lodge-variable-does>  ( -- a )
  \ Behaviour of a lodge variable. 
  does> ( -- a ) ( dfa ) body>lodge
  ;
: (lodge-variable)  ( u -- )
  \ Compile a lodge variable of u address units.
  current-lodge @ , dup lodge-allocate throw dup , (lodge-erase)
  ;
: lodge-variable  ( "name" -- )
  \ Create a lodge variable and init it with zero.
  create cell (lodge-variable) lodge-variable-does>
  ;
: lodge-2variable  ( "name" -- )
  \ Create a lodge double variable and init it with zero.
  create 2 cells (lodge-variable) lodge-variable-does>
  ;

\ --------------------------------------------------------------
\ Values

: (lodge-value)  ( u -- a )
  \ Compile a lodge value of u address units.
  current-lodge @ , lodge-allocate throw dup , lodge+
  ;
: (cell-lodge-value:)  ( x "name" -- )
  \ Create a 1-cell lodge value.
  create  cell (lodge-value) !
  ;
: lodge-value  ( n "name" -- )
  \ Create a lodge value.
  (cell-lodge-value:)
  does> ( -- n ) ( dfa ) body>lodge @
  ;
: lodge-address-value  ( +n "name" -- )
  \ Create a lodge address value.
  \ +n = lodge offset 
  \ This kind of lodge-value stores a lodge offset but returns the
  \ corresponding absolute address.  This is useful for creating
  \ lodge-values that point to data space in the lodge but have to be
  \ used as ordinary Forth values.
  (cell-lodge-value:)
  does> ( -- n ) ( dfa )
    dup @ @ dup rot cell+ @ + @ +
    \ dup body>lodge @ swap @ @ +  \ not clearer, and certainly slower
  ;
: lodge-2value  ( d "name" -- )
  \ Create a lodge value.
  create 2 cells (lodge-value) 2!
  does> ( -- n ) ( dfa ) body>lodge 2@
  ;

\ --------------------------------------------------------------
\ To

: xt>lodge  ( xt -- a )
  \ Absolute lodge address from the xt of a lodge-variable or a
  \ lodge-value.
  >body body>lodge
  ;

: <lodge-to>  ( x "name" -- )
  \ Change the content of a lodge-variable or a lodge-value.
  ' xt>lodge !
  ; 
: [lodge-to]  ( compilation: x "name" -- )
  \ Change the content of a lodge-variable or a lodge-value.
  ' postpone literal postpone xt>lodge postpone !
  ; immediate 
' <lodge-to>
' [lodge-to]
interpret/compile: lodge-to

: <lodge-2to>  ( x "name" -- )
  \ Change the content of a lodge-2variable or a lodge-2value.
  ' xt>lodge 2!
  ; 
: [lodge-2to]  ( compilation: d "name" -- )
  \ Change the content of a lodge-2variable or a lodge-2value.
  ' xt>lodge postpone 2literal postpone 2!
  ; immediate 
' <lodge-2to>
' [lodge-2to]
interpret/compile: lodge-2to

\ --------------------------------------------------------------
\ Misc

: lodge-save-mem  ( a1 len -- +n len )
  \ Copy a memory block into the lodge.
  \ Written after Gforth's 'save-mem'.
  swap >r  dup lodge-allocate throw  swap over lodge+ over  r> -rot move
  ;
: lodge-,  ( x -- )
  \ "Compile" a cell into the current lodge.
  cell lodge-allocate throw lodge+ !
  ;
: lodge-2,  ( d -- )
  \ "Compile" two cells into the current lodge.
  2 cells lodge-allocate throw lodge+ 2!
  ;
