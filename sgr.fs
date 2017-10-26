\ galope/sgr.fs
\ `sgr` and SGR (Select Graphic Rendition) parameters not included in
\ the 'trm' module of Forth Foundation library.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016, 2017.

\ ==============================================================

require ffl/trm.fs  \ Forth Foundation Library

\ Reference:
\ <http://en.wikipedia.org/wiki/ANSI_escape_code#graphics>.

003 constant trm.italic-on
023 constant trm.italic-off
090 constant trm.foreground-black-high
091 constant trm.foreground-red-high
092 constant trm.foreground-green-high
093 constant trm.foreground-brown-high
094 constant trm.foreground-blue-high
095 constant trm.foreground-magenta-high
096 constant trm.foreground-cyan-high
097 constant trm.foreground-white-high
100 constant trm.background-black-high
101 constant trm.background-red-high
102 constant trm.background-green-high
103 constant trm.background-brown-high
104 constant trm.background-blue-high
105 constant trm.background-magenta-high
106 constant trm.background-cyan-high
107 constant trm.background-white-high

  \ doc{
  \
  \ trm.italic-on ( -- x )
  \
  \ An attribute to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `trm.italic-off`, `trm.foreground-black-high`,
  \ `trm.foreground-red-high`, `trm.foreground-green-high`,
  \ `trm.foreground-brown-high`, `trm.foreground-blue-high`,
  \ `trm.foreground-magenta-high`, `trm.foreground-cyan-high`,
  \ `trm.foreground-white-high`, `trm.background-black-high`,
  \ `trm.background-red-high`, `trm.background-green-high`,
  \ `trm.background-brown-high`, `trm.background-blue-high`,
  \ `trm.background-magenta-high`, `trm.background-cyan-high`,
  \ `trm.background-white-high`, `sgr`, `black`, `blue`, `light-blue`,
  \ `brown`, `cyan`, `light-cyan`, `green`, `light-green`, `gray`,
  \ `light-gray`, `magenta`, `light-magenta`, `red`, `light-red`,
  \ `white`, `yellow`, `lighter`.

  \
  \ }doc

  \ doc{
  \
  \ trm.italic-off ( -- x )
  \
  \ An attribute to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `trm.italic-on`, `trm.foreground-black-high`,
  \ `trm.foreground-red-high`, `trm.foreground-green-high`,
  \ `trm.foreground-brown-high`, `trm.foreground-blue-high`,
  \ `trm.foreground-magenta-high`, `trm.foreground-cyan-high`,
  \ `trm.foreground-white-high`, `trm.background-black-high`,
  \ `trm.background-red-high`, `trm.background-green-high`,
  \ `trm.background-brown-high`, `trm.background-blue-high`,
  \ `trm.background-magenta-high`, `trm.background-cyan-high`,
  \ `trm.background-white-high`, `sgr`, `black`, `blue`, `light-blue`,
  \ `brown`, `cyan`, `light-cyan`, `green`, `light-green`, `gray`,
  \ `light-gray`, `magenta`, `light-magenta`, `red`, `light-red`,
  \ `white`, `yellow`, `lighter`.

  \
  \ }doc

  \ doc{
  \
  \ trm.foreground-black-high ( -- x )
  \
  \ An attribute to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `trm.italic-on`, `trm.italic-off`,
  \ `trm.foreground-red-high`, `trm.foreground-green-high`,
  \ `trm.foreground-brown-high`, `trm.foreground-blue-high`,
  \ `trm.foreground-magenta-high`, `trm.foreground-cyan-high`,
  \ `trm.foreground-white-high`, `trm.background-black-high`,
  \ `trm.background-red-high`, `trm.background-green-high`,
  \ `trm.background-brown-high`, `trm.background-blue-high`,
  \ `trm.background-magenta-high`, `trm.background-cyan-high`,
  \ `trm.background-white-high`, `sgr`, `black`, `blue`, `light-blue`,
  \ `brown`, `cyan`, `light-cyan`, `green`, `light-green`, `gray`,
  \ `light-gray`, `magenta`, `light-magenta`, `red`, `light-red`,
  \ `white`, `yellow`, `lighter`.

  \
  \ }doc

  \ doc{
  \
  \ trm.foreground-red-high ( -- x )
  \
  \ An attribute to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `trm.italic-on`, `trm.italic-off`, `trm.foreground-black-high`,
  \ `trm.foreground-green-high`,
  \ `trm.foreground-brown-high`, `trm.foreground-blue-high`,
  \ `trm.foreground-magenta-high`, `trm.foreground-cyan-high`,
  \ `trm.foreground-white-high`, `trm.background-black-high`,
  \ `trm.background-red-high`, `trm.background-green-high`,
  \ `trm.background-brown-high`, `trm.background-blue-high`,
  \ `trm.background-magenta-high`, `trm.background-cyan-high`,
  \ `trm.background-white-high`, `sgr`, `black`, `blue`, `light-blue`,
  \ `brown`, `cyan`, `light-cyan`, `green`, `light-green`, `gray`,
  \ `light-gray`, `magenta`, `light-magenta`, `red`, `light-red`,
  \ `white`, `yellow`, `lighter`.

  \
  \ }doc

  \ doc{
  \
  \ trm.foreground-green-high ( -- x )
  \
  \ An attribute to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `trm.italic-on`, `trm.italic-off`, `trm.foreground-black-high`,
  \ `trm.foreground-red-high`,
  \ `trm.foreground-brown-high`, `trm.foreground-blue-high`,
  \ `trm.foreground-magenta-high`, `trm.foreground-cyan-high`,
  \ `trm.foreground-white-high`, `trm.background-black-high`,
  \ `trm.background-red-high`, `trm.background-green-high`,
  \ `trm.background-brown-high`, `trm.background-blue-high`,
  \ `trm.background-magenta-high`, `trm.background-cyan-high`,
  \ `trm.background-white-high`, `sgr`, `black`, `blue`, `light-blue`,
  \ `brown`, `cyan`, `light-cyan`, `green`, `light-green`, `gray`,
  \ `light-gray`, `magenta`, `light-magenta`, `red`, `light-red`,
  \ `white`, `yellow`, `lighter`.

  \
  \ }doc

  \ doc{
  \
  \ trm.foreground-brown-high ( -- x )
  \
  \ An attribute to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `trm.italic-on`, `trm.italic-off`, `trm.foreground-black-high`,
  \ `trm.foreground-red-high`, `trm.foreground-green-high`,
  \ `trm.foreground-blue-high`,
  \ `trm.foreground-magenta-high`, `trm.foreground-cyan-high`,
  \ `trm.foreground-white-high`, `trm.background-black-high`,
  \ `trm.background-red-high`, `trm.background-green-high`,
  \ `trm.background-brown-high`, `trm.background-blue-high`,
  \ `trm.background-magenta-high`, `trm.background-cyan-high`,
  \ `trm.background-white-high`, `sgr`, `black`, `blue`, `light-blue`,
  \ `brown`, `cyan`, `light-cyan`, `green`, `light-green`, `gray`,
  \ `light-gray`, `magenta`, `light-magenta`, `red`, `light-red`,
  \ `white`, `yellow`, `lighter`.

  \
  \ }doc

  \ doc{
  \
  \ trm.foreground-blue-high ( -- x )
  \
  \ An attribute to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `trm.italic-on`, `trm.italic-off`, `trm.foreground-black-high`,
  \ `trm.foreground-red-high`, `trm.foreground-green-high`,
  \ `trm.foreground-brown-high`,
  \ `trm.foreground-magenta-high`, `trm.foreground-cyan-high`,
  \ `trm.foreground-white-high`, `trm.background-black-high`,
  \ `trm.background-red-high`, `trm.background-green-high`,
  \ `trm.background-brown-high`, `trm.background-blue-high`,
  \ `trm.background-magenta-high`, `trm.background-cyan-high`,
  \ `trm.background-white-high`, `sgr`, `black`, `blue`, `light-blue`,
  \ `brown`, `cyan`, `light-cyan`, `green`, `light-green`, `gray`,
  \ `light-gray`, `magenta`, `light-magenta`, `red`, `light-red`,
  \ `white`, `yellow`, `lighter`.

  \
  \ }doc

  \ doc{
  \
  \ trm.foreground-magenta-high ( -- x )
  \
  \ An attribute to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `trm.italic-on`, `trm.italic-off`, `trm.foreground-black-high`,
  \ `trm.foreground-red-high`, `trm.foreground-green-high`,
  \ `trm.foreground-brown-high`, `trm.foreground-blue-high`,
  \ `trm.foreground-cyan-high`,
  \ `trm.foreground-white-high`, `trm.background-black-high`,
  \ `trm.background-red-high`, `trm.background-green-high`,
  \ `trm.background-brown-high`, `trm.background-blue-high`,
  \ `trm.background-magenta-high`, `trm.background-cyan-high`,
  \ `trm.background-white-high`, `sgr`, `black`, `blue`, `light-blue`,
  \ `brown`, `cyan`, `light-cyan`, `green`, `light-green`, `gray`,
  \ `light-gray`, `magenta`, `light-magenta`, `red`, `light-red`,
  \ `white`, `yellow`, `lighter`.

  \
  \ }doc

  \ doc{
  \
  \ trm.foreground-cyan-high ( -- x )
  \
  \ An attribute to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `trm.italic-on`, `trm.italic-off`, `trm.foreground-black-high`,
  \ `trm.foreground-red-high`, `trm.foreground-green-high`,
  \ `trm.foreground-brown-high`, `trm.foreground-blue-high`,
  \ `trm.foreground-magenta-high`,
  \ `trm.foreground-white-high`, `trm.background-black-high`,
  \ `trm.background-red-high`, `trm.background-green-high`,
  \ `trm.background-brown-high`, `trm.background-blue-high`,
  \ `trm.background-magenta-high`, `trm.background-cyan-high`,
  \ `trm.background-white-high`, `sgr`, `black`, `blue`, `light-blue`,
  \ `brown`, `cyan`, `light-cyan`, `green`, `light-green`, `gray`,
  \ `light-gray`, `magenta`, `light-magenta`, `red`, `light-red`,
  \ `white`, `yellow`, `lighter`.

  \
  \ }doc

  \ doc{
  \
  \ trm.foreground-white-high ( -- x )
  \
  \ An attribute to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `trm.italic-on`, `trm.italic-off`, `trm.foreground-black-high`,
  \ `trm.foreground-red-high`, `trm.foreground-green-high`,
  \ `trm.foreground-brown-high`, `trm.foreground-blue-high`,
  \ `trm.foreground-magenta-high`, `trm.foreground-cyan-high`,
  \ `trm.background-black-high`,
  \ `trm.background-red-high`, `trm.background-green-high`,
  \ `trm.background-brown-high`, `trm.background-blue-high`,
  \ `trm.background-magenta-high`, `trm.background-cyan-high`,
  \ `trm.background-white-high`, `sgr`, `black`, `blue`, `light-blue`,
  \ `brown`, `cyan`, `light-cyan`, `green`, `light-green`, `gray`,
  \ `light-gray`, `magenta`, `light-magenta`, `red`, `light-red`,
  \ `white`, `yellow`, `lighter`.

  \
  \ }doc

  \ doc{
  \
  \ trm.background-black-high ( -- x )
  \
  \ An attribute to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `trm.italic-on`, `trm.italic-off`, `trm.foreground-black-high`,
  \ `trm.foreground-red-high`, `trm.foreground-green-high`,
  \ `trm.foreground-brown-high`, `trm.foreground-blue-high`,
  \ `trm.foreground-magenta-high`, `trm.foreground-cyan-high`,
  \ `trm.foreground-white-high`,
  \ `trm.background-red-high`, `trm.background-green-high`,
  \ `trm.background-brown-high`, `trm.background-blue-high`,
  \ `trm.background-magenta-high`, `trm.background-cyan-high`,
  \ `trm.background-white-high`, `sgr`, `black`, `blue`, `light-blue`,
  \ `brown`, `cyan`, `light-cyan`, `green`, `light-green`, `gray`,
  \ `light-gray`, `magenta`, `light-magenta`, `red`, `light-red`,
  \ `white`, `yellow`, `lighter`.

  \
  \ }doc

  \ doc{
  \
  \ trm.background-red-high ( -- x )
  \
  \ An attribute to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `trm.italic-on`, `trm.italic-off`, `trm.foreground-black-high`,
  \ `trm.foreground-red-high`, `trm.foreground-green-high`,
  \ `trm.foreground-brown-high`, `trm.foreground-blue-high`,
  \ `trm.foreground-magenta-high`, `trm.foreground-cyan-high`,
  \ `trm.foreground-white-high`, `trm.background-black-high`,
  \ `trm.background-green-high`,
  \ `trm.background-brown-high`, `trm.background-blue-high`,
  \ `trm.background-magenta-high`, `trm.background-cyan-high`,
  \ `trm.background-white-high`, `sgr`, `black`, `blue`, `light-blue`,
  \ `brown`, `cyan`, `light-cyan`, `green`, `light-green`, `gray`,
  \ `light-gray`, `magenta`, `light-magenta`, `red`, `light-red`,
  \ `white`, `yellow`, `lighter`.

  \
  \ }doc

  \ doc{
  \
  \ trm.background-green-high ( -- x )
  \
  \ An attribute to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `trm.italic-on`, `trm.italic-off`, `trm.foreground-black-high`,
  \ `trm.foreground-red-high`, `trm.foreground-green-high`,
  \ `trm.foreground-brown-high`, `trm.foreground-blue-high`,
  \ `trm.foreground-magenta-high`, `trm.foreground-cyan-high`,
  \ `trm.foreground-white-high`, `trm.background-black-high`,
  \ `trm.background-red-high`,
  \ `trm.background-brown-high`, `trm.background-blue-high`,
  \ `trm.background-magenta-high`, `trm.background-cyan-high`,
  \ `trm.background-white-high`, `sgr`, `black`, `blue`, `light-blue`,
  \ `brown`, `cyan`, `light-cyan`, `green`, `light-green`, `gray`,
  \ `light-gray`, `magenta`, `light-magenta`, `red`, `light-red`,
  \ `white`, `yellow`, `lighter`.

  \
  \ }doc

  \ doc{
  \
  \ trm.background-brown-high ( -- x )
  \
  \ An attribute to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `trm.italic-on`, `trm.italic-off`, `trm.foreground-black-high`,
  \ `trm.foreground-red-high`, `trm.foreground-green-high`,
  \ `trm.foreground-brown-high`, `trm.foreground-blue-high`,
  \ `trm.foreground-magenta-high`, `trm.foreground-cyan-high`,
  \ `trm.foreground-white-high`, `trm.background-black-high`,
  \ `trm.background-red-high`, `trm.background-green-high`,
  \ `trm.background-blue-high`,
  \ `trm.background-magenta-high`, `trm.background-cyan-high`,
  \ `trm.background-white-high`, `sgr`, `black`, `blue`, `light-blue`,
  \ `brown`, `cyan`, `light-cyan`, `green`, `light-green`, `gray`,
  \ `light-gray`, `magenta`, `light-magenta`, `red`, `light-red`,
  \ `white`, `yellow`, `lighter`.

  \
  \ }doc

  \ doc{
  \
  \ trm.background-blue-high ( -- x )
  \
  \ An attribute to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `trm.italic-on`, `trm.italic-off`, `trm.foreground-black-high`,
  \ `trm.foreground-red-high`, `trm.foreground-green-high`,
  \ `trm.foreground-brown-high`, `trm.foreground-blue-high`,
  \ `trm.foreground-magenta-high`, `trm.foreground-cyan-high`,
  \ `trm.foreground-white-high`, `trm.background-black-high`,
  \ `trm.background-red-high`, `trm.background-green-high`,
  \ `trm.background-brown-high`,
  \ `trm.background-magenta-high`, `trm.background-cyan-high`,
  \ `trm.background-white-high`, `sgr`, `black`, `blue`, `light-blue`,
  \ `brown`, `cyan`, `light-cyan`, `green`, `light-green`, `gray`,
  \ `light-gray`, `magenta`, `light-magenta`, `red`, `light-red`,
  \ `white`, `yellow`, `lighter`.

  \
  \ }doc

  \ doc{
  \
  \ trm.background-magenta-high ( -- x )
  \
  \ An attribute to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `trm.italic-on`, `trm.italic-off`, `trm.foreground-black-high`,
  \ `trm.foreground-red-high`, `trm.foreground-green-high`,
  \ `trm.foreground-brown-high`, `trm.foreground-blue-high`,
  \ `trm.foreground-magenta-high`, `trm.foreground-cyan-high`,
  \ `trm.foreground-white-high`, `trm.background-black-high`,
  \ `trm.background-red-high`, `trm.background-green-high`,
  \ `trm.background-brown-high`, `trm.background-blue-high`,
  \ `trm.background-cyan-high`,
  \ `trm.background-white-high`, `sgr`, `black`, `blue`, `light-blue`,
  \ `brown`, `cyan`, `light-cyan`, `green`, `light-green`, `gray`,
  \ `light-gray`, `magenta`, `light-magenta`, `red`, `light-red`,
  \ `white`, `yellow`, `lighter`.

  \
  \ }doc

  \ doc{
  \
  \ trm.background-cyan-high ( -- x )
  \
  \ An attribute to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `trm.italic-on`, `trm.italic-off`, `trm.foreground-black-high`,
  \ `trm.foreground-red-high`, `trm.foreground-green-high`,
  \ `trm.foreground-brown-high`, `trm.foreground-blue-high`,
  \ `trm.foreground-magenta-high`, `trm.foreground-cyan-high`,
  \ `trm.foreground-white-high`, `trm.background-black-high`,
  \ `trm.background-red-high`, `trm.background-green-high`,
  \ `trm.background-brown-high`, `trm.background-blue-high`,
  \ `trm.background-magenta-high`,
  \ `trm.background-white-high`, `sgr`, `black`, `blue`, `light-blue`,
  \ `brown`, `cyan`, `light-cyan`, `green`, `light-green`, `gray`,
  \ `light-gray`, `magenta`, `light-magenta`, `red`, `light-red`,
  \ `white`, `yellow`, `lighter`.
  \
  \ }doc

  \ doc{
  \
  \ trm.background-white-high ( -- x )
  \
  \ An attribute to be used with the trm module
  \ of Forth Foundation Library.
  \
  \ See: `trm.italic-on`, `trm.italic-off`, `trm.foreground-black-high`,
  \ `trm.foreground-red-high`, `trm.foreground-green-high`,
  \ `trm.foreground-brown-high`, `trm.foreground-blue-high`,
  \ `trm.foreground-magenta-high`, `trm.foreground-cyan-high`,
  \ `trm.foreground-white-high`, `trm.background-black-high`,
  \ `trm.background-red-high`, `trm.background-green-high`,
  \ `trm.background-brown-high`, `trm.background-blue-high`,
  \ `trm.background-magenta-high`, `trm.background-cyan-high`,
  \ `sgr`, `black`, `blue`, `light-blue`,
  \ `brown`, `cyan`, `light-cyan`, `green`, `light-green`, `gray`,
  \ `light-gray`, `magenta`, `light-magenta`, `red`, `light-red`,
  \ `white`, `yellow`, `lighter`.
  \
  \ }doc

synonym sgr trm+set-attributes

  \ doc{
  \
  \ sgr ( u1 .. un n -- )
  \
  \ Set _n_ attributes.
  \
  \ ``sgr`` (Select Graphic Rendition) is a synonym of
  \ ``trm+set-attributes``, found in the trm module of Forth
  \ Foundation Library.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-12-02: Refactor from "Asalto y castigo"
\ (http://programandala.net/es.programa.asalto_y_castigo.forth.html).
\
\ 2016-07-11: Update source layout and file header.
\
\ 2017-10-25: Improve documentation.
\
\ 2017-10-26: Fix markup in documentation.
