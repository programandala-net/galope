\ galope/rectangle.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Last modified: 201807271618
\ See change log at the end of the file.

\ Author: Marcos Cruz (programandala.net), 2018.

\ ==============================================================
\ Requirements

require ./package.fs          \ `package`
require ./x-emits.fs          \ `x-emits`

\ ==============================================================

package galope-rectangle ( wid1 wid2 )

0
  field: ~top-left-corner
  field: ~top-line
  field: ~top-right-corner
  field: ~left-line
  field: ~right-line
  field: ~bottom-left-corner
  field: ~bottom-line
  field: ~bottom-right-corner

( wid1 wid2 len ) -rot public rot

constant /rectangle-style ( -- len )

  \ doc{
  \
  \ /rectangle-style ( -- len )
  \
  \ Size of a `rectangle-style` (8 cells), in address units.
  \
  \ }doc

create ascii-rectangle-style
  '+' , '-' , '+' ,
  '|' ,       '|' ,
  '+' , '-' , '+' ,

  \ doc{
  \
  \ ascii-rectangle-style ( -- a )
  \
  \ _a_ is the address of a `rectangle-style` definition that uses
  \ only ASCII characters.
  \
  \ See: `rectangle`, `simple-rectangle-style`,
  \ `double-rectangle-style`, `/rectangle-style`.
  \
  \ }doc

create simple-rectangle-style
  '┌' , '─' , '┐' ,
  '│' ,       '│' ,
  '└' , '─' , '┘' ,

  \ doc{
  \
  \ simple-rectangle-style ( -- a )
  \
  \ _a_ is the address of a `rectangle-style` definition that uses
  \ simple lines.
  \
  \ See: `rectangle`, `ascii-rectangle-style`,
  \ `double-rectangle-style`, `/rectangle-style`.
  \
  \ }doc

create double-rectangle-style
  '╔' , '═' , '╗' ,
  '║' ,       '║' ,
  '╚' , '═' , '╝' ,

  \ doc{
  \
  \ double-rectangle-style ( -- a )
  \
  \ _a_ is the address of a `rectangle-style` definition that uses
  \ double lines.
  \
  \ See: `rectangle`, `ascii-rectangle-style`,
  \ `simple-rectangle-style`, `/rectangle-style`.
  \
  \ }doc

simple-rectangle-style value rectangle-style

  \ doc{
  \
  \ rectangle-style ( -- a )
  \
  \ A ``value``. _a_ is the address of the current `rectangle` style,
  \ which is an array of extended characters:

  \ |===
  \ | Cell offset | Extended character
  \
  \ | +0          | top left corner
  \ | +1          | top line
  \ | +2          | top right corner
  \ | +3          | left line
  \ | +4          | right line
  \ | +5          | bottom left corner
  \ | +6          | bottom line
  \ | +7          | bottom right corner
  \ |===

  \ The default value of ``rectangle-style`` is
  \ `simple-rectangle-style`.  Two alternative styles are provided:
  \ `ascii-rectangle-style` and `double-rectangle-style`.
  \
  \ See: `/rectangle-style`.
  \
  \ }doc

: rectangle {: column row width height -- :}
  column row at-xy
  rectangle-style ~top-left-corner @ xemit
  rectangle-style ~top-line @ width 2 - xemits
  rectangle-style ~top-right-corner @ xemit
  height 1 - 1 ?do
    column row i + at-xy
    rectangle-style ~left-line @ xemit
    column width 1- + row i + at-xy
    rectangle-style ~right-line @ xemit
  loop
  column row height 1- + at-xy
  rectangle-style ~bottom-left-corner @ xemit
  rectangle-style ~bottom-line @ width 2 - xemits
  rectangle-style ~bottom-right-corner @ xemit ;

  \ doc{
  \
  \ rectangle ( column row width height -- )
  \
  \ Display a rectangle at coordinates _colum row_, with size _width
  \ height_. The style can be configured by `rectangle-style`.
  \
  \ See: `blank-rectangle`.
  \
  \ }doc

: blank-rectangle {: column row width height -- :}
  column row at-xy
  rectangle-style ~top-left-corner @ xemit
  rectangle-style ~top-line @ width 2 - xemits
  rectangle-style ~top-right-corner @ xemit
  height 1 - 1 ?do
    column row i + at-xy
    rectangle-style ~left-line @ xemit
    width 2 - spaces
    rectangle-style ~right-line @ xemit
  loop
  column row height 1- + at-xy
  rectangle-style ~bottom-left-corner @ xemit
  rectangle-style ~bottom-line @ width 2 - xemits
  rectangle-style ~bottom-right-corner @ xemit ;

  \ doc{
  \
  \ blank-rectangle ( column row width height -- )
  \
  \ Display a blank rectangle at coordinates _colum row_, with size
  \ _width height_. The style can be configured by `rectangle-style`.
  \
  \ See: `rectangle`.
  \
  \ }doc

end-package

\ ==============================================================
\ Change log

\ 2018-07-27: Written.
\
\ 2018-12-19: Fix documentation.
