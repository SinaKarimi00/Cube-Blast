using System.Linq;
using UnityEngine;


namespace BlastCube.Cubes
{
    public class CubeRouting
    {
        public Vector3 GetRoute(int cubeValue, GameObject currentGameObject)
        {
            int targetValue = cubeValue;
            GameObject destinationObject = CubesDataHandler.GeneratedCubes
                                                           .Where(x => !x.Key.GetComponent<Cube>().CanPass && x.Key != currentGameObject)
                                                           .FirstOrDefault(x => x.Value == targetValue).Key;
            if (destinationObject)
                return destinationObject.transform.position;

            return new Vector3(0f, 0f, 0f);
        }
    }
}