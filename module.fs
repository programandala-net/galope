\ galope/module.fs
\ A Gforth implementation of the SP-Forth's modules

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2014, 2015, 2016,
\ 2017.

\ ==============================================================
\ Credit

\ This code was inspired by, and partly based on:
\
\   Forth system: SP-Forth (version 4.20)
\   URL:          http://spf.sourceforge.net
\   File:         <src/compiler/spf_modules.f>
\   File header:
\     $Id: spf_modules.f,v 1.7 2006/12/04 21:15:59 ygreks Exp $
\     Working with forth modules
\     Copyright (C) 2000 D.Yakimov day AT forth DOT org DOT ru
\   License: GNU GPL

\ ==============================================================

require ./warning-paren.fs

warnings @ [if]

  warning( `module` is deprecated, superseded by `package`)

[then]

\ ==============================================================
\ Inner words

get-order get-current

wordlist dup constant galope-module
         dup set-current >order

variable current-wid
variable module-wid

: (module:) ( "name" -- wid )
  get-current current-wid !
  wordlist dup module-wid ! dup >order ;

set-current

\ ==============================================================
\ Interface words

: export ( -- ) current-wid @ set-current ;

  \ doc{
  \
  \ export ( -- )
  \
  \ Public definitions follow in the current module started by
  \ `module:` or `:module`.
  \
  \ See: `hide`.
  \
  \ }doc

: hide ( -- ) module-wid @ set-current ;

  \ doc{
  \
  \ hide ( -- )
  \
  \ Hidden definitions follow in the current module started by
  \ `module:` or `:module`.
  \
  \ See: `export`.
  \
  \ }doc

: module: ( "name" -- ) (module:) constant hide ;

  \ doc{
  \
  \ module: ( "name" -- )
  \
  \ Start a named module _name_. Hidden definitions follow.
  \
  \ Modules hide the internal implementation and leave visible the
  \ words of the outer interface. Example:
  \
  \ ----

  \ module: my-module
  \   \ Inner/helper words.
  \ export
  \   \ Interface words,
  \   \ compiled in the outer vocabulary,
  \   \ thus seen from the extern.
  \ hide
  \   \ inner/helper words again.
  \ export
  \   \ Interface words again. And so on.
  \ ;module

  \ ----
  \
  \ As an alternative, the word `:module` starts an unnamed module.
  \
  \ NOTE: This implementation of `module:` is deprecated, superseded
  \ by `package`.
  \
  \ See: `export`, `hide`, `;module`, `package`.

  \ }doc

: :module ( -- ) (module:) drop hide ;

  \ doc{
  \
  \ :module ( -- )
  \
  \ Start an anonymous module.  Hidden definitions follow.
  \
  \ Modules hide the internal implementation and leave visible the
  \ words of the outer interface. Example:
  \
  \ ----

  \ :module
  \   \ Inner/helper words.
  \ export
  \   \ Interface words,
  \   \ compiled in the outer vocabulary,
  \   \ thus seen from the extern.
  \ hide
  \   \ inner/helper words again.
  \ export
  \   \ Interface words again. And so on.
  \ ;module

  \ ----
  \
  \ As an alternative, the word `module:` starts a named module.
  \
  \ NOTE: This implementation of `module` is deprecated, superseded by
  \ `package`.
  \
  \ See: `export`, `hide`, `;module`, `package`.

  \ }doc

: ;module ( -- ) export previous ;

  \ doc{
  \
  \ ;module ( -- )
  \
  \ End a module started by `module:` or `:module`.
  \
  \ }doc

set-order

\ ==============================================================
\ Change log

\ 2012-04-17: First version.
\
\ 2012-09-14: Code and comments reformated.
\
\ 2013-06-02: New stack comments.
\
\ 2014-02-18: 'set-wordlist' is moved to its own file.
\
\ 2014-02-18: 'do-latest' is renamed to 'execute-latest' and moved to
\ its own file.
\
\ 2014-02-18: Fix: 'vocs' and 'order' crashed in unclear conditions.
\ These changes were made: 'vocabulary' and 'definitions' were
\ removed; 'wordlist' was used instead; the code was factored and
\ rewritten in orden to make sure the wordlists are restored at the
\ end of any created module and at the end of this file too. Solved.
\
\ 2014-11-17: Module name and comments updated. Original SP-Forth
\ credits added.
\
\ 2015-09-28: GPL header.
\
\ 2015-10-26: Removed old requirements.
\
\ 2015-11-09: Fix: module names were created in the module wordlist!
\ Now `(module:)` does not executes `set-current`.  `module:` and
\ `:module` execute `hide` instead. This bug was discovered during the
\ conversion to Solo Forth.
\
\ 2016-01-16: Updated header, license and layout.
\
\ 2017-08-17: Update change log layout.
\
\ 2017-08-18: Deprecated. Superseded by `package`. Remove the
\ "-module" suffix from the module name, after the changes in the rest
\ of the modules, converted to `package`.
\
\ 2017-10-24: Improve documentation.
\
\ 2017-10-25: Improve documentation.
\
\ 2017-11-14: Add a warning about the deprecation.
\
\ 2017-11-22: Improve documentation.
