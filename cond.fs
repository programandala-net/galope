\ galope/cond.fs

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

0 constant cond immediate compile-only

  \ doc{
  \
  \ cond
  \   Compilation: ( C: -- 0 )
  \   Run-time:    ( -- )

  \
  \ Compilation: Mark the start of a ``cond`` .. `thens`
  \ structure.  Leave _0_ on the control-flow stack, as a mark
  \ for `thens`.
  \
  \ Run-time: Continue execution.
  \
  \ ``cond`` is an ``immediate`` and ``compile-only`` word.
  \
  \ Usage example:

  \ ----
  \ : test ( x -- )
  \   cond
  \     test1 if action1 else
  \     test2 if action2 else
  \     test3 if action3 else
  \     default-action
  \   thens ;
  \ ----

  \ ``cond`` and `thens` may be used also to resolve all additional
  \ ``while`` of a ``begin`` structure, instead of adding all the
  \ corresponding ``then`` at the end, this way:

  \ ----
  \ : test ( x -- )
  \   cond begin
  \     while action1
  \     while action2
  \     while action3
  \     while action4
  \     while action5
  \   repeat thens ;
  \ ----

  \ }doc

\ ==============================================================
\ Change log

\ 2017-12-02: Copy from Solo Forth
\ (http://programandala.net/en.program.solo_forth.html).
\
\ 2017-12-03: Improve documentation.
