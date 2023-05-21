# Computational Geometry Seminars

## About

Primary Author: H-Tudor

Date of publish: 21.05.2023

This repository contain all^ the solutions to the "Computational Geometry" seminars in a single C# Solution in a Structured Project. (^ at this time not all solutions are include due to not existing).

Bellow you will find:
- the project map (with descriptions)
- the project workflow
- the project strategy

## Project Map

```
GC Main (folder, contains all the code)
	|--- Engine (folder, contains general algorithms that operate with an array of points and fulfil various tasks)
	|		|--- LineComparer (folder)
	|		|		|--- Polar.cs (file, IComparer, compares lines according to their polar angel / position relative to their first point if it is the same)
	|		|		|--- SegmentLength.cs (file, IComparer, compares lines according to their lengths (euclidian distace between points)
	|		|--- PointComparer (folder)
	|		|		|--- CrossProduct.cs (file, IComparer, compares points according to result of the determinat of the matrix composed of their coordinates)
	|		|		|--- DownLeft.cs (file, IComparer, compares points according to their position, criteria_1: down, if on equal Y, criteria_2: left)
	|		|		|--- Left.cs (file, IComparer, compares points according to their position, criteria_1: left, if on equal X, criteria_2: down)
	|		|--- ConvexHull.cs (file, static class, containss all convex hull algorithms for an array of points)
	|		|--- LineComparers.cs (file, static class, contains a instances of each class in Line Comparer)
	|		|--- PointComparers.cs (file, static class, contain a instance of each class in Point Comparer)
	|		|--- PointOperations.cs (file, static class, contains methods for operating with points)
	|		|--- PolygonOperations.cs (file, static class, contians methods for operating with points that are considerd a polyogon)
	|		|--- TriangleOperations.cs (file, static class, contains methods for operating with points that are considerd a triangle)
	|		|--- TriangulationOperations.cs (file, static class, contains methods for triangulating an array of points)
	|--- Manager (folder, contains folders for each day (set of exercises) and within them files for each exercise, named according to the exercise)
	|--- Resource (folder, contains model classes (classes that store data or model concepts))
	|		|--- Config.cs (file, static class, contains the array of array of exercises (each sub array is a set of exercises / a day))
	|		|--- Line.cs (file, contains the "Line" class)
	|		|--- Point.cs (file, contains the "Point" class (distinct to System.Drawing.Point))
	|--- UI (folder, contains the Graphic User Interface elements)
	|		|--- GraphicsHandler.cs (file, contains the "GraphicsHandler" class, which is the only class used to interact with the canvas (picture box) in the form)
	|		|--- MainForm.cs (file, contains the "MainForm" class that define the form's functionalities
	|		|--- MainForm.Designer.cs (file, initialises the form elements)
	|--- GC.csproj (file, project header)
	|--- Program.cs (file, app entry point)

```

## Project Workflow

When adding a new exercise:
1. Go to Mangers and check if the desired day's folder exists (if not, create it) then
2. In the day's folder, create a class named after the exercise's main task and make this class implement the "IExercise" interface
3. In the manager class, you:
	- prepare your variables
	- call the appropriate general algorithm from Engine (if it does not exist, add it, respecting the structure)
	- call the appropriate graphics handler draw method (if by some chance it does not exist, add it)
4. Add the class in the appropriate sub-array in the "Config.cs" file located in the "Resource" folder

## Project Strategy

In this project we make heavy use of the "Strategy" pattern in the sense that:
- for the same type of task, all functions will have the same parameters only different names
- the project is open for extension but closed for modification due to the implemented infrastructure

For this reason:
- the System.Drawing module is only imported and used in the GraphicsHandler module, the only module responsible for determining how to draw on the canvas
- the only valid method to run a exercise is to have a class implementing IExercise added in a Config.cs sub-array (array contained in the EXERCISES array / jagged array)
- specific methods for calculating the triangle area are called from the general triangle area method (important principle)

When it comes to code-style:
- the pre-existing code style is the goal / standard
- the general settings are:
	- respect the naming guide
	- for indentation, use TABS instead of SPACES
	- before / after each property / method leave an empty line (besides the number of references
	- for every type of code block / structure (if, for, while, methods, classes etc) the opening brace is on the same line as structure declaration (disable all "place opening brace on a new line options in the settings)
	- for properties, if they are auto implementing (ex: if they don't declare a body for get / set) leave them on a single line
	- respect spacing (ex: between operands and operators)

When it comes to naming:
- the adhered style is python's naming conventions:
	- **lower_underscore**: variables & fields 
	- **UPPER_UNDERSCORE**: constants & hard-coded values
	- **CamelCase**: properties, methods, classes & files
- if the names are part of the public API, they have to be meaningful, else they can be shortened.

When it comes to Fields vs. Properties:
- Fields: static classes  
- Properties: normal classes (property's privacy: public read / private write (or protected if necessary))

When it comes to task organization, consider a day is as a ProductBacklogItem (PBI) and an exercise is a task from that PBI

When it comes to contributing and pushing your commits:
- clone the repository and create your separate branch/es as follows: 
	- one branch per exercise (even though you plan on doing more
	- the branch name should be something as follows: "/{username}/{day}/{exercise}"
- after adding your code to the separate branch, change branch to master and pull from the repository
- resolve merge conflicts on your local branch and make sure the code style matches the guide 
- push after completing a full day / set3


## Other details

For clarification: these solutions are to the "Computational Geometry" class seminars at the University of Oradea, Faculty of Informatics and Sciences - "Informatics" program, year 1 semester 2.
As of the writing of this file, they are work in progress.
Contribution to this repository should be done by those that took the aforementioned class and are familiar with these exercises, but other than that, if these algorithms helped you, leave a star.
