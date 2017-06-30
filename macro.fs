\ galope/macro.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-05-06 Added.

\ 'macro' was created by Wil Baden.

[undefined] macro [if]
  : macro  ( "name <char> ccc<char>" -- )
    : char parse  postpone sliteral  postpone evaluate
    postpone ; immediate
    ;
[then]

