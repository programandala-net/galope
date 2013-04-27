\ galope/module.fs
\ A Gforth implementation of the SP-Forth's modules

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-04-17 First version.
\ 2012-09-14 Code and comments reformated.

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Usage

(

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

)

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Inner

get-current  ( wid )
vocabulary galope_module also galope_module definitions

: set-wordlist ( wid -- )
  \ Replace the wordlist on the top of the search list.
  \ Code from Gforth's compat/vocabulary.fs (public domain).
  >r get-order
  dup 0= -50 and throw \ Search-order underflow?
  nip r> swap  set-order
  ;
variable current-wid  \ Backup of the current wordlist.
: save-current  get-current current-wid !  ;
variable module-wid  \ Module wordlist.
: do-latest
  \ Execute the interpretation semantics of the latest word created.
  latest name>int execute 
  ;

( wid ) set-current \ Restore original (i.e., public) compilation wordlist.

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Outer

: module:  ( "name" -- )
  \ Start a module and create a named wordlist (a vocabulary) for it.
  save-current vocabulary also do-latest definitions
  ;
: :module
  \ Start a module and create a wordlist for it.
  save-current wordlist dup module-wid ! set-wordlist definitions
  ;
: export  current-wid @ set-current  ;
' definitions alias hide
' previous alias ;module

previous \ Restore original search order (inner words become invisible).
