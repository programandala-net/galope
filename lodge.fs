\ galope/lodge.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================
\ Description

\ This code provides words that create variables, values or any
\ kind of data whose actual data are stored into a self-growing
\ buffer. The variables and values store in their own body an
\ offset to the actual data in the buffer.  This makes it
\ possible to save the whole buffer to a binary file and
\ restore it later (e.g. for game sessions), even if the actual
\ absolute address of the buffer changes.

\ ==============================================================
\ Lodge

variable lodge  0 allocate throw lodge !

  \ doc{
  \
  \ lodge ( -- a )
  \
  \ _a_ is the address of a cell containig the address of the
  \ lodge.
  \
  \ See: `/lodge`.
  \
  \ }doc

variable /lodge  0 /lodge !

  \ doc{
  \
  \ /lodge ( -- a )
  \
  \ _a_ is the address of a cell containing the length of the
  \ `lodge` in address units.
  \
  \ See: `lodge-here`.
  \
  \ }doc

: lodge-here ( -- +n ) /lodge @ ;

  \ doc{
  \
  \ lodge-here ( -- +n )
  \
  \ Return the offset _+n_ of the next free available address
  \ of the `lodge`, which is its length contained in `/lodge`.
  \
  \ }doc

: lodge+ ( +n -- a ) lodge @ + ;

  \ doc{
  \
  \ lodge+ ( +n -- a )
  \
  \ Convert `lodge` offset _+n_ to its absolute address _a_.
  \
  \ Words created by `lodge-variable`, `lodge-2variable`,
  \ `lodge-value`, `lodge-2value` and `lodge-create` save in
  \ their dafa field address the current value returned by
  \ `lodge-here`, and convert it to the its corresponding
  \ `lodge` address at run-time.
  \
  \ }doc

: (lodge-resize) ( u a -- +n )
  lodge ! /lodge @  swap /lodge +! ;
  \ u  = additional address units already allocated in the lodge
  \ a  = new address of the lodge
  \ +n = offset to the new free space (it's the same than the
  \      previous length of the lodge)

: lodge-resize ( u -- +n ior )
  lodge @ swap resize >r (lodge-resize) r> ;

  \ doc{
  \
  \ lodge-resize ( u -- +n ior )
  \
  \ Resize the `lodge` to _u_ address units.  If the operation
  \ succeeds, _+n_ is the offset to the additional free space
  \ and _ior_ is zero.  If the operation fails, the value of
  \ _+n_ is unimportant and _ior_ in the corresponding I/O
  \ result code.
  \
  \ See: `lodge-allocate`.
  \
  \ }doc

: lodge-allocate ( n1 -- +n2 ior )
  dup /lodge @ + lodge-resize ;

  \ doc{
  \
  \ lodge-allocate ( n1 -- +n2 ior )
  \
  \ Allocate _n1_ additional address units in the `lodge`.  If
  \ the operation succeeds, _+n2_ is the offset to the
  \ additional free space and _ior_ is zero.  If the operation
  \ fails, the value of _+n_ is unimportant and _ior_ in the
  \ corresponding I/O result code.
  \
  \ See: `lodge-resize`, `lodge-allot`.
  \
  \ }doc

: lodge-allot ( n -- ) lodge-allocate throw drop ;

  \ doc{
  \
  \ lodge-allot ( n -- )
  \
  \ Add _n_ address units to the `lodge`.
  \
  \ See: `lodge-here`, `lodge-allocate`.
  \
  \ }doc

: body>lodge ( dfa -- a ) @ lodge+ ;

  \ doc{
  \
  \ body>lodge ( dfa -- a )
  \
  \ Convert the _dfa_ of a `lodge-variable`, `lodge-2variable`,
  \ `lodge-value`, `lodge-2value` or a word created by
  \ `lodge-create` to its absolute `lodge` address _a_.
  \
  \ See: `>lodge`, `lodge+`.
  \
  \ }doc

: >lodge ( xt -- a ) >body body>lodge ;

  \ doc{
  \
  \ >lodge ( xt -- a )
  \
  \ Convert the _xt_ of a `lodge-variable`, `lodge-2variable`,
  \ `lodge-value`, `lodge-2value` or a word created by
  \ `lodge-create` to its absolute `lodge` address _a_.
  \
  \ See: `body>lodge`.
  \
  \ }doc

\ ==============================================================
\ Variables

: (lodge-create) ( "name" -- ) create lodge-here , ;

: lodge-create ( "name" -- ) (lodge-create) does> body>lodge ;

  \ doc{
  \
  \ lodge-create ( "name" -- )
  \
  \ Create a definition for _name_. When _name_ is executed, it
  \ will return the next free address of the `lodge` when
  \ _name_ was created.
  \
  \ See: `lodge-here`, `body>lodge`.
  \
  \ }doc

: lodge-variable ( "name" -- ) lodge-create cell lodge-allot ;

  \ doc{
  \
  \ lodge-variable ( "name" -- )
  \
  \ Create a definition for _name_. When _name_ is executed, it
  \ will return the next free address of the `lodge` when
  \ _name_ was created, where a 1-cell data space was
  \ allocated.
  \
  \ See: `lodge-2variable`, `lodge-value`, `lodge-create`,
  \ `lodge-allot`.
  \
  \ }doc

