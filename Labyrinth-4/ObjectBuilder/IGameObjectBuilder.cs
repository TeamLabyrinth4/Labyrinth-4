namespace Labyrinth.ObjectBuilder
{
    using Labyrinth.Renderer;    
    using Labyrinth.Users;
    using Scoreboard;

    public interface IGameObjectBuilder
    {
        IRenderer CreteRenderer();

        IPlayer CreatePlayer();

        IScoreboard CreateScoreboard();

        IScoreBoardObserver CreteScoreBoardHanler(IScoreboard scoreboard);

        LabyrinthMatrix CreateLabyrinthMatrix();

        Messages CreateMessages();

        string GetUserName();
    }
}
