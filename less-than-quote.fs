\ galope/less-than-quote.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014.

\ ==============================================================

require ./heredoc.fs

: <" ( "text <double-quote><greater>" -- ca len )
  s\" \">" (heredoc) save-mem ;
  \ Read text from the input stream until '">' is found.

\ ==============================================================
\ Change log

\ 2014-02-13 Modifed from the word '<"', written by the same author in
\
\ 2013 for a text game.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
