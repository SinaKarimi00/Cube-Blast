using BlastCube.Cubes;
using UnityEngine;


namespace BlastCube.Level
{
    public class FinalLineCollision : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Cube>())
            {
                Cube cube = other.GetComponent<Cube>();
                if (cube.CanPass)
                    cube.CanPass = false;

                else
                {
                    EventManager eventManager = new EventManager();
                    eventManager.Propagate(new OnCubeCrossing());
                }
            }
        }
    }
}