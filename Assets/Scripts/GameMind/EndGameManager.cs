using BlastCube.Base;
using BlastCube.Cubes;
using BlastCube.PopUp;


namespace BlastCube.GameMind
{
    public class EndGameManager : IListener, IManager
    {
        public EndGameManager()
        {
            EventManager eventManager = new EventManager();
            eventManager.Register(this);
        }

        public void HandleEvent(IEvent crossingEvent)
        {
            if (crossingEvent is OnCubeCrossing)
            {
                PopUpHandler popUpHandler = new PopUpHandler();
                popUpHandler.CreatePopUp("EndGamePopUp");
            }
        }

        public void InitializeGameObject()
        {
        }
    }
}