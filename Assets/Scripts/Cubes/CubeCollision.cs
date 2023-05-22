using UnityEngine;


namespace BlastCube.Cubes
{
    public class CubeCollision : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            Cube mainCube = GetComponent<Cube>() ? GetComponent<Cube>() : null;
            Cube collisionCube = collision.gameObject.GetComponent<Cube>() ? collision.gameObject.GetComponent<Cube>() : null;
            if (mainCube != null && collisionCube != null)
            {
                EventManager eventManager = new EventManager();
                eventManager.Propagate(new OnCrash(mainCube, collisionCube));
            }
        }
    }
}