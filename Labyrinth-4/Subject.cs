namespace Labyrinth
{
    // TODO : Should be renamed and movein in some folder (e.t ScoreTableObserver)

    using System.Collections.Generic;
    using Labyrinth.Users;

    public abstract class Subject
    {
        public List<IScoreBoardObserver> Observers = new List<IScoreBoardObserver>();

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
}
