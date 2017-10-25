\ galope/colors.fs
\ Color constants.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016, 2017

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

  \ doc{
  \
  \ black ( -- x )
  \
  \ A color constant to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `blue`, `light-blue`, `brown`, `cyan`, `light-cyan`,
  \ `green`, `light-green`, `gray`, `light-gray`, `magenta`,
  \ `light-magenta`, `red`, `light-red`, `white`, `yellow`, `lighter`.
  \
  \ }doc

  \ doc{
  \
  \ blue ( -- x )
  \
  \ A color constant to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `black`, `light-blue`, `brown`, `cyan`, `light-cyan`,
  \ `green`, `light-green`, `gray`, `light-gray`, `magenta`,
  \ `light-magenta`, `red`, `light-red`, `white`, `yellow`, `lighter`.
  \
  \ }doc

  \ doc{
  \
  \ light-blue ( -- x )
  \
  \ A color constant to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `black`, `blue`, `brown`, `cyan`, `light-cyan`,
  \ `green`, `light-green`, `gray`, `light-gray`, `magenta`,
  \ `light-magenta`, `red`, `light-red`, `white`, `yellow`, `lighter`.
  \
  \ }doc

  \ doc{
  \
  \ brown ( -- x )
  \
  \ A color constant to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `black`, `blue`, `light-blue`, `cyan`, `light-cyan`,
  \ `green`, `light-green`, `gray`, `light-gray`, `magenta`,
  \ `light-magenta`, `red`, `light-red`, `white`, `yellow`, `lighter`.
  \
  \ }doc

  \ doc{
  \
  \ cyan ( -- x )
  \
  \ A color constant to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `black`, `blue`, `light-blue`, `brown`, `light-cyan`,
  \ `green`, `light-green`, `gray`, `light-gray`, `magenta`,
  \ `light-magenta`, `red`, `light-red`, `white`, `yellow`, `lighter`.
  \
  \ }doc

  \ doc{
  \
  \ light-cyan ( -- x )
  \
  \ A color constant to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `black`, `blue`, `light-blue`, `brown`, `cyan`,
  \ `green`, `light-green`, `gray`, `light-gray`, `magenta`,
  \ `light-magenta`, `red`, `light-red`, `white`, `yellow`, `lighter`.
  \
  \ }doc

  \ doc{
  \
  \ green ( -- x )
  \
  \ A color constant to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `black`, `blue`, `light-blue`, `brown`, `cyan`, `light-cyan`,
  \ `light-green`, `gray`, `light-gray`, `magenta`,
  \ `light-magenta`, `red`, `light-red`, `white`, `yellow`, `lighter`.
  \
  \ }doc

  \ doc{
  \
  \ light-green ( -- x )
  \
  \ A color constant to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `black`, `blue`, `light-blue`, `brown`, `cyan`, `light-cyan`,
  \ `green`, `gray`, `light-gray`, `magenta`,
  \ `light-magenta`, `red`, `light-red`, `white`, `yellow`, `lighter`.
  \
  \ }doc

  \ doc{
  \
  \ gray ( -- x )
  \
  \ A color constant to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `black`, `blue`, `light-blue`, `brown`, `cyan`, `light-cyan`,
  \ `green`, `light-green`, `light-gray`, `magenta`,
  \ `light-magenta`, `red`, `light-red`, `white`, `yellow`, `lighter`.
  \
  \ }doc

  \ doc{
  \
  \ light-gray ( -- x )
  \
  \ A color constant to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `black`, `blue`, `light-blue`, `brown`, `cyan`, `light-cyan`,
  \ `green`, `light-green`, `gray`, `magenta`,
  \ `light-magenta`, `red`, `light-red`, `white`, `yellow`, `lighter`.
  \
  \ }doc

  \ doc{
  \
  \ magenta ( -- x )
  \
  \ A color constant to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `black`, `blue`, `light-blue`, `brown`, `cyan`, `light-cyan`,
  \ `green`, `light-green`, `gray`, `light-gray`,
  \ `light-magenta`, `red`, `light-red`, `white`, `yellow`, `lighter`.
  \
  \ }doc

  \ doc{
  \
  \ light-magenta ( -- x )
  \
  \ A color constant to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `black`, `blue`, `light-blue`, `brown`, `cyan`, `light-cyan`,
  \ `green`, `light-green`, `gray`, `light-gray`, `magenta`,
  \ `red`, `light-red`, `white`, `yellow`, `lighter`.
  \
  \ }doc

  \ doc{
  \
  \ red ( -- x )
  \
  \ A color constant to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `black`, `blue`, `light-blue`, `brown`, `cyan`, `light-cyan`,
  \ `green`, `light-green`, `gray`, `light-gray`, `magenta`,
  \ `light-magenta`, `light-red`, `white`, `yellow`, `lighter`.
  \
  \ }doc

  \ doc{
  \
  \ light-red ( -- x )
  \
  \ A color constant to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `black`, `blue`, `light-blue`, `brown`, `cyan`, `light-cyan`,
  \ `green`, `light-green`, `gray`, `light-gray`, `magenta`,
  \ `light-magenta`, `red`, `white`, `yellow`, `lighter`.
  \
  \ }doc

  \ doc{
  \
  \ white ( -- x )
  \
  \ A color constant to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `black`, `blue`, `light-blue`, `brown`, `cyan`, `light-cyan`,
  \ `green`, `light-green`, `gray`, `light-gray`, `magenta`,
  \ `light-magenta`, `red`, `light-red`, `yellow`, `lighter`.
  \
  \ }doc

  \ doc{
  \
  \ yellow ( -- x )
  \
  \ A color constant to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `black`, `blue`, `light-blue`, `brown`, `cyan`, `light-cyan`,
  \ `green`, `light-green`, `gray`, `light-gray`, `magenta`,
  \ `light-magenta`, `red`, `light-red`, `white`, `lighter`.
  \
  \ }doc

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
\
\ 2017-10-25: Improve documentation.
