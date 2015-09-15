namespace Labyrinth
{
    using System;

    public static class AppStart
    {
        public static void Main()
        {
            LabyrinthProcesor processor = new LabyrinthProcesor();

            while (true)
            {
                ConsoleWritter.ShowLabyrinth(processor.Matrix);
                processor.ShowInputMessage();
                string input;
                input = Console.ReadLine();
                processor.HandleInput(input);
            }
        }
    }
}
