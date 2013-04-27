\ galope/random_strings.fs
\ Random strings

\ This file is part of Galope

\ Copyright (C) 2011,2012 Marcos Cruz (programandala.net)

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ History

(

2012-04-07 In order to reuse this code, it was extracted from
the project it was developed for
[http://programandala.net/es.programa.asalto_y_castigo.forth].
The abort messages are translated to English.

2012-04-22 The original Spanish comments are moved to the end of
the file.  More compact source layout. 

2012-04-30 Added 's?{' and '}s{'.

2012-05-02 Fixed some stack comments.

2012-05-05 Added the new files galope/increment.fs and
galope/decrement.fs, instead of defining '++' and '--'.  Added
'}s&?'.

2012-05-08 galope/increment.fs and galope/decrement.fs changed
their names to galope/plus-plus.fs and galope/minus-minus.fs.

2012-09-14 Code reformated.

) 

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

require random.fs

require galope/module.fs
require galope/2choose.fs
require galope/sb.fs
require galope/plus-plus.fs
require galope/minus-minus.fs

module: galope_random_strings

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Depth stack

8 constant /dstack
variable dstack_pointer
/dstack cells allot 
: 'dstack_tos ( -- a )
  dstack_pointer dup @ cells +
  ;
: dstack_full? ( -- ff )
  dstack_pointer @ /dstack =
  ;
: dstack_empty? ( -- ff )
  dstack_pointer @ 0=
  ;
: ?abort_full
  dstack_full? abort" Too many nesting levels with S{ and }S ."
  ;
: dstack! ( u -- )
  ?abort_full dstack_pointer ++ 'dstack_tos !
  ;
: ?abort_empty
  dstack_empty? abort" S{ and }S badly nested."
  ;
: dstack@ ( -- u )
  ?abort_empty 'dstack_tos @ dstack_pointer --
  ;

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Operators

export

: s{ ( -- )
  depth dstack!
  ;
: }s ( a1 u1 ... an un -- a' u' )
  depth dstack@ - 2 / 2choose
  ;
: }s{ ( a1 u1 ... an un -- a' u' )
  }s s{
  ;
: }s& ( a0 u0 a1 u1 ... an un -- a' u' )
  }s bs&
  ;
: }s+ ( a0 u0 a1 u1 ... an un -- a' u' )
  }s bs+
  ;
: s? ( a u -- a u | a 0 )
  2 random *
  ;
: s?& ( a1 u1 a2 u2 -- a3 u3 | a3 u1 )
  s? bs&
  ;
: s?+ ( a1 u1 a2 u2 -- a3 u3 | a3 u1 )
  s? bs+
  ;
: s+? ( a1 u1 a2 u2 -- a3 u3 | a3 0 )
  bs+ s?
  ;
: s&? ( a1 u1 a2 u2 -- a3 u3 | a3 0 )
  bs& s?
  ;
: }s? ( a1 u1 ... an un -- a' u' | a' 0 )
  }s s?
  ;
: }s?& ( a0 u0 a1 u1 ... an un -- a' u' )
  }s? bs&
  ;
: }s?+ ( a0 u0 a1 u1 ... an un -- a' u' )
  }s? bs+
  ;
: s&{ ( a1 u1 a2 u2 -- a3 u3 )
  bs& s{
  ;
: s+{ ( a1 u1 a2 u2 -- a3 u3 )
  bs+ s{
  ;
: s?{ ( a1 u1 -- a1 u1 | a1 0 )
  s? s{
  ;
: }s&? ( a0 u0 a1 u1 ... an un -- a' u' | a' 0 )
  }s& s?
  ;

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Spanish documentation

0 [if]

Este módulo proporciona operadores para hacer una selección
aleatoria de una cadena entre un grupo, así como hacer
diversas concatenaciones.  Las palabras principales son 's{'
y '}s'.  Para que puedan ser anidadas usan una pila propia
en la que guardan la profundidad de la pila de Forth en cada
anidación.  

\ Pila

/dstack \ Elementos de la pila (y por tanto número máximo de anidaciones)
dstack_pointer \ Puntero al elemento superior de la pila (o cero si está vacía)
'dstack_tos \ Dirección del elemento superior de la pila.
dstack_full?  \ ¿Está la pila llena?
dstack_empty? \ ¿Está la pila vacía?
dstack! \ Guarda un elemento en la pila.
dstack@ \ Devuelve el elemento superior de la pila.

\ Operadores

s{ \ Inicia una zona de selección aleatoria de cadenas.
}s \ Elige una cadena entre las puestas en la pila desde que se ejecutó por última vez la palabra 's{'.
}s{ \ Equivale a la combinación '}s s{'.
}s& \ Elige una cadena entre las puestas en la pila desde que se ejecutó 's{' y la concatena (con separación) a una cadena anterior.
}s+ \ Elige una cadena entre las puestas en la pila desde que se ejecutó 's{' y la concatena a una cadena anterior.
s? \ Vacía una cadena (con el 50% de probabilidad).
s?& \ Devuelve una cadena concatenada o no (al azar) a otra, con separación.
s?+ \ Devuelve una cadena concatenada o no (al azar) a otra.
s+? \ Devuelve dos cadenas concatenadas o (al azar) una cadena vacía.
s&? \ Devuelve dos cadenas concatenadas (con separación) o (al azar) una cadena vacía.
}s? \ Elige una cadena entre las puestas en la pila desde que se ejecutó 's{' y la vacía con el 50% de probabilidad.
}s?& \ Elige una cadena entre las puestas en la pila desde que se ejecutó 's{' y (con un 50% de probabilidad) la concatena (con separación) a una cadena anterior.
}s?+ \ Elige una cadena entre las puestas en la pila desde que se ejecutó 's{' y (con un 50% de probabilidad) la concatena (sin separación) a una cadena anterior.
s&{ \ Concatena dos cadenas (con separación) e inicia una zona de selección aleatoria de cadenas.
s+{ \ Concatena dos cadenas (sin separación) e inicia una zona de selección aleatoria de cadenas.
s?{ \ Vacía una cadena (con el 50% de probabilidad) e inicia una zona de selección aleatoria de cadenas.
}s&? \ Elige una cadena entre las puestas en la pila desde que se ejecutó 's{', la concatena a la cadena inferior y vacía el resultado (con un 50% de probabilidad).

[then]

;module
