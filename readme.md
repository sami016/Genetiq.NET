# Project

 - Evolutionary Algorithm: A class of algorithm inspired by the evolutionary via natural selection.
	- Optimization algorithm involving a population of reproducing individuals, each of which is assigned a measure of fitness based on a utility function (analogous with Darwinian fitness).
	- Individuals with higher fitness values reproduce with a greater probability than those with lower fitness values, hence the relative frequency of fitter individuals increases over time.
	- Variation is introduced over time via mutation and recombination, this variation gives differences that can be acted on by the selective pressure. Despite this gradual variation, children are always similar to their parents.
 - Genetic Algorithm: A subclass of evolutionary algorithms in which an individual's genome is represented by a sequence/string of numbers.

# Examples

 - [Example 1: Evolving a simple sequence of 'A's](https://github.com/sami016/Genetiq.NET/tree/master/Genetiq.Examples/1_simple_sequence_string_a_count)
 - [Example 2: Evolving a linear classifier](https://github.com/sami016/Genetiq.NET/tree/master/Genetiq.Examples/2_linear_classification_task)
 - [Example 3:]()

# Future

 - Parallelism (multi-deme populations and migration)
 - Coevolution
 - Cooperative evolution

# Core Interfaces

A note on generics: most types within the Genetiq library are parameterised using the genotype type, which represents the type of individual being evolved within the algorithm.

## Environment: populations and how they change.
 - `IPopulation<T>`: A population of individuals/genomes, of fixed size. 
 - `Population<T>`: Basic population of populations.
 - `IPopulationEnvironment<T>`: The environment which may potentially contain multiple environments, determining how these interact.
 - `SimpleEnvironment<T>`: Simple environment with a single population. 
 - `IEpochStrategy`: the strategy of executing a round/epoch (e.g. generational, steady-state).
 - `IShortlistStrategy`: a strategy for shortlisting invidiuals in a generational round strategy (e.g. elitism).

## Epoch execution
 - `EpochProfile<T>`: High level profile for determining how each epoch (round) is executed.
 - `IEpochStrategy<T>`: Strategy determining how a each epoch is executed.
 - `GenerationalEpochStrategy<T>`: Round startegy, where an entire new generation is bred each round.
 - `ITerminationCondition<T>`: Condition determining when execution should complete.
 - `RoundThresholdTerminationCondition<T>`: Termination after a set number of rounds have passed. 

## Selective Process: fitness function and selection approach.
 - `ISelectionProfile<T>`: High level profile determining how selection is performed.
 - `ImplicitSelectionProfile<T>`: Selection profile for implicit fitness functions.
 - `ExplicitSelectionProfile<T>`: Selection profile for explicit fitness functions.
 - `IExplicitFitnessFunction<T>`: A function which maps a genotype to a fitness value.
 - `IImplicitFitnessFunction<T>`: A function which compares two invididuals and returns the most fit.
 - `ISelectionStrategy`: the strategy for selecting individuals based on their fitness values (e.g. tournament).
 
## Variation: Mutation, Recombination
 - `VariationProfile<T>`: High level profile for determining how variation occurs.
 - `IMutator<T>`: A mutation scheme which modifies the genotype passed in.
 - `ICombiner<T>`: A recombination scheme which combines multiple parents to profuce a child.

## Exection
 - `SerialExecutor<T>`: An algorithm executor that runs sequentially on the local machine using a single thread.

# Algorithm profile

 The algorithm profile class if used as a configuration container to be set up before execution.
 An algorithm profile will maintain state between subsequent runs - a factory should be used to create fresh profiles if this is undesirable.

[See Example 1](https://github.com/sami016/Genetiq.NET/tree/master/Genetiq.Examples/1_simple_sequence_string_a_count)

