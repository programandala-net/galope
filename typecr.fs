\ galope/typecr.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2015, 2016, 2017.

\ ==============================================================

: typecr ( ca len -- ) type cr ;

  \ doc{
  \
  \ typecr ( ca len -- )
  \
  \ Display character string _ca len_ and then move the cursor to the
  \ next line. This word simply does ``type cr``. It is a factor of
  \ `?error-bye`, where its execution token is used with
  \ ``outfile-execute``.
  \
  \ See: `ltype`, `lcr`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2015-12-17: Add to the library for <question-error-bye.fs>.
\
\ 2016-07-11: Update source layout and file header.
\
\ 2017-08-17: Update source style. Update header.
\
\ 2017-11-04: Improve documentation.
