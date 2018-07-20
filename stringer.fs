\ galope/stringer.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016, 2017, 2018.

\ Description: A configurable circular string buffer.

\ ==============================================================

require ./package.fs
require ./smove.fs

package galope-stringer

public

variable unused-stringer ( -- a )

  \ doc{
  \
  \ unused-stringer ( -- a )
  \
  \ _a_ is the address of a cell containing the number of free
  \ characters in the `stringer`.
  \
  \ See: `/stringer`.
  \
  \ }doc

0 value stringer ( -- a )

  \ doc{
  \
  \ stringer ( -- a )
  \
  \ _a_ is the address of the stringer, which can be created by
  \ `allocate-stringer` or `set-stringer`.
  \
  \ See: `/stringer`, `unused-stringer`.
  \
  \ }doc

0 value /stringer ( -- len )

  \ doc{
  \
  \ /stringer ( -- len )
  \
  \ _len_ is the size of the `stringer` in address units.
  \
  \ See: `unused-stringer`.
  \
  \ }doc

private

: unavailable-stringer? ( len -- f ) unused-stringer @ > ;
  \ Are _len_ address units more than the current unused stringer?

: restart-stringer ( -- ) /stringer unused-stringer ! ;
  \ Restart the stringer to its maximum capacity.

: ?restart-stringer ( len -- )
  unavailable-stringer? if restart-stringer then ;
  \ If _len_ address units are more than the current unused stringer,
  \ restart it to its maximum capacity.

: used-stringer ( len -- ) negate unused-stringer +! ;
  \ Note _len_ address units have been used in the stringer.

: use-stringer ( len -- ) dup ?restart-stringer used-stringer ;
  \ Use _len_ address units from the stringer.

: stringer-pointer ( -- ca ) stringer unused-stringer @ + ;
  \ Return the address _ca_ of the stringer pointer.

public

: set-stringer ( ca len -- )
  to /stringer to stringer restart-stringer ;

  \ doc{
  \
  \ set-stringer ( ca len -- )
  \
  \ Set the `stringer` to use memory zone _ca len_, being _len_ the
  \ size in address units.
  \
  \ NOTE: The previous space of the `stringer`, if any, is not freed
  \ by `free-stringer`.
  \
  \ See: `allocate-stringer`.
  \
  \ }doc

: free-stringer ( -- ) stringer free throw 0 to stringer ;

  \ doc{
  \
  \ free-stringer ( -- )
  \
  \ Free the allocated data space used by the `stringer`, which should
  \ had been created by `allocate-stringer`.
  \
  \ See: `resize-stringer`.
  \
  \ }doc

: resize-stringer ( len -- )
  dup stringer swap resize throw swap set-stringer ;

  \ doc{
  \
  \ resize-stringer ( len -- )
  \
  \ Resize the allocated data space used by `stringer`, which should
  \ had been created by `allocate-stringer`, setting its size to _len_
  \ address units.
  \
  \ See: `free-stringer`.
  \
  \ }doc

: allocate-stringer ( len -- )
  free-stringer dup allocate throw swap set-stringer ;

  \ doc{
  \
  \ allocate-stringer ( len -- )
  \
  \ Create a `stringer` in the heap. _len_ is the size in address
  \ units.
  \
  \ As an alternative, a `stringer` can be created by `set-stringer`
  \ using any memory zone reserved by the application.
  \
  \ See: `resize-stringer`, `free-stringer`.
  \
  \ }doc

: allocate-in-stringer ( len -- ca ) use-stringer stringer-pointer ;

  \ doc{
  \
  \ allocate-in-stringer ( len -- ca )
  \
  \ Allocate _len_ address units in the `stringer`, returning the
  \ address _ca_ of the allocated space.
  \
  \ See: `>stringer`.
  \
  \ }doc

: >stringer ( ca1 len -- ca2 len )
  dup allocate-in-stringer 2dup 2>r smove 2r> swap ;

  \ doc{
  \
  \ >stringer ( ca1 len -- ca2 len )
  \
  \ Copy string _ca1 len_ to the `stringer`, returning it as _ca2
  \ len_.
  \
  \ See: `allocate-in-stringer`.
  \
  \ }doc

end-package

\ ==============================================================
\ Change log

\ 2016-07-19: Write, based on the deprecated module <sb.fs>.
\
\ 2017-11-08: Use `package` to hide the private words.  Rename
\ `init-stringer` `set-stringer` and reverse the order of their
\ parameters. Remove private factors `(free-stringer)` and
\ `(>stringer)`, which were used only once. Move useless
\ `allocate-stringer` into `create-stringer`, then rename
\ `create-stringer` `allocate-stringer`, making the public interface
\ clearer. Remove useless `chars`. Improve documentation.
\
\ 2018-07-20: Remove the check from `free-stringer`. Rename
\ `allocate-ss` `allocate-in-stringer`.
