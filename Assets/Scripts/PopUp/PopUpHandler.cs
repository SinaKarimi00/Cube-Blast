using UnityEngine;


namespace BlastCube.PopUp
{
    public class PopUpHandler
    {

        public void CreatePopUp(string prefabAddress)
        {
            Object.Instantiate(Resources.Load<GameObject>(prefabAddress));
        }
    }
}