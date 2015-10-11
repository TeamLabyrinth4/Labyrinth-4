# Team Labyrinth-4 Refactoring Documentation.
=============================================

Team Labyrinth-4 members:
  - Emil Tishinov
  - Teodor Cholakov
  - Chavdar Angelov
  - Ivaylo Andonov

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
    - Messages:
    	- public const string GoodBye = "Good bye!";
        - public const string InvalidMoveMessage = "Ups, wrong command!";
        - public const string WelcomeMessage = " Welcome to “Labirinth” game.Just try to escape from out Labirinth ! You can use next commands:\n -'top' to view the top scoreboard\n -'restart' to start a new game\n -'save' to save current position\n -'restore' to restore saved position\n -'newplayer' to set a new player\n -'exit' to quit the game.";
        - public const string InputMessage = "\nEnter your move (L=left, R-right, U=up, D=down): ";
        - public const string ChangePlayer = "Please Enter a new Name for the Player";
        - public const string Save = "Position Saved!";
        - public const string Load = "Position Restored!";
        - public const string Positions = "At position: X:{0},Y:{1}";
        - public const string Restarted = "New game started !\n" + - -WelcomeMessage; 

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

<code>
	string Name { get; set; }</br>
	int Score { get; set; }</br>
	int PositionRow { get; set; }</br>
	int PositionCol { get; set; }</br>
</code>

 which substitute<br/>
 <code>private IList<Tuple<uint, string>> scoreboard;</code><br/>

Also the Labyrint matrix no longer knows about the player position.

2. The Main method is extracted from the class ConsoleWritter and put in separate class AppStart. 

3. In method HandleScoreboard(int moveCount) in Top5Scoreboard class
the logic for recording the top players is improved by substitution of a for loop with a LINQ:
this.scoreboard = this.scoreboard.OrderBy(x => x.Score).ToList()</code>;

4. New classes ScoreBoardHandler, LocalScoreBoard and new interface IScoreboard are introduced. LocalScoreBoard implements the new interface with the methods:

<code>
void AddToScoreBoard(IPlayer player);<br/>
IList<IPlayer> ReturnCurrentScoreBoard();
</code>;<br/>

ScoreBoardHandler has an instance of the LocalScoreBoard recorded in it.
ScoreBoardHandler has method HandleScoreboard which calls the new method AddToScoreBoard from LocalScoreBoard. ShowScoreboard() calls ReturnCurrentScoreBoard.

5. IRenderer interface added. The concrete implementation of this new interface is through the ConsoleRenderer class. This class has methods for all the logic of the game for the UI. This separation of the UI logic follows the Single responsibility principle. Now all the other classes when has to use the console they use method from this class. In the final version this class implements three methods: ShowLabyrinth(), AddInput() and ShowMessage(). There are several messages which could be passed to ShowMessage() method. Class for the messages is introduced where we have a couple of constants to keep the strings. Also it is possible to change the ConsoleRenderer with some different UI platform. This is implementation of the open-closed principle with strategy pattern. The other classes use instance of IRenderer - not the concrete implementation.  

- - - -

## Step 3: Introduction of Design Patterns

### Creatinal Patterns

##### Builder Pattern:

Implemented to create all the needed initial game objects, respecrting all dependencies between them in order to create the Game Engine.

What kind of objects will be created:

~~~c#
 public interface IGameObjectBuilder
    {
        IRenderer CreteRenderer();

        IPlayer CreatePlayer();

        IScoreboard CreateScoreboard();

        IScoreBoardObserver CreteScoreBoardHanler(IScoreboard scoreboard);

        LabyrinthMatrix CreateLabyrinthMatrix();

        string GetUserName();
    }
~~~ 

The Direcotr class:

