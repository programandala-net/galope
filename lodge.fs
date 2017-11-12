\ galope/lodge.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

variable lodge  0 allocate throw lodge !

  \ doc{
  \
  \ lodge ( -- a )
  \
  \ _a_ is the address of a cell containing the address of the
  \ lodge.
  \
  \ A lodge is a self-growing buffer allocated from the heap,
  \ where data can be stored and retrieved transparently, using
  \ offsets, regardless of the actual address of the buffer,
  \ provided the definer words `lodge-create`,
  \ `lodge-variable`, `lodge-constant` and others are used.
  \ The words so defined store in their data field the offset
  \ to the actual data in the lodge, which is resolved at
  \ run-time.
  \
  \ A lodge makes it possible to concentrate the application
  \ data into one relocatable and transparent buffer, which can
  \ be saved and restored as a whole (e.g. for game sessions).
  \
  \ See: `/lodge`.
  \
  \ }doc

variable /lodge  0 /lodge !

  \ doc{
  \
  \ /lodge ( -- a )
  \
  \ _a_ is the address of a cell containing the length of the
  \ `lodge` in address units.
  \
  \ See: `lodge-here`.
  \
  \ }doc

: lodge+ ( +n -- a ) lodge @ + ;

  \ doc{
  \
  \ lodge+ ( +n -- a )
  \
  \ Convert `lodge` offset _+n_ to its absolute address _a_.
  \
  \ Words created by `lodge-variable`, `lodge-2variable`,
  \ `lodge-value`, `lodge-2value` and `lodge-create` save in
  \ their data field address the current value returned by
  \ `lodge-here`, and convert it to its corresponding `lodge`
  \ address at run-time.
  \
  \ }doc

: body>lodge ( dfa -- a ) @ lodge+ ;

  \ doc{
  \
  \ body>lodge ( dfa -- a )
  \
  \ Convert the _dfa_ of a `lodge-variable`, `lodge-2variable`,
  \ `lodge-value`, `lodge-2value` or a word created by `lodge-create`
  \ or `lodge-(create)` to its absolute `lodge` address _a_.
  \
  \ See: `>lodge`, `lodge+`.
  \
  \ }doc

: >lodge ( xt -- a ) >body body>lodge ;

  \ doc{
  \
  \ >lodge ( xt -- a )
  \
  \ Convert the _xt_ of a `lodge-variable`, `lodge-2variable`,
  \ `lodge-value`, `lodge-2value` or a word created by
  \ `lodge-create` to its absolute `lodge` address _a_.
  \
  \ See: `body>lodge`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2014-02-16 Written for Finto
\ (http://programandala.net/en.program.finto.html).
\
\ 2014-02-17 New: `lodge-value`, `lodge-to` and related words.
\
\ 2014-02-19 New: `lodge-address-value`.
\
\ 2014-02-20 Change: "index" and "relative pointer" corrected to
\ "offset" in the comments; additional comment in
\ `lodge-address-value`; `(cell-lodge-value:)` factored out from
\ `lodge-value` and `lodge-address-value`; `>lodge` renamed to
\ `lodge+`.  2014-02-20 New: `lodge-save-mem`.
\
\ 2014-02-21 Fix: `[lodge-to]` and `[lodge-2to]` were wrong.
\
\  `[lodge-to]`, before the fix:
\
\     ' postpone xt>lodge postpone literal postpone !
\
\  First bug: `xt>lodge` should not be postponed in this case.  Second
\  bug: the absolute lodge address must not be compiled, because it
\  may change.
\
\   After the fix:
\
\     ' postpone literal postpone xt>lodge postpone !
\
\ Now the xt is compiled and the lodge address is calculated at
\ run-time.
\
\ 2014-02-21: Forked to <galope/lodge-colon.fs>.
\
\ 2014-02-21: New: `lodge-,` and `lodge-2,`.
\
\ 2014-02-21: Fix: `lodge-resize` now can be used directly by the
\ application. Solved by moving the trailing code of `lodge-allocate`
\ to `lodge-resize`.
\
\ 2017-07-03: Update code style. Improve documentation.
\
\ 2017-08-21: Improve documentation and stack notation. Add the factor
\ `body>lodge`, after the `lodge:` module.
\
\ 2017-08-22: Prepare to supersed the `lodge:` module.
\
\ 2017-08-23: Factor. Add `lodge-here`, `lodge-allot` and
\ `lodge-create`, and rewrite other words after them, making the code
\ easier to follow.  Remove zero initialization of variables. Improve
\ documentation. Rename `xt>lodge` to `>lodge`.
\
\ 2017-08-24: Improve documentation.
\
\ 2017-10-25: Fix typo.
\
\ 2017-11-12: Rename `(lodge-create)` `lodge-(create)`. Extract
\ `lodge-allocate`, `lodge-allot`, `lodge-comma`, `lodge-create`,
\ `lodge-here`, `lodge-(create)`, `lodge-resize`, `lodge-save-mem`,
\ `lodge-two-comma`, `lodge-two-value`, `lodge-two-variable`,
\ `lodge-value` and `lodge-variable` to their own files. Improve
\ documentation.
