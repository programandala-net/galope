\ galope/break.fs
\ This file is part of Galope

\ 2015-02-03
\ 2016-06-23: Rename the module.

\ Adapted from CP/M DX-Forth 4.09 (file <BREAKGO.SCR>).
\
\ The DX-Forth code was adapted from Frank Seuberling's code
\ (1981-05-04) published in Forth Dimensions (volume 5, number 1,
\ 1983-05, page 19).

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

\ BREAK GO

\ Breakpoint tool

\ 'break' is inserted into the application source code at the point to
\ be debugged.  When 'break' is subsequently executed, the application
\ is temporarily halted and the current stack contents displayed.  The
\ user will then be in a special interpret loop (indicated by the
\ '[ok]' prompt) during which time the system may be examined.  The
\ application can be resumed at any time using 'go'.

\ Executing 'quit' or 'abort' while halted (e.g. as a result of
\ mistyping a command) will result in the user dropping back to forth.

require ./module.fs

module: galope-break-module

variable depth-backup
create debug-pad  80 allot

: debug  ( -- )
  begin  debug-pad dup 80 accept evaluate ."  [ok]" cr  again
  ;

export

: break ( i*x -- i*x )
  \ Halt the application.
  cr ." [Break point. Type 'go' to resume.]" cr .s
  depth depth-backup !
  ['] debug catch dup -256 - if  throw  else  drop  then
  ;

: go ( i*x -- i*y )
  \ Resume the application.
  depth depth-backup @ -
  depth-backup off  \ XXX needed?
  abort" stack changed" -256 throw
  ;

;module
