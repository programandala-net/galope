\ galope/thens.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Authors:
\ Wil Baden, 2002.
\ Marcos Cruz (programandala.net), 2017.

\ Credit of the `cond thens` structure:
\
\ Subject: Re: Multiple WHILE's
\ From: Wil Baden <neil...@earthlink.net>
\ Newsgroups: comp.lang.forth
\ Message-ID: <260620020959020469%neilbawd@earthlink.net>
\ Date: Wed, 26 Jun 2002 16:58:18 GMT

\ ==============================================================

: thens
  \ Compilation: ( C: 0 orig#1 .. orig#n -- )
  \ Run-time:    ( -- )
  begin ?dup while postpone then repeat
  ; immediate compile-only

  \ doc{
  \
  \ thens Compilation: ( C: 0 orig#1 .. orig#n -- ) Run-time:    ( --
  \ )
  \
  \ Resolve all forward references _orig#1 .. orign#n_ with ``then``
  \ until _0_ is found.
  \
  \ ``thens`` is an ``immediate`` and ``compile-only`` word.
  \
  \ ``thens`` is part of the `cond` .. ``thens`` structure.

  \ }doc

  \ Credit of the `cond thens` structure:
  \
  \ Subject: Re: Multiple WHILE's
  \ From: Wil Baden <neil...@earthlink.net>
  \ Newsgroups: comp.lang.forth
  \ Message-ID: <260620020959020469%neilbawd@earthlink.net>
  \ Date: Wed, 26 Jun 2002 16:58:18 GMT

\ ==============================================================
\ Change log

\ 2017-12-02: Copy from Solo Forth
\ (http://programandala.net/en.program.solo_forth.html).
