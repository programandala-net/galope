\ galope/stringer.fs
\ Circular string buffer

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016.

\ Description: A configurable circular string buffer that uses the
\ heap. Related modules: <s-s-quote.fs> and <s-s-plus.fs>.

\ ==============================================================

require ./smove.fs

variable unused-stringer  \ Free chars in the buffer

0 value stringer
  \ Address of the stringer.

0 value /stringer
  \ Size of the stringer in address units.

: unavailable-stringer?  ( len -- f )  unused-stringer @ >  ;
  \ Are _len_ chars more than the current unused stringer?

: restart-stringer  ( -- )  /stringer unused-stringer !  ;
  \ Restart the stringer to its maximum capacity.

: ?restart-stringer  ( len -- )
  unavailable-stringer? if   restart-stringer  then  ;
  \ If _len_ chars are more than the current unused stringer, restart
  \ it to its maximum capacity.

: used-stringer  ( len -- )  negate unused-stringer +!  ;
  \ Note _len_ chars have been used in the stringer.

: use-stringer  ( len -- )  dup ?restart-stringer used-stringer  ;
  \ Use _len_ chars from the stringer.

: init-stringer  ( len ca -- )
  to stringer to /stringer restart-stringer  ;
  \ Init a stringer at _ca_ for _len_ chars

: stringer-pointer  ( -- ca )  stringer unused-stringer @ +  ;

: (free-stringer)  ( -- )
  stringer free throw  0 to stringer  ;

: free-stringer  ( -- )
  stringer if  (free-stringer)  then   ;

: allocate-stringer  ( len -- )
  chars dup allocate throw init-stringer  ;

: resize-stringer  ( len -- )
  dup stringer swap resize throw init-stringer  ;

: create-stringer  ( len -- )
  free-stringer allocate-stringer  ;
  \ Create a string buffer in the heap.

: (>stringer)  ( ca1 len ca2 -- ca2 len )  2dup 2>r smove 2r> swap  ;
  \ Copy string _ca1 len_ to _ca2_, returning it as _ca2 len_.

: allocate-ss  ( len -- ca )  use-stringer stringer-pointer  ;
  \ Allocate _len_ chars in the stringer, returning the address _ca_
  \ of the allocated space.

: >stringer  ( ca1 len -- ca2 len )  dup allocate-ss (>stringer)  ;
  \ Copy string _ca1 len_ to the stringer, returning it as _ca2 len_.

\ ==============================================================
\ Change log

\ 2016-07-19: Write, based on the deprecated module <sb.fs>.
