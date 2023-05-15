using UnityEngine;


namespace BlastCube.Cubes
{
    public class CubeCollision : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (GetComponent<Cube>() && collision.gameObject.GetComponent<Cube>())
            {
                EventManager eventManager = new EventManager();
                CubeData mainCubeModel = GetComponent<Cube>().CubeData;
                CubeData colliderCubeModel = collision.gameObject.GetComponent<Cube>().CubeData;
                eventManager.Propagate(new OnCrash(mainCubeModel, colliderCubeModel));
            }
        }
    }
}