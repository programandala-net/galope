\ galope/three-dup.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ ==============================================================

false [if]  \ first version, deprecated

  \ Taken from ToolBelt 2002 by Wil Baden.

  require third.fs

  : 3dup ( x1 x2 x3 -- x1 x2 x3 x1 x2 x3 ) third third third ;
    \  Copy top three elements on the stack onto top of stack.

[else]

  \ Taken from Brad Nelson's Literate Forth
  \ http://bradn123.github.io/literateforth/out/literate_0003.html

  : 3dup ( x1 x2 x3 -- x1 x2 x3 x1 x2 x3 ) dup 2over rot ;

[then]

\ ==============================================================
\ Change log

\ 2012-12-04 First version; code by Wil Baden.
\
\ 2013-07-05 Second version; code by Brad Nelson.
\
\ 2017-08-17: Update change log layout. Update header and source
\ style.
