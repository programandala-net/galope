\ galope/module.fs
\ A Gforth implementation of the SP-Forth's modules

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013,2014,2015,2016

\ ==============================================================
\ Licence

\ You may do whatever you want with this work, so long as you
\ retain the copyright/authorship/acknowledgment/credit
\ notice(s) and this license in all redistributed copies and
\ derived works.  There is no warranty.

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
\ History

\ 2012-04-17: First version.
\
\ 2012-09-14: Code and comments reformated.
\
\ 2013-06-02: New stack comments.
\
\ 2014-02-18: 'set-wordlist' is moved to its own file.
\
\ 2014-02-18: 'do-latest' is renamed to 'execute-latest' and
\ moved to its own file.
\
\ 2014-02-18: Fix: 'vocs' and 'order' crashed in unclear
\ conditions.  These changes were made: 'vocabulary' and
\ 'definitions' were removed; 'wordlist' was used instead; the
\ code was factored and rewritten in orden to make sure the
\ wordlists are restored at the end of any created module and at
\ the end of this file too. Solved.
\
\ 2014-11-17: Module name and comments updated. Original
\ SP-Forth credits added.
\
\ 2015-09-28: GPL header.
\
\ 2015-10-26: Removed old requirements.
\
\ 2015-11-09: Fix: module names were created in the module
\ wordlist!  Now `(module:)` does not executes `set-current`.
\ `module:` and `:module` execute `hide` instead. This bug was
\ discovered during the conversion to Solo Forth.
\
\ 2016-01-16: Updated header, license and layout.

\ ==============================================================
\ Usage

0 [if]

Modules hide the internal implementation and leave visible the
words of the outer interface. Example:

module: my-module
  \ Inner/helper words.
export
  \ Interface words,
  \ compiled in the outer vocabulary,
  \ thus seen from the extern.
hide
  \ inner/helper words again.
export
  \ Interface words again. And so on.
;module

as an alternative, the word ':module' starts an unnamed module.

[then]

\ ==============================================================
\ Inner words

get-order get-current

wordlist  dup constant galope-module-module
          dup set-current  >order

variable current-wid
variable module-wid

: (module:)  ( "name" -- wid )
  get-current current-wid !
  wordlist dup module-wid ! dup >order  ;

set-current

\ ==============================================================
\ Interface words

: export  ( -- )
  current-wid @ set-current  ;
  \ Public definitions follow.

: hide  ( -- )
  module-wid @ set-current  ;
  \ Hidden definitions follow.

: module:  ( "name" -- )
  (module:) constant hide  ;
  \ Start a named module.

: :module  ( -- )
  (module:) drop hide  ;
  \ Start an anonymous module.
  \ Hidden definitions follow.

: ;module  ( -- )
  export previous  ;
  \ End a module.
  \ Hidden definitions follow.

set-order
