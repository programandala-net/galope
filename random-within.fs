\ galope/random-within.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Credit:
\
\ Code adapted from Robert Pfeiffer's forthsnake
\ (https://github.com/robertpfeiffer/forthsnake), 2009.

\ ==============================================================

require random.fs

: random-within ( n1 n2 -- n3 ) over - rnd swap mod + ;

  \ doc{
  \
  \ random-within ( n1 n2 -- n3 )
  \
  \ Return a random number _n3_ from _n1_ (minimum) to _n2-1_
  \ (maximum).
  \
  \ See: `random-between`, `randomize`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-22: Copy Serpentino's `random-range`
\ (http://programandala.net/en.program.serpentino.html).
\ Original code by Robert Pfeiffer, 2009, `myrand`:
\ <https://github.com/robertpfeiffer/forthsnake>. Rename.
\ Replace `utime +` with `rnd`.
\
\ 2017-11-24: Update documentation.
\
\ 2017-12-11: Update documentation.
