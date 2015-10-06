namespace Labyrinth.ObjectBuilder
{
    using Labyrinth.Renderer;
    using Labyrinth.Users;

    public interface IGameObjectBuilder
    {
        IRenderer CreteRenderer();

        IPlayer CreatePlayer();

        IScoreBoardObserver CreteScoreBoardHanler();

        Messages CreateMessages();
    }
}
