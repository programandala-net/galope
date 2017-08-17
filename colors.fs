\ galope/colors.fs
\ Color constants.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016.

\ ==============================================================

require ffl/trm.fs
require ./sgr.fs
require ./lighter.fs

\ Recommended:
\ require ./ink.fs
\ require ./paper.fs

\ Results with the "trm" module of Forth Foundation Library on
\ Debian:
\
\ 'trm.half-bright' and 'trm.underscore-on' do underscore.
\
\ 'trm.italic-on' and 'trm.reverse-on' do inverse video.
\
\ 'trm.foreground-white' sets a white darker than the default one.
\
\ Reference:
\ <http://en.wikipedia.org/wiki/ANSI_escape_code>.

trm.foreground-black    constant black
trm.foreground-blue     constant blue
blue lighter            constant light-blue
trm.foreground-brown    constant brown
trm.foreground-cyan     constant cyan
cyan lighter            constant light-cyan
trm.foreground-green    constant green
green lighter           constant light-green
black lighter           constant gray
trm.foreground-white    constant light-gray
trm.foreground-magenta  constant magenta
magenta lighter         constant light-magenta
trm.foreground-red      constant red
red lighter             constant light-red
light-gray lighter      constant white
brown lighter           constant yellow

\ ==============================================================
\ Change log

\ 2012-12-02: Refactored from "Asalto y castigo"
\ (http://programandala.net/es.programa.asalto_y_castigo.forth.html).
\
\ 2013-08-17: Rewritten with constants.
\
\ 2016-06-26: Change underscores to hyphens. Update style and header.
\ Remove old version, already commented out.
\
\ 2016-07-11: Update source layout and file header.
