# BattleTech.NET
## A Generic .NET Library for Processing BattleTech Data

This is a library of .NET Standard classes intended to aid development of
software the stores, processes, and analyzes data relating to the BattleTech
board game and its various related products.

## In-Scope Documents

For the moment, we're restricting implementation to the core rulebook set, as
well as Alpha Strike.  Specifically:

- Total Warfare
- TechManual
- Tactical Operations
- Strategic Operations
- Interstellar Operations
- Campaign Operations
- Alpha Strike
- BattleMech Manual

## Test Cases

The BattleTechNETTests Project contains xUnit tests intended to verify that the
processing in the application runs as expected.  In addition to the normal
tests one expects of a library, we would also like to encode all written
examples in the core rulebooks to ensure that this library's output matches the
expected results from the definitive documents (errata applied.)

## Contribution and Style Guidelines

If you intend to contribute code, I am happy to review it.  I will ask a
couple of things for the sake of consistency, although I understand that it
will conflict with some developer's coding style.

### 1. Strong Typing

I really insist whenever a variable is declared that it is given a non-variant
datatype.  Besides helping syntactically to detect when an improper value is
being passed, it also helps when reading the declarations to know what value
will be going into a variable, and understanding what it is going to do.

### 2. Title Case Classes, Properties, and Methods

Classes, Properties, and Methods should always be named with Title Case -- that 
is, capitializing the first letter of each word that makes up the class name.
Where applicable, this applies to articles and conjunctions.

### 3. Prohibition on LINQ

I know this is going anger a lot of developers, but LINQ really doesn't have a
place in this project.  Although it is undeniably splendid for database 
transfer code and dynamically writing queries, it represents a pretty 
significant barrier for both new and very old programmers to understand the
nuances and subtleties, to say nothing of the stylistics permutations different
developers embrace.  We don't need LINQ for this project, so over the side it
goes.

### 4. Rules Citation

Whereever practical, please cite a rules reference in comments for the code you
are writing.  This can usually just be an acronym of the book followed by a
page number (for instance, SO217 for Strategic Operations, page 217.)  This
really helps with validaating where a particular rule came from, especially
when clarifying contradictory or strangely interacting rules.

If you are citing Tactical Operations or Interstellar Operations from after 
those books were separated, be sure to include their subtitled abbreviation 
(TO:AR for Tactical Operations: Advance Rules, TO:AUE for Tactical Operations:
Advanced Units and Equipment, IO:AE for Interstellar Operations:Alternate Eras,
and IO:BF for Interstellar Operations:BattleForce.)


### 5. Id Is Mixed-Case

For the sake of consistency, an identification field named Id is mixed-case,
and should never be ID or id.  If you need to use a local variable to hold an
Id number, add more characters to the variable name to define what it is (for
example, CurrentUnitId).

