\ galope/module.fs
\ A Gforth implementation of the SP-Forth's modules

\ This file is part of Galope

\ Copyright (C) 2012,2013,214 Marcos Cruz (programandala.net)

\ This code was inspired by, and partly based on:
\
\   Forth system: SP-Forth (version 4.20)
\   URL:          http://spf.sourceforge.net
\   File:         <src/compiler/spf_modules.f>
\   File header:
\     $Id: spf_modules.f,v 1.7 2006/12/04 21:15:59 ygreks Exp $
\     Working with forth modules
\     Copyright (C) 2000 D.Yakimov day AT forth DOT org DOT ru
\   License:
\     You can modify and/or redistribute the core SP-Forth system
\     (i.e.  all files in src) under the terms of GNU GPL
\     [http://www.fsf.org/licensing/licenses/gpl.html] as published by
\     FSF [http://www.fsf.org/]. All other files, including
\     contrubuted code in devel, are licensed under [22]GNU LGPL by
\     default (if not stated otherwise).

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ History

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

wordlist  dup constant galope_module_module  dup set-current  >order

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
  \ Hidden definitions follow.
  module-wid @ set-current  
  ;
: ;module  ( -- )
  \ End a module.
  export previous
  ;

set-order
