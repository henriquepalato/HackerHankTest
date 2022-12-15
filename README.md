# Busy beaver

A very busy beaver is placed in the center of a forest represented by a rectangular N x M 2D matrix. The values of the matrix will represent numbers of logs available to the beaver to build its dam. If the forest does not have an exact center, the beaver should start in the square closest to the center with the highest log count.

On a given turn, the beaver will collect the logs available in the square that it is on, then move up, down, left or right, choosing the square that has the most logs. If there are no logs left on any of the adjacent squares, the beaver will stop working. You may assume that the beaver will never have to choose between two squares with the same number of logs.

Write a function which takes a forest matrix and returns the number of logs the beaver collects. You may assume the matrix is rectangular with at least 1 row and 1 column, and that it is populated with non-negative integers.

The test case in this question is provided only as a convenience so that you may run and test your code. The task given here is not an example of real-world work, so we will not grade your submission based only on its numerical output or correctness in particular test cases. However, how you accomplish the task and the decisions you make in writing your submission are demonstrations of real-world skills, and the submission will be graded on its overall correctness, quality, and design.

Example:

````
Forest matrix:

2 1 3 2 4
2 0 2 0 1
6 2 1 3 0
3 1 0 4 3
````

Solution:

The beaver has collected 12 logs.

Walkthrough:

In the following visualizations, the beaver is represented by an X and the adjacent squares are underlined.

The forest has an odd number of columns, so the beaver will start in the exact middle column (the third from the left). However, there are an even number of rows, so the beaver will inspect the two middle values (the 2 from the second row and the 1 from the third row) and start in the square with the greater number of logs. After this, the beaver and its adjacent squares are:

````
2 1 3 2 4
2 0 X 0 1
6 2 1 3 0
3 1 0 4 3
````

The beaver collects the 2 logs there, leaving 0 behind, and then proceeds as follows through the forest. Of the adjacent four squares with values 3, 0, 1, and 0, the beaver moves up to where there are 3 logs, collects them, and has a total of 5 logs now.

````
2 1 X 2 4
2 0 0 0 1
6 2 1 3 0
3 1 0 4 3
````

Of the adjacent three squares (within the forest's boundary) with values 2, 0, and 1, the beaver moves right to where there are 2 logs, collects them, and has a total of 7 logs now.

````
2 1 0 X 4
2 0 0 0 1
6 2 1 3 0
3 1 0 4 3
````

Of the adjacent three squares with values 4, 0, and 0, the beaver moves right to where there are 4 logs, collects them, and has a total of 11 logs now.

````
2 1 0 0 X
2 0 0 0 1
6 2 1 3 0
3 1 0 4 3
````

Of the adjacent two squares with values 1 and 0, the beaver moves down to where there is 1 log, collects it, and has a total of 12 logs now.

````
2 1 0 0 0
2 0 0 0 X
6 2 1 3 0
3 1 0 4 3
````

All three of the adjacent squares have no logs in them, so the beaver will stop working, having collected a total of 12 logs.
