# Example 1: Simple Sequence - string A count

A simple example demonstrating the evolution of a sequence of character bytes.
 - This employs a random replacement mutation scheme where in each offsprint a random character from each parent is replaced with a random other character.
 - A simple uniform crossover scheme is used, where each sequence position (locus) has an equal chance of being from either parent.
 - Employ a generational round strategy which replaces the entire population each round with new children.
 - Elitism is used to persist the top 5% of the population, preventing a loss of the best solutions.

 ## Representation: Sequence

 When running an evolutionary algorithm, selecting an appropriate genome representation can be crucial to performance, with effective representations constraining the search space of possible solutions in a useful way.
 In this example, a genotype is represented using `Sequence<byte>` - each having a string of 10 bytes.
 The `Sequence<T>` type is provided as a common array-based genome representation, coming with a range of off the shelf strategies for recombination (cross-over) and mutation.
 