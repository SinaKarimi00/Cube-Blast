using System.Collections.Generic;
using BlastCube.Base;


namespace BlastCube.Cubes
{
    public class EventManager
    {
        private static readonly List<IListener> Listeners = new List<IListener>();


        public void Propagate(IEvent generatedEvent)
        {
            foreach (IListener listener in Listeners)
                listener.HandleEvent(generatedEvent);
        }

        public void Register(IListener listener)
        {
            Listeners.Add(listener);
        }
    }
}