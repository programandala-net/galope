\ galope/lodge.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ --------------------------------------------------------------
\ About

\ This code provides words that create variables, values or any kind
\ of data whose actual data are stored into a self-growing buffer. The
\ variables and values store in their own body an offset to the actual
\ data in the buffer.  This makes it possible to save the whole buffer
\ to a binary file and restore it later (e.g. for game sessions), even
\ if the actual absolute address of the buffer changes.

\ There's an improved version that makes it possible to create
\ different named buffers and change any of them at any moment.  See
\ the file <galope/lodge-colon.fs>.  Both versions can not be loaded
\ at the same time because most of the word names are the same.
\ <galope/lodge.fs> should be a bit faster because of the simpler
\ inner calculations.

\ The first name of this code was "zbuffer"; then it was renamed to
\ "pack", but unfortunately the name was already taken in Galope, by a
\ simple one-liner; then it was renamed to "stow", just to discover
\ (in The Collaborative International Dictionary of English v.0.48
\ [gcide]) that "stow" is only a transitive verb, not a substantive,
\ and some words didn't fit well; finally "lodge" was chosen...

\ --------------------------------------------------------------
\ History

\ 2014-02-16 Written for Finto
\   (<http://programandala.net/en.program.finto.html>).
\ 2014-02-17 New: 'lodge-value', 'lodge-to' and related words.
\ 2014-02-19 New: 'lodge-address-value'.
\ 2014-02-20 Change: "index" and "relative pointer" corrected to "offset"
\   in the comments; additional comment in 'lodge-address-value';
\   '(cell-lodge-value:)' factored out from 'lodge-value' and
\   'lodge-address-value'; '>lodge' renamed to 'lodge+'.
\ 2014-02-20 New: 'lodge-save-mem'.
\ 2014-02-21 Fix: '[lodge-to]' and '[lodge-2to]' were wrong.
\   '[lodge-to]', before the fix:
\     ' postpone xt>lodge postpone literal postpone !
\     \ first bug: 'xt>lodge' should not be postponed in this case.
\     \ second bug: the absolute lodge address must not be compiled,
\     \   because it may change.
\   After the fix:
\     ' postpone literal postpone xt>lodge postpone !
\   Now the xt is compiled and the lodge address is calculated at run-time.
\ 2014-02-21: Forked to <galope/lodge-colon.fs>.
\ 2014-02-21: New: 'lodge-,' and 'lodge-2,'.
\ 2014-02-21: Fix: 'lodge-resize' now can be used directly by the
\   application. Solved by moving the trailing code of
\   'lodge-allocate' to 'lodge-resize'.

\ --------------------------------------------------------------
\ Buffer

variable lodge  \ buffer address
variable /lodge  \ length in address units
0 /lodge !  \ [only for compatibility; Gforth doesn't need it]

0 allocate throw lodge !  \ an empty buffer at first

: lodge+  ( +n -- a )
  \ Current absolute address of a lodge offset.
  lodge @ +
  ;
: lodge-update  ( u a -- +n )
  \ u = additional address units already allocated in the lodge
  \ a = new address of the lodge
  \ +n = offset to the new free space
  \      (it's the same than the previous length of the lodge)
  lodge !  /lodge @  swap /lodge +!
  ;
: lodge-resize  ( u -- +n wior )
  \ u = new size of the lodge
  \ +n = lodge offset to the additional free space
  lodge @ swap resize >r lodge-update r>
  ;
: lodge-allocate  ( u -- +n wior )
  \ u = additional address units required in the lodge
  \ +n = lodge offset to the additional free space
  dup /lodge @ + lodge-resize
  ;
: (lodge-erase)  ( u +n -- )
  \ Erase u address units from a lodge offset.
  lodge+ swap erase
  ;
: lodge-erase  ( +n u -- )
  \ Erase u address units from a lodge offset.
  swap (lodge-erase)
  ;

\ --------------------------------------------------------------
\ Variables

: lodge-variable-does>  ( -- a )
  \ Behaviour of a lodge variable.
  does> ( -- a ) ( dfa ) @ lodge+
  ;
: (lodge-variable)  ( u -- )
  \ Compile a lodge variable of u address units.
  dup lodge-allocate throw dup , (lodge-erase)
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
  lodge-allocate throw dup , lodge+
  ;
: (cell-lodge-value:)  ( x "name" -- )
  \ Create a 1-cell lodge value.
  create  cell (lodge-value) !
  ;
: lodge-value  ( n "name" -- )
  \ Create a lodge value.
  (cell-lodge-value:)  does> ( -- n ) ( dfa ) @ lodge+ @
  ;
: lodge-address-value  ( +n "name" -- )
  \ Create a lodge address value.
  \ +n = lodge offset
  \ This kind of lodge-value stores a lodge offset but returns the
  \ corresponding absolute address.  This is useful for creating
  \ lodge-values that point to data space in the lodge but have to be
  \ used as ordinary Forth values.
  (cell-lodge-value:)  does> ( -- a ) ( dfa ) @ lodge+ @ lodge+
  ;
: lodge-2value  ( d "name" -- )
  \ Create a lodge value.
  create 2 cells (lodge-value) 2!
  does> ( -- d ) ( dfa ) @ lodge+ 2@
  ;

\ --------------------------------------------------------------
\ To

: xt>lodge  ( xt -- a )
  \ Absolute lodge address from the xt of a lodge-variable or a
  \ lodge-value.
  >body @ lodge+
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
