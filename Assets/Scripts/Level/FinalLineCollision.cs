using BlastCube.Cubes;
using UnityEngine;


namespace BlastCube.Level
{
    public class FinalLineCollision : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Cube cube = other.GetComponent<Cube>() ? other.GetComponent<Cube>() : null;

            if (cube != null)
            {
                if (cube.CanPass)
                    cube.CanPass = false;

                else
                {
                    EventManager eventManager = new EventManager();
                    eventManager.Propagate(new OnCubeCrossing());
                }
            }
        }

        private void OnTriggerStay(Collider other)
        {
            Cube cube = other.GetComponent<Cube>() ? other.GetComponent<Cube>() : null;
            if (cube != null && cube.Collided)
            {
                EventManager eventManager = new EventManager();
                eventManager.Propagate(new OnCubeCrossing());
                cube.Collided = false;
            }
        }
    }
}