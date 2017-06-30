\ galope/chop.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ History
\ 2014-11-16: Added.

\ Message-Id: <544139de$0$2964$e4fe514c@news2.news.xs4all.nl>
\ From: Hans Bezemer <the.beez.speaks@gmail.com>
\ Subject: Re: Tiny regular expressions code
\ Newsgroups: comp.lang.forth
\ Date: Fri, 17 Oct 2014 17:48:50 +0200

: chop  ( a n -- a+1 n-1)
  1- swap char+ swap
  ;
