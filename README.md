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

1. __Initial commit reformatting:__ We received a solution with name KPK_PROEKT which we renamed to Labyrinth-Game. Along with this solution we alse received 5  files. The refactoring in each one of these are:

	- top5score.cs:    
		- moving the using directives under the namespace
		- region with field for the scoreboard list removed;
		- added keyword this in front of scoreboard property; 
	- LabyrinthMatrix: 
		- moving the using direvtives under the namespace;
		- added keyword this in front of fields myPositionVertical, myPositionHorizontal and Matrix;
		- removed empty lines where necessary; 
	- LabyrinthProcesor.cs:
		- moving the using directives under the namespace;
		- added keyword this in front of fields; 
		- added keyword this in front of used internal for the class methods - moveUp, moveDown, moveRight, moveLeft, isFinished, movecount; 
		- rename the methods moveUp, moveDown, moveRight, moveLeft, isFinished to be with capital letter;
		- regions for properties, fields and methods removed;
		- "String" class is substituted with "string"; 
		

2. __Introduced constants:__
	- top5score.cs 
		- private const int MaxScorebordSize = 5;
	- LabyrinthMatrix: 
		- public const int StartPositionVertical = 3;
	    - public const int StartPositionHorizontal = 3;
		- public const int MatrixRows = 7;
		- public const int MatrixCols = 7;
	-  LabyrinthProcesor.cs:
		- public const int MaximalHorizontalPosition = 6;
        - public const int MinimalHorizontalPosition = 0;
        - public const int MaximalVerticalPosition = 6;
        - public const int MinimalVerticalPosition = 0;
 

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

1. Introduced class Player and interface IPlayer with properties:
<code>string Name { get; set; }<br/>
        int Score { get; set; }<br/>
        int PositionRow { get; set; }<br/>
       int PositionCol { get; set; }</code><br/>
 which substitute<br/>
 <code>private IList<Tuple<uint, string>> scoreboard;</code><br/>
 with<br/>
<code>private IList<IPlayer> scoreboard;</code><br/>
in class top5score. Now we can store data in the player in a separate place.
2. The Main method is extracted from the class ConsoleWritter and put in separate class AppStart. 
3. In method HandleScoreboard(int moveCount) in Top5Scoreboard class
the logic for recording the top players is improved by substitution of a for loop with a LINQ:
<code>this.scoreboard = this.scoreboard.OrderBy(x => x.Score).ToList()</code>;
4.
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