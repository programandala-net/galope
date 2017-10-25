\ galope/chop.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Authors:
\ Hans Bezemer, 2014
\ Marcos Cruz (programandala.net), 2017

\ ==============================================================

: chop ( ca1 len1 -- ca2 len2 ) 1 /string ;

  \ doc{
  \
  \ chop ( ca1 len1 -- ca2 len2 )
  \
  \ Remove the first character from _ca1 len1_ resulting _ca2 len2_.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2014-11-16: Added. From:

\ Message-Id: <544139de$0$2964$e4fe514c@news2.news.xs4all.nl>
\ From: Hans Bezemer <the.beez.speaks@gmail.com>
\ Subject: Re: Tiny regular expressions code
\ Newsgroups: comp.lang.forth
\ Date: Fri, 17 Oct 2014 17:48:50 +0200

\ 2017-08-17: Update change log layout. Update header.
\
\ 2017-10-25: Rewrite with `/string`. Improve documentation.
