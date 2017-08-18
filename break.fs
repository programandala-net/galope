\ galope/break.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ ==============================================================
\ Authors

\ Code adapted from CP/M DX-Forth 4.09 to Galope by Marcos Cruz
\ (programandala.net), 2015, 2016, 2017.
\
\ CP/M DX-Forth 4.09 by Ed (http://dxforth.netbay.com.au;
\ http://dxforth.mirrors.minimaltype.com), 2014.
\
\ The DX-Forth code was adapted from Frank Seuberling's code
\ (1981-05-04) published in Forth Dimensions (volume 5, number 1,
\ 1983-05, page 19). <http://forth.org/fd/FDcover.html>.

\ ==============================================================

require ./package.fs

package galope-break

variable depth-backup

80 constant /debug-pad

create debug-pad  /debug-pad allot

: debug ( -- )
  begin debug-pad dup /debug-pad accept
        evaluate ."  [ok]" cr
  again ;

here constant resume

public

: break ( -- )
  cr ." [Break point. Type `go` to resume.]" cr .s
  depth depth-backup !
  ['] debug catch dup resume <> if throw else drop then ;

  \ doc{
  \
  \ break ( -- )
  \
  \ Halt the application to debug it.
  \
  \ ``break`` is inserted into the application source code at the point to
  \ be debugged.  When ``break`` is subsequently executed, the application
  \ is temporarily halted and the current stack contents displayed.  The
  \ user will then be in a special interpret loop (indicated by the
  \ "[ok]" prompt) during which time the system may be examined.  The
  \ application can be resumed at any time using 'go'.

  \ Executing 'quit' or 'abort' while halted (e.g. as a result of
  \ mistyping a command) will result in the user dropping back to forth.
  \
  \ }doc

: go ( -- )
  depth depth-backup @ <> abort" stack changed"
  resume throw ;

  \ doc{
  \
  \ go ( -- )
  \
  \ Resume the application halted by `break`.
  \
  \ See: `break`.
  \
  \ }doc

end-package

\ ==============================================================
\ Change log

\ 2015-02-03: Start.
\
\ 2016-06-23: Rename the module.
\
\ 2017-08-18: Use `package` instead of `module:`. Update the change
\ log layout. Update source style. Improve credits. Document. Make the
\ throw value standard.
