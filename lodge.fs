\ galope/lodge.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html
\
\ Last modified 201707031346.
\ See change log at the end of the file.

\ Copyright (C) 2014,2017 Marcos Cruz (programandala.net)

\ ==============================================================
\ Description

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

\ ==============================================================
\ Buffer

variable lodge
  \ Buffer address.

variable /lodge  0 /lodge !
  \ Length in address units.

0 allocate throw lodge ! \ an empty buffer at first

: lodge+ ( +n -- a )
  lodge @ + ;
  \ Return current absolute address _a_ of a lodge offset _+n_.

: lodge-update ( u a -- +n )
  lodge !  /lodge @  swap /lodge +! ;
  \ u = additional address units already allocated in the lodge
  \ a = new address of the lodge
  \ +n = offset to the new free space
  \      (it's the same than the previous length of the lodge)

: lodge-resize ( u -- +n wior )
  lodge @ swap resize >r lodge-update r> ;
  \ u = new size of the lodge
  \ +n = lodge offset to the additional free space

: lodge-allocate ( u -- +n wior )
  dup /lodge @ + lodge-resize ;
  \ u = additional address units required in the lodge
  \ +n = lodge offset to the additional free space

: (lodge-erase) ( u +n -- )
  lodge+ swap erase ;
  \ Erase _u_ address units from a lodge offset.

: lodge-erase ( +n u -- )
  swap (lodge-erase) ;
  \ Erase _u_ address units from a lodge offset.

\ ==============================================================
\ Variables

: lodge-variable-does> ( -- a )
  does> ( -- a ) ( dfa ) @ lodge+ ;
  \ Behaviour of a lodge variable.

: (lodge-variable) ( u -- )
  dup lodge-allocate throw dup , (lodge-erase) ;
  \ Compile a lodge variable of _u_ address units.

: lodge-variable ( "name" -- )
  create cell (lodge-variable) lodge-variable-does> ;
  \ Create a lodge variable and init it with zero.

: lodge-2variable ( "name" -- )
  create 2 cells (lodge-variable) lodge-variable-does> ;
  \ Create a lodge double variable and init it with zero.

\ ==============================================================
\ Values

: (lodge-value) ( u -- a )
  lodge-allocate throw dup , lodge+ ;
  \ Compile a lodge value of _u_ address units.

: (cell-lodge-value:) ( x "name" -- )
  create  cell (lodge-value) ! ;
  \ Create a 1-cell lodge value.

: lodge-value ( n "name" -- )
  (cell-lodge-value:)  does> ( -- n ) ( dfa ) @ lodge+ @ ;
  \ Create a lodge value.

: lodge-address-value ( +n "name" -- )
  (cell-lodge-value:)  does> ( -- a ) ( dfa ) @ lodge+ @ lodge+ ;
  \ Create a lodge address value.
  \
  \ +n = lodge offset
  \
  \ This kind of lodge-value stores a lodge offset but returns the
  \ corresponding absolute address.  This is useful for creating
  \ lodge-values that point to data space in the lodge but have to be
  \ used as ordinary Forth values.

: lodge-2value ( d "name" -- )
  create 2 cells (lodge-value) 2!
  does> ( -- d ) ( dfa ) @ lodge+ 2@ ;
  \ Create a lodge value.

\ ==============================================================
\ To

: xt>lodge ( xt -- a )
  >body @ lodge+ ;
  \ Return absolute lodge address _a_ from the _xt_ of a
  \ lodge-variable or a lodge-value.

: <lodge-to> ( x "name" -- )
  ' xt>lodge ! ;
  \ Change the content of a lodge-variable or a lodge-value.

: [lodge-to] ( compilation: x "name" -- )
  ' postpone literal postpone xt>lodge postpone ! ; immediate
  \ Change the content of a lodge-variable or a lodge-value.

' <lodge-to>
' [lodge-to]
interpret/compile: lodge-to

: <lodge-2to> ( x "name" -- )
  ' xt>lodge 2! ;
  \ Change the content of a lodge-2variable or a lodge-2value.

: [lodge-2to] ( compilation: d "name" -- )
  ' xt>lodge postpone 2literal postpone 2! ; immediate
  \ Change the content of a lodge-2variable or a lodge-2value.

' <lodge-2to>
' [lodge-2to]
interpret/compile: lodge-2to

\ ==============================================================
\ Misc

: lodge-save-mem ( a1 len -- +n len )
  swap >r  dup lodge-allocate throw  swap over lodge+ over
  r> -rot move ;
  \ Copy a memory block into the lodge.
  \ Written after Gforth's `save-mem`.

: lodge-, ( x -- )
  cell lodge-allocate throw lodge+ ! ;
  \ "Compile" _x_ into the current lodge.

: lodge-2, ( x1 x2 -- )
  2 cells lodge-allocate throw lodge+ 2! ;
  \ "Compile" _x1 x2_ into the current lodge.

\ ==============================================================
\ Change log

\ 2014-02-16 Written for Finto
\ (http://programandala.net/en.program.finto.html).
\
\ 2014-02-17 New: `lodge-value`, `lodge-to` and related words.
\
\ 2014-02-19 New: `lodge-address-value`.
\
\ 2014-02-20 Change: "index" and "relative pointer" corrected to
\ "offset" in the comments; additional comment in
\ `lodge-address-value`; `(cell-lodge-value:)` factored out from
\ `lodge-value` and `lodge-address-value`; `>lodge` renamed to
\ `lodge+`.  2014-02-20 New: `lodge-save-mem`.
\
\ 2014-02-21 Fix: `[lodge-to]` and `[lodge-2to]` were wrong.
\
\  `[lodge-to]`, before the fix:
\
\     ' postpone xt>lodge postpone literal postpone !
\
\  First bug: `xt>lodge` should not be postponed in this case.
\  Second bug: the absolute lodge address must not be compiled,
\  because it may change.
\
\   After the fix:
\
\     ' postpone literal postpone xt>lodge postpone !
\
\ Now the xt is compiled and the lodge address is calculated at
\ run-time.
\
\ 2014-02-21: Forked to <galope/lodge-colon.fs>.
\
\ 2014-02-21: New: `lodge-,` and `lodge-2,`.
\
\ 2014-02-21: Fix: `lodge-resize` now can be used directly by
\ the application. Solved by moving the trailing code of
\ `lodge-allocate` to `lodge-resize`.
\
\ 2017-07-03: Update code style. Improve documentation.

