namespace BlastCube.Base
{
    public interface IListener
    {
        public void HandleEvent(IEvent invokedEvent);
    }
}