\ galope/colors.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ History
\
\ 2012-12-02 Refactored from the "Asalto y castigo" project
\ (<http://programandala.net/es.programa.asalto_y_castigo.forth>).
\ 2013-08-17 Rewritten with constants.

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

require ffl/trm.fs
require ./sgr.fs
require ./lighter.fs

\ Recommended:
\ require ./ink.fs
\ require ./paper.fs

(

Results with the "trm" module of Forth Foundation Library on
Debian:

'trm.half-bright' and 'trm.underscore-on' do underscore.

'trm.italic-on' and 'trm.reverse-on' do inverse video.

'trm.foreground-white' sets a white darker than the default one.

Reference:
<http://en.wikipedia.org/wiki/ANSI_escape_code>.

)

false [if]  \ old version

: black  ( -- u )  trm.foreground-black  ;
: blue  ( -- u )  trm.foreground-blue  ;
: light_blue  ( -- u )  blue lighter  ;
: brown  ( -- u )  trm.foreground-brown  ;
: cyan  ( -- u )  trm.foreground-cyan  ;
: light_cyan  ( -- u )  cyan lighter  ;
: green  ( -- u )  trm.foreground-green  ;
: light_green  ( -- u )  green lighter  ;
: gray  ( -- u )  black lighter  ;
: light_gray  ( -- u )  trm.foreground-white  ;
: magenta  ( -- u )  trm.foreground-magenta  ;
: light_magenta  ( -- u )  magenta lighter  ;
: red  ( -- u )  trm.foreground-red  ;
: light_red  ( -- u )  red lighter  ;
: white  ( -- u )  light_gray lighter  ;
: yellow  ( -- u )  brown lighter  ;

[else]  \ new version

trm.foreground-black    constant black
trm.foreground-blue     constant blue
blue lighter            constant light_blue
trm.foreground-brown    constant brown
trm.foreground-cyan     constant cyan
cyan lighter            constant light_cyan
trm.foreground-green    constant green
green lighter           constant light_green
black lighter           constant gray
trm.foreground-white    constant light_gray
trm.foreground-magenta  constant magenta
magenta lighter         constant light_magenta
trm.foreground-red      constant red
red lighter             constant light_red
light_gray lighter      constant white
brown lighter           constant yellow

[then]
