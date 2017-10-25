\ galope/package.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author:
\   Julian Fondren, 2016.
\   http://forth.minimaltype.com/packages.html
\   Newsgroups: comp.lang.forth
\   Date: Tue, 2 Aug 2016 04:00:38 -0700 (PDT)
\   Message-ID: <0a8d7b8a-8367-4e92-a482-ee8b6728325a@googlegroups.com>
\ Adapted to Galope:
\   Marcos Cruz (programandala.net), 2017.

\ ==============================================================

require ./minus-order.fs    \ `-order`
require ./plus-order.fs     \ `+order`
require ./wordlist-colon.fs \ `wordlist:`

: package ( "name" -- wid1 wid2 )
  get-current >in @ bl word find
  if   nip execute
  else drop >in !  wordlist:
  then dup set-current  dup +order ;

  \ doc{
  \
  \ package ( "name" -- wid1 wid2 )
  \
  \ If a package _name_ already exists, reuse it; otherwise define it.
  \ New definitions will be private to the package, until `public` or
  \ `end-package` are executed.
  \
  \ The word list identified by _wid1_ is the compilation word list
  \ before ``package`` was executed.  The word list identified by
  \ _wid2_ is the one associated to _name_, where the package
  \ `private` definitions will be defined.

  \ Usage example:

  \ ----
  \ package my-package
  \
  \ ... private definitions here ...
  \
  \ public
  \
  \ ... public definitions here ...
  \
  \ private
  \
  \ ... more private definitions maybe ...
  \
  \ end-package
  \ ----

  \ In the above, private definitions are placed in the ``my-package``
  \ word list.  Public definitions are placed in whatever word list
  \ was current before ``package my-package``, i.e _wid1_.  If a
  \ package ``my-package`` already exists prior to the above, then it
  \ is reused, rather than redefined.
  \
  \ Credit: ``package`` comes from SwiftForth. Versions for Gforth and
  \ other Forth systems were written by Julian Fondren.

  \ See: `public`, `private`, `end-package`, `module:`, `:module`.
  \
  \ }doc

: end-package ( wid1 wid2 -- ) -order set-current ;

  \ doc{
  \
  \ end-package ( wid1 wid2 -- )
  \
  \ End the current `package`, removing _wid2_ (the package word list)
  \ from the search order and setting the compilation word list to the
  \ word list identified by _wid1_, which was the compilation word
  \ list when the latest `package` was executed.
  \
  \ See `package` for a usage example.
  \
  \ }doc

: public  ( wid1 wid2 -- wid1 wid2 ) over set-current ;

  \ doc{
  \
  \ public  ( wid1 wid2 -- wid1 wid2 )
  \
  \ Set the compilation word list to the word list identified by
  \ _wid1_, which was the compilation word list when the latest
  \ `package` was executed. Therefore, new definitions will be public.
  \
  \ See `package` for a usage example.
  \
  \ }doc

: private ( wid1 wid2 -- wid1 wid2 ) dup set-current ;

  \ doc{
  \
  \ private ( wid1 wid2 -- wid1 wid2 )
  \
  \ Set the compilation word list to the word list identified
  \ by _wid2_, which is the word list associated to the current
  \ `package`. Therefore, new definitions will be private to the
  \ current package.
  \
  \ See `package` for a usage example.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-08-16: Start.
\
\ 2017-08-17: Document. Improve credits.
\
\ 2017-10-25: Improve documentation.
