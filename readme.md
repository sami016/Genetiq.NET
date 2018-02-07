# Project

# Examples

 - [Example 1: Evolving a simple sequence of 'A's](https://github.com/sami016/Genetiq.NET/tree/master/Genetiq.Examples/1_simple_sequence_string_a_count)
 - [Example 2: Evolving a linear classifier](https://github.com/sami016/Genetiq.NET/tree/master/Genetiq.Examples/2_linear_classification_task)


# Future

 - Parallelism (multi-deme populations and migration)
 - Coevolution
 - Cooperative evolution

# Core Interfaces

## Populations and fitness
 - `IFitnessFunction<T>`: A function which maps a genotype to a fitness value.
 - `IPopulation<T>`: A population of individuals/genomes, of fixed size. 
 - `IPopulationEnvironment<T>`: The environment which may potentially contain multiple environments, determining how these interact.

## Round strategies
 - `ISelectionStrategy`: the strategy for selecting individuals based on their fitness values (e.g. tournament).
 - `IRoundStrategy`: the strategy of executing a round/epoch (e.g. generational, steady-state).
 - `IShortlistStrategy`: a strategy for shortlisting invidiuals in a generational round strategy (e.g. elitism).
 - `ITerminationCondition`: a condition which will terminate the algorithm upon being met.

## Variation
 - `IMutator<T>`: A mutation scheme which modifies the genotype passed in.
 - `ICombiner<T>`: A recombination scheme which combines multiple parents to profuce a child.

# Algorithm profile

 The algorithm profile class if used as a configuration container to be set up before execution.
 An algorithm profile will maintain state between subsequent runs - a factory should be used to create fresh profiles if this is undesirable.

[See Example 1](https://github.com/sami016/Genetiq.NET/tree/master/Genetiq.Examples/1_simple_sequence_string_a_count)
