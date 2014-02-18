\ galope/module.fs
\ A Gforth implementation of the SP-Forth's modules

\ This file is part of Galope

\ Copyright (C) 2012,2013,214 Marcos Cruz (programandala.net)

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ History

\ 2012-04-17: First version.

\ 2012-09-14: Code and comments reformated.

\ 2013-06-02: New stack comments. 

\ 2014-02-18: 'set-wordlist' is moved to its own file.

\ 2014-02-18: 'do-latest' is renamed to 'execute-latest' and moved to
\ its own file.

\ 2014-02-18: Fix: 'vocs' and 'order' crashed in unclear conditions.
\ These changes were made: 'vocabulary' and 'definitions' were
\ removed; 'wordlist' was used instead; the code was factored and
\ rewritten in orden to make sure the wordlists are restored at the
\ end of any created module and at the end of this file too. Solved.

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Requirements

require ./set-wordlist.fs
require ./execute-latest.fs

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Usage

0 [if]

Modules hide the internal implementation and leave visible the
words of the outer interface. Example:

MODULE: my_module
  \ Inner/helper words.
EXPORT
  \ Interface words,
  \ compiled to the outer vocabulary,
  \ thus seen from the extern.
HIDE
  \ Inner/helper words again.
EXPORT
  \ Interface words again. And so on.
;MODULE

As an alternative, the word ':module' starts an unnamed module.

[then]

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Inner words

get-order get-current

wordlist  dup constant galope_module  dup set-current  >order

variable current-wid
variable module-wid

: (module:)  ( "name" -- wid )
  get-current current-wid !
  wordlist dup module-wid ! dup >order dup set-current
  ;

set-current

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Interface words

: module:  ( "name" -- )
  \ Start a named module.
  (module:) constant
  ;
: :module  ( -- )
  \ Start an anonymous module.
  (module:) drop
  ;
: export  ( -- )
  \ Public definitions follow.
  current-wid @ set-current
  ;
: hide  ( -- )
  \ Module definitions follow.
  module-wid @ set-current  
  ;
: ;module  ( -- )
  \ End a moduel.
  export previous
  ;

set-order
