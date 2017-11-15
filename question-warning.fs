\ galope/question-warning.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

[undefined] ?warning [if]

  : ?warning ( f xt -- ) swap 0<> warnings @ 0<> and
                         if   ." warning: " execute
                         else drop then ;

  \ doc{
  \
  \ ?warning ( f xt -- )
  \
  \ If _f_ is non-zero and ``warnings`` is non-zero, execute _xt_,
  \ which is supposed to display a warning; otherwise remove _xt_ from
  \ the stack.
  \
  \ ``?warning`` is provided by Gforth 0.7.9. This module provides a
  \ simpler version for backward compatibility. If ``?warning`` is
  \ already defined, this modules does nothing.
  \
  \ See: `warning(`.
  \
  \ }doc

[then]

\ ==============================================================
\ Change log

\ 2017-11-15: Start.
