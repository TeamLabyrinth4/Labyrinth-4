namespace Labyrinth
{
    using System.Collections.Generic;

    using Labyrinth.Users;

    public abstract class Subject
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

        public abstract void Notify(IPlayerCloneable player);
    }
}
