# Example 2: Linear classification task

This examples shows a simple linear classifier evolving to classify a set of data points.

As an easy example, the set of coordinates for all cities in the UK and France have been provided, which are used to evolve a classifier to recognise country based on position.

Individuals are represented by a sequence of doubles, these values define a hyperplane which can be used for classification between two classes.
The third term in the sequence is used as a bias term (proportional with `-c` in the equation `y = mx+c`).
```
v(x, y) = s[0] * x +  s[1] * y + s[2] * 1;
```

In order to classify, we evaluate a given point and select a class based on the sign of the output.

```
if v(x, y) is greater than 0:
	class = CLASS_1
otherwise:
	class = CLASS_2
```

This definition would prove problematic for an evolutionary process, given that it is a discrete function with no gradient to guide selection.
We therefore define a fitness function that provides a more traversible fitness landscape:

```
fitness(x):
	if class == CLASS_1
	{
		// When data is in class 1, reward negative values.
		return Math.Min(-result, 10));
	}
	else
	{
		// When data is in class 2, reward positive values.
		return Math.Min(result, 10));
	}
```

Fitness score is limited to a maximum of 1, since we only wanting answers to have the correct sign, and neglecting to do this would introduce a selective pressure for larger weights to evolve artificially.