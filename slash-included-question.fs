\ galope/slash-included-question.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ History
\ 2014-03-24: Written after Gforth's 'included?', that matches only
\ exact paths. Sometimes exact paths are inconvenient because you
\ don't know where the file was actually loaded from.

require ./string-suffix-question.fs

: /included? ( ca len -- wf )
  \ True only if the file ca len is the end of an earlier
  \ included file.
  \ Contrary to Gforth's 'included?' this word makes it possible to
  \ check for specific files, with partial or none path, no matter
  \ where it actually was downloaded from.
  \ In order to prevent name clashes, a slash is recommended before
  \ the file name:
  \     s" /my_known_specific_file.fs" /included?
  \     s" /here/my_other_known_specific_file.fs" /included?
  included-files 2@ 0
  ?do ( ca len a )
    dup >r 2@ 2over string-suffix?
    if  2drop rdrop unloop true exit  then
    r> cell+ cell+
  loop  2drop drop false
  ;