: lodge-2variable ( "name" -- )
  lodge-create [ 2 cells ] literal lodge-allot ;

  \ doc{
  \
  \ lodge-2variable ( "name" -- )
  \
  \ Create a definition for _name_. When _name_ is executed, it
  \ will return the next free address of the `lodge` when
  \ _name_ was created, where a 2-cell data space was
  \ allocated.
  \
  \ See: `lodge-variable`, `lodge-2value`, `lodge-create`,
  \ `lodge-allot`.
  \
  \ }doc

\ ==============================================================
\ Values

: lodge-value ( x "name" -- )
  lodge-here (lodge-create)
  cell lodge-allot lodge+ !
  does> ( -- x ) ( dfa ) body>lodge @ ;

  \ doc{
  \
  \ lodge-value ( x "name" -- )
  \
  \ Create a definition for _name_. When _name_ is executed, it
  \ will return _x_, which was stored in the `lodge`.
  \
  \ See: `lodge-2value`, `lodge-variable`, `lodge-create`,
  \ `lodge-allot`.
  \
  \ }doc

: lodge-2value ( x1 x2 "name" -- )
  lodge-here (lodge-create)
  [ 2 cells ] literal lodge-allot lodge+ 2!
  does> ( -- x1 x2 ) ( dfa ) body>lodge 2@ ;
  \ Create a double-cell lodge value _name_.

  \ doc{
  \
  \ lodge-2value ( x1 x2 "name" -- )
  \
  \ Create a definition for _name_. When _name_ is executed, it
  \ will return _x1 x2_, which were stored in the `lodge`.
  \
  \ See: `lodge-value`, `lodge-2variable`, `lodge-create`,
  \ `lodge-allot`.
  \
  \ }doc

: <lodge-to> ( x "name" -- ) ' >lodge ! ;
  \ Store _x_ into a lodge-value _name_.

: [lodge-to] \ Compilation: ( x "name" -- )
  ' postpone literal postpone >lodge postpone ! ; immediate
  \ Compile the words needed to store _x_ into a lodge-value
  \ _name_.

' <lodge-to>
' [lodge-to]
interpret/compile: lodge-to \ Interpretation: ( x "name" -- )
                            \ Compilation: ( x "name" -- )

  \ doc{
  \
  \ lodge-to \ Interpretation: ( x "name" -- )
  \          \ Compilation: ( x "name" -- )
  \
  \ Store _x_ into a `lodge-value` _name_.
  \
  \ See: `lodge-2to`.
  \
  \ }doc

: <lodge-2to> ( x1 x2 "name" -- ) ' >lodge 2! ;
  \ Store the cell pair _x1 x2_ into a double-cell lodge-value
  \ _name_.

: [lodge-2to] \ Compilation: ( x1 x2 "name" -- )
  ' >lodge postpone 2literal postpone 2! ; immediate
  \ Compile the words needed to store the cell pair _x1 x2_
  \ into a double-cell lodge-value _name_.

' <lodge-2to>
' [lodge-2to]
interpret/compile: lodge-2to \ Interpretation: ( x1 x2 "name" -- )
                             \ Compilation: ( x1 x2 "name" -- )

  \ doc{
  \
  \ lodge-2to \ Interpretation: ( x1 x2 "name" -- )
  \           \ Compilation: ( x1 x2 "name" -- )
  \
  \ Store _x1 x2_ into a `lodge-2value` _name_.
  \
  \ See: `lodge-2to`.
  \
  \ }doc

\ ==============================================================
\ Misc

: lodge-save-mem ( a len -- +n len )
  swap >r dup lodge-allocate throw swap over lodge+ over
       r> -rot move ;

  \ doc{
  \
  \ lodge-save-mem ( a len -- +n len )
  \
  \ Add a memory zone _a len_ to the `lodge`, increasing its
  \ size accordingly and returning its offset _+n_ and the
  \ length _len_ of the zone.
  \
  \ See: `lodge-,`, `lodge-2,`, `lodge-allocate`.
  \
  \ }doc

: lodge-, ( x -- ) lodge-here cell lodge-allot lodge+ ! ;

  \ doc{
  \
  \ lodge-, ( x -- )
  \
  \ Add _x_ to the `lodge`, increasing its size by one cell.
  \
  \ See: `lodge-2,`, `lodge-save-mem`, `lodge-here`,
  \ `lodge-allot`.
  \
  \ }doc

: lodge-2, ( x1 x2 -- )
  lodge-here [ 2 cells ] literal lodge-allot lodge+ 2! ;

  \ doc{
  \
  \ lodge-2, ( x1 x2 -- )
  \
  \ Add the cell pair _x1 x2_ to the `lodge` increasing its
  \ size by two cells.
  \
  \ See: `lodge-,`, `lodge-save-mem`, `lodge-here`,
  \ `lodge-allot`.
  \
  \ }doc

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
\  First bug: `xt>lodge` should not be postponed in this case.  Second
\  bug: the absolute lodge address must not be compiled, because it
\  may change.
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
\ 2014-02-21: Fix: `lodge-resize` now can be used directly by the
\ application. Solved by moving the trailing code of `lodge-allocate`
\ to `lodge-resize`.
\
\ 2017-07-03: Update code style. Improve documentation.
\
\ 2017-08-21: Improve documentation and stack notation. Add the factor
\ `body>lodge`, after the `lodge:` module.
\
\ 2017-08-22: Prepare to supersed the `lodge:` module.
\
\ 2017-08-23: Factor. Add `lodge-here`, `lodge-allot` and
\ `lodge-create`, and rewrite other words after them, making the code
\ easier to follow.  Remove zero initialization of variables. Improve
\ documentation. Rename `xt>lodge` to `>lodge`.
