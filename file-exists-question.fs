\ galope/file-exists-question.fs
\ file-exists?

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2015,2017 Marcos Cruz (programandala.net)

\ 2015-02-01: First version.
\ 2017-06-25: Update source style.

: file-exists? ( ca len -- f )
  file-status -514 <> nip ;
  \ Does filename _ca len_ exists?
