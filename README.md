# Team Labyrinth-4 Refactoring Documentation.
=============================================

Team Labyrinth-4 members:
  - Emil Tishinov
  - Teodor Cholakov
  - Chavdar Angelov
  - Ivaylo Andonov
  - Vasil Profirov
  - Vasil Pavlov 

- - - -

## Step 1: Initial Tasks 

1. __Renamed variables:__

2. __Introduced constants:__

3. __Fixed StyleCop Issues:__

* Fixed Warning: CSharp.Spacing : The spacing around keywords and symbols, multiple empty rows and etc.
* Fixed Warning CSharp.Readability : Extensive use of 'this.' to indicate that the item is a member of the given class.	
* Fixed Warning CSharp.Ordering : All using directives are placed inside of the namespace. Methods have proper ordering depending on their access modifier
* Fixed CSharp.Naming : All method names begin with an upper-case letter.
* Fixed CSharp.Maintainability : All classes, fields and methods have an access modifier.
* Fixed CSharp.Layout : Curly brackets are properly placed, Blank lines are introduced where needed and etc.

4. __Introduced New Methods:__

* the method private char[][] CreateMatrix() is moved outside the LabyrinthMatrix() constructor;
* the metohd private char GetRandomSymbol() is moved outside the LabyrinthMatrix() constructor;

At the start most of the methods are already separated, so only parts of the code were moved outside the construcotrs of certain objects.

- - - -

## Step 2: Creating Class Abstraction And Game Logic Separation

1. __Expample 1:__ (Replace example with the Introduced new interface IPlayer and so on)

- - - -

## Step 3: Introduction of Design Patterns

### Creatinal Patterns

1. __Builder Pattern:__

2. __Singleton Pattern:__

3. __Prototype Pattern:__ 

4. __Factory Method:__

### Structural Patterns

5. __Facade Pattern:__

6. __Flyweight Pattern:__

7. __Decorator Pattern:__

### Behavioral Patterns

8. __Command Pattern:__

9. __Observer Pattern:__

10. __Memento Pattern:__

- - - - 

## Step 4: Created Unit Tests

- - - - 

## SOLID Principles

1. Single responsibility principle
	* 

2. Open/closed principle
	* 

3. Liskov substitution principle
	* 

4. Interface segregation principle
	* 

5. Dependency inversion principle
	* 

- - - - 

###### Repo of Team Labyrinth-4 [Link to GitHub](https://github.com/TeamLabyrinth4/Labyrinth-4/tree/master/Labyrinth-4)