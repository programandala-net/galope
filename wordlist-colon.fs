\ galope/wordlist-colon.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author:
\   Marcos Cruz (programandala.net), 2017

\ Credit:
\   Idea taken from:
\   Julian Fondren, 2016.
\   http://forth.minimaltype.com/packages.html

\ ==============================================================

false [if]

  \ Original version
  \ from http://forth.minimaltype.com/packages.html:

: wordlist: ( "name" -- wid )
  >in @ vocabulary dup >in ! also ' execute
  get-order swap >r 1- set-order r>
  swap >in ! dup constant ;

  \ Modified to prevent warnings:

: wordlist: ( "name" -- wid )
  warnings @ >r warnings off
  >in @ vocabulary dup >in ! also ' execute
  get-order swap >r 1- set-order r>
  swap >in ! dup constant
  r> warnings ! ;

  \ Simplified a bit, with Gforth's `latestxt`:

: wordlist: ( "name" -- wid )
  warnings @ >r warnings off
  >in @ vocabulary also latestxt execute
  get-order swap >r 1- set-order r>
  swap >in ! dup constant
  r> warnings ! ;

[else]

: wordlist: ( "name" -- wid ) wordlist dup constant ;

[then]

  \ doc{
  \
  \ wordlist: ( "name" -- wid )
  \
  \ Create a named word list _name_ identified by _wid_. Later
  \ execution of _name_ will return _wid_.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-08-16: Start. Copy from Julian Fondren's package
\ (http://forth.minimaltype.com/packages.html).
\
\ 2017-08-17: Rewrite, much simpler. Document.
