namespace Labyrinth.Commands
{
    using Labyrinth.Renderer;
    using System;
    using Users;

    class GameCommand : Command
    {
        private LabyrinthProcesor labyrinthProcesor;
        private IScoreBoardObserver scoreboardHandler;
        private IRenderer renderer;
        private IPlayerCloneable player;
        private string command;

        public GameCommand(LabyrinthProcesor labyrinthProcesor, IScoreBoardObserver scoreboardHandler, IRenderer renderer, IPlayerCloneable player, string command)
        {
            this.labyrinthProcesor = labyrinthProcesor;
            this.scoreboardHandler = scoreboardHandler;
            this.renderer = renderer;
            this.player = player;
            this.command = command;
        }

        public override void Execute()
        {
            switch (this.command)
            {
                case "top": scoreboardHandler.ShowScoreboard();
                    break;

                case "restart": labyrinthProcesor.Restart();
                    break;

                case "exit": renderer.ShowMessage(Messenger.GoodBye); System.Environment.Exit(0);
                    break;

                case "newplayer": renderer.ShowMessage(Messenger.ChangePlayer);
                    AddNewPlayer();
                    break;

                default: renderer.ShowMessage(Messenger.InvalidMoveMessage);
                    break;
            }
        }

        private void AddNewPlayer()
        {
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();
            this.player.Name = userName;
            labyrinthProcesor.Restart();
        }
    }
}