~~~c#
 public GameEngine SetupGame(IGameObjectBuilder objectBuilder)
        {
            this.renderer = objectBuilder.CreteRenderer();
            this.player = objectBuilder.CreatePlayer();
            this.scoreboard = objectBuilder.CreateScoreboard();
            this.scoreBoardHandler = objectBuilder.CreteScoreBoardHanler(this.scoreboard);
            this.matrix = objectBuilder.CreateLabyrinthMatrix();

            return GameEngine.Instance(this.player, this.renderer, this.scoreBoardHandler, this.matrix);
        }
~~~


Usage:

~~~c#
 var constructor = new GameConstructor();
 var gameBuilder = new ConsoleSizeableGameBuilder(new SimpleConsoleGameBuilder());
 var game = constructor.SetupGame(gameBuilder);
~~~ 

##### Singleton Pattern:

Used for the GameEngine, because we need only one istnce of this object.

~~~c#
public static GameEngine Instance(IPlayer player, IRenderer renderer, IScoreBoardObserver scoreboard, LabyrinthMatrix matrix, Messages messages)
        {
            if (gameInstance == null)
            {
                lock (syncLock)
                {
                    if (gameInstance == null)
                    {
                        gameInstance = new GameEngine(player, renderer, scoreboard, matrix);
                    }
                }
            }

            return gameInstance;
        }
~~~

##### Prototype Pattern:

Implemented in the Player class. Helps us to keep only one instance of the player within the hole game, the cloning is used when we need to save the player in the database.

