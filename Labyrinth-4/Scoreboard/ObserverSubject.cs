namespace Labyrinth.Scoreboard
{
    using System.Collections.Generic;

    using Labyrinth.Users;

    /// <summary>
    /// The 'Subject' abstract class which defines the implementation of the Observer pattern.
    /// </summary>
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
}
