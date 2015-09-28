using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Labyrinth.Renderer;

namespace Labyrinth.Commands
{
    class GameCommand : Command
    {
        private LabyrinthProcesor labyrinthProcesor;
        private IScoreBoardObserver scoreboardHandler;
        private IRenderer renderer;
        private string command;

        public GameCommand(LabyrinthProcesor labyrinthProcesor, IScoreBoardObserver scoreboardHandler, IRenderer renderer, string command)
        {
            this.labyrinthProcesor = labyrinthProcesor;
            this.scoreboardHandler = scoreboardHandler;
            this.renderer = renderer;
            this.command = command;
        }

        public override void Execute()
        {
            switch (this.command)
            {
                case "top": scoreboardHandler.ShowScoreboard(); break;

                case "restart": labyrinthProcesor.Restart(); break;

                case "exit": renderer.ShowMessage(Messenger.GoodBye); System.Environment.Exit(0); break;

                default: renderer.ShowMessage(Messenger.InvalidMoveMessage); break;
            }
        }
    }
}