~~~c#
 public object Clone()
        {
            // Don't serialize a null object, simply return the default for that object
            if (object.ReferenceEquals(this, null))
            {
                return this;
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();

            using (stream)
            {
                formatter.Serialize(stream, this);
                stream.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(stream);
            }
        }
~~~

##### Factory Method:

Used for creating the ingame commands:
~~~c#
 public interface ICommandFactory
    {
        IContext Context { get; }

        ICommand CreateCommand(CommandType input);
    }


public ICommand CreateCommand(CommandType input)
        {
            if (this.commands.ContainsKey(input))
            {
                return this.commands[input];
            }

            switch (input)
            {
                case CommandType.U:
                    this.commands[CommandType.U] = new MoveUpCommand(this.Context); 
                    break;
                case CommandType.D:
                    this.commands[CommandType.D] = new MoveDownCommand(this.Context); 
                    break;
                case CommandType.R:
                    this.commands[CommandType.R] = new MoveRightCommand(this.Context); 
                    break;
                case CommandType.L:
                    this.commands[CommandType.L] = new MoveLeftCommand(this.Context);
                    break;
                case CommandType.Exit:
                    this.commands[CommandType.Exit] = new ExitCommand(this.Context);
                    break;
                case CommandType.Restart:
                    this.commands[CommandType.Restart] = new RestartCommand(this.Context); 
                    break;
                case CommandType.Top:
                    this.commands[CommandType.Top] = new TopCommand(this.Context); 
                    break;
                case CommandType.Save:
                    this.commands[CommandType.Save] = new SaveCommand(this.Context); 
                    break;
                case CommandType.Restore:
                    this.commands[CommandType.Restore] = new LoadCommand(this.Context); 
                    break;
                case CommandType.Newplayer:
                    this.commands[CommandType.Newplayer] = new NewPlayerCommand(this.Context); 
                    break;
                default:
                    this.commands[CommandType.Restore] = null; 
                    break;
            }

            return this.commands[input];
        }
~~~

Also it masused for creating the player movements and etc.

### Structural Patterns

##### Facade Pattern:

In this project this is the GameEngine class, which hides all complex logic and relation between the object within itself.

~~~c#
private GameEngine(IPlayer player, IRenderer renderer, IScoreBoardObserver scoreboard, LabyrinthMatrix matrix, Messages messages)
        {
            this.messenger = messages;

            this.context = new Context(scoreboard, renderer, player, matrix);
            this.factory = new CommandFactory(this.context);

            this.Attach(this.context.ScoreboardHandler);
            this.context.StartNewGame();
        }
~~~ 

Also implments the core game logic:

~~~c#
public void GameRun()
        {
            while (true)
            {
                this.context.Renderer.ShowLabyrinth(this.context.Matrix, this.context.Player);
                this.ShowInputMessage();
                this.input = this.context.Renderer.AddInput();
                this.HandleInput(this.input);
            }
        }
~~~ 

##### Flyweight Pattern:

Reduceses the creation of new in game objects.

It was used for the player command movemnts:
~~~c#
 public class PlayerFactory
    {
        private static PlayerMovement playerMovement;

        public static PlayerMovement GetPlayer()
        {
            if (playerMovement == null)
            {
                playerMovement = new PlayerMovement();
            }

            return playerMovement;
        }
    }
~~~

Also how the commands are stored:

~~~c#
private readonly Dictionary<CommandType, ICommand> commands = new Dictionary<CommandType, ICommand>();
~~~

##### Decorator Pattern:

Used for adding new functionallity to the game as easy as possible

~~~c#
public class ConsoleSizeableGameBuilder : Decorator
    {
        public ConsoleSizeableGameBuilder(IGameObjectBuilder gameObjectBuilder)
            : base(gameObjectBuilder)
        {
            this.ChangeConsoleWindowSize();
        }

        private void ChangeConsoleWindowSize()
        {
            Console.SetWindowSize(100, 50);
        }
    }
~~~~

### Behavioral Patterns

##### Command Pattern:

It was used to handle all ingame commands

~~~c#
 public interface ICommand
    {
        IContext Context { get; }

        void Execute();
    }
~~~

And a simple example of a command:

~~~c#
public class MoveLeftCommand : ICommand
    {
        public MoveLeftCommand(IContext context)
        {
            this.Context = context;
        }

        public IContext Context { get; private set; }

        public void Execute()
        {
            if (!(this.Context.Player.PositionCol == Constants.MinimalHorizontalPosition) &&
                 this.Context.Matrix.Matrix[this.Context.Player.PositionCol - 1][this.Context.Player.PositionRow] == '-')
            {
                this.Context.Player.MoveLeft();
            }
        }
    }
~~~

##### Observer Pattern:

Helps us to link the event of ending the game with the update of the List of the best players

~~~c#
public abstract class ObserverSubject
    {
        protected readonly List<IScoreBoardObserver> Observers = new List<IScoreBoardObserver>();

        public void Attach(IScoreBoardObserver observer)
        {
            this.Observers.Add(observer);
        }

        public void Detach(IScoreBoardObserver observer)
        {
            this.Observers.Remove(observer);
        }

        public abstract void Notify(IPlayer player);
    }
~~~~

##### Memento Pattern: 

It was used to add new functionality to the game -> option to save the game and to load it.

~~~c#
public class Memento
    {
        public Memento(int score, int positionRow, int positionCol)
        {
            this.Score = score;
            this.PositionRow = positionRow;
            this.PositionCol = positionCol;
        }

        public int Score { get; set; }

        public int PositionRow { get; set; }

        public int PositionCol { get; set; }
    }
~~~
- - - - 

## Step 4: Created Unit Tests

- - - - 

## How SOLID Principles are followed:

1. Single responsibility principle
	* Classes are focused on performing only one task 
	* For example the playfield does not know how it is drawn
	* Separate in-game saver - Memento pattern

2. Open/closed principle
	* The code relies on a Interfaces not on a concrete classes, they can be easily replaced with new ones.
	* The core game logic does not rely on if-else constructions (Command pattern)
	* New features are added via the Decorator pattern

3. Liskov substitution principle
	* Child classes do not remove base class behaviour or violate base class invariants
	* There is no type checking
	* No virtual methods in class constructors

4. Interface segregation principle
	* Most interfaces are small and focused 
	* There are no classes who does not implement given interface

5. Dependency inversion principle
	* There are no hidden dependencies in constructors.
	* It was used Constructor injection.
	* Limited use of new keyword and static classic and methods.

- - - - 

###### Repo of Team Labyrinth-4 [Link to GitHub](https://github.com/TeamLabyrinth4/Labyrinth-4/tree/master/Labyrinth-4)