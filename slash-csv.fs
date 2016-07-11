\ galope/slash-csv.fs
\ `/csv`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013.

\ ==============================================================

require ./slash-sides.fs  \ '/sides'

: /csv  ( ca len -- ca#1 len#1 ... ca#n len#n n )
  depth >r
  begin  s" ," /sides 0=  until  2drop
  depth r> 2 - - 2/  ;
  \ Split a comma separated values string _ca len_ into value strings
  \ _ca#1 len#1 ... ca#n len#n_, and returning the number of resulting
  \ strings _n_.

\ ==============================================================
\ History

\ 2013-11-11: Move from Fendo
\ (http://programandala.net/en.program.fendo.html).
\
\ 2014-11-29: Add comments.
\
\ 2016-07-11: Update source layout and file header. Move the
\ unfinished draft of a variant (which removes side spaces and ignores
\ empty results) to the drafts directory.
