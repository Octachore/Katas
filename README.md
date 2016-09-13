# Katas
Code katas in C#


## FizzBuzz

### Initial statement

Produce numbers from 1 to 100.
Replaces multiples of 3 with *fizz* and multiples of 5 with *buzz.*
If a number if multiple of 3 and 5, replace it with *fizzbuzz*.

### Used statement

Produce and input enumeration.
Get some constraints.
Produce an output enumeration in which each element matching a constraint is replaced with that constraint replacement value. If the element matches several constraints, it is replaced with a junction of the replacement values.

For instance:

- **input**: 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15
- **constraints**: 
  - replace prime numbers with *0*
  - replace multiples of 3 with *-1*
  - replace multiples of 5 with *2*
- **joining**: we could choose to join replacement by printing them one after another, but also to print their sum, product... Let's choose the sum.

**OUTPUT**: 1 0 -1 4 2 -1 0 8 -1 2 0 -1 0 14 1


## Sudoku Solver

Solve a sudoku grid :)

## Roman calculator

Handle the addition of two roman numbers, **without converting to int**.

## Paint filler

Mimic the Paint filler tool. Fill a continuous shape of same colour with another.

Filling the 0 square with "colour" 2 :

```
111111111111            111111111111
111100011111            111122211111
111100011111    -->     111122211111
111100011111            111122211111
111111111111            111111111111
```


## Draughts (or *checkers*)

Make a bot that can play draughts (international rules on a 10 x 10 board).

