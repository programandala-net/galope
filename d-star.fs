\ galope/d-star.fs
\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Anton Ertl, 2013.

\ ==============================================================

true [if]

\ Newsgroups: comp.lang.forth
\ From: Anton Ertl
\ Subject: Re: Double multiplication
\ Date: Tue, 26 Nov 2013 16:13:19 GMT
\ Message-ID: <2013Nov26.171319@mips.complang.tuwien.ac.at>

: d* { al ah bl bh -- cl ch }
  al bh * ah bl * + 0 swap
  al bl um* d+ ;
  \ (2^m*ah+al)+(2^m*bh+bl) =
  \ 2^(2*m)*ah*bh+2^m*(ah*bl+al*bh)+al*bl
  \ take this modulo 2^(2*m), making ah*bh irrelevant

[else]

\ Newsgroups: comp.lang.forth
\ From: Hans Bezemer
\ Subject: Re: Double multiplication
\ Date: Wed, 27 Nov 2013 22:34:06 +0100
\ Message-Id: <52966559$0$15971$e4fe514c@news2.news.xs4all.nl>

: d*  ( d1 d2 -- d3 )
  >r swap >r over over um* rot r> * + rot r> * + ;

[then]

\ ==============================================================
\ Change log

\ 2013-11-28 Added. with code found in <comp.lang.forth>.
\
\ 2017-08-17: Update change log layout and source style. Update
\ header.
