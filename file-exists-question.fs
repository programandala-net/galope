\ galope/file-exists-question.fs
\ file-exists?

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2015, 2017.

\ ==============================================================

: file-exists? ( ca len -- f ) file-status -514 <> nip ;
  \ Does filename _ca len_ exists?

\ ==============================================================
\ Change log

\ 2015-02-01: First version.
\
\ 2017-06-25: Update source style.
\
\ 2017-08-17: Update change log layout and source style.
