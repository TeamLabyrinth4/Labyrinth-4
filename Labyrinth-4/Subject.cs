namespace Labyrinth
{
    using Labyrinth.Users;
    using System.Collections.Generic;

    public abstract class Subject
    {
        protected readonly List<IScoreBoardObserver> observers = new List<IScoreBoardObserver>();

        public void Attach(IScoreBoardObserver observer)
        {
            this.observers.Add(observer);
        }

        public void Detach(IScoreBoardObserver observer)
        {
            this.observers.Remove(observer);
        }

        public abstract void Notify(IPlayerCloneable player);
    }
}
