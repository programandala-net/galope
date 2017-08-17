\ galope/empty.fs
\ `empty`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Authors:
\   Wil Baden, 2002 (from ToolBelt).
\   Marcos Cruz (programandala.net), 2012.

\ ==============================================================

require ./anew.fs

: empty ( -- )
  s" anew --empty-- decimal only forth definitions"
  evaluate ;
  \ Reset the dictionary to a predefined golden state, discarding all
  \ definitions and releasing all allocated data space beyond that
  \ state.  This `empty` uses  --empty--` to separate kernel words and
  \ user words.  Rename `--empty--` if you wish.  `marker --empty--`
  \ will setup a new golden area for `empty`.  `--empty--` will
  \ restore the previous golden area.

\ ==============================================================
\ Change log

\ 2012-05-18: Add to the library.
\
\ 2012-09-14: Reformat the code.
\
\ 2016-07-08: Update source layout and header.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
