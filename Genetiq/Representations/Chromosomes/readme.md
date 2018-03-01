
# Representing chromosomes

Breaking a genome into chromosomes provides an easy way of seperating out modules of homogeneous type.

  - A set of chromosomes is best represented using the `Sequence<T>` type, where `T` defines the chromosome type.
 - `ChromosomeMutator` provides an easy way to define a set of mutators to be applied across all chromosomes.