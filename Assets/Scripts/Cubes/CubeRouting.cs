using System.Linq;
using UnityEngine;


namespace BlastCube.Cubes
{
    public class CubeRouting
    {
        public Vector3 GetRoute(int cubeValue, GameObject currentGameObject)
        {
            int targetValue = cubeValue;
            GameObject destinationObject = CubesDataHandler.GetGeneratedCubes
                                                           .Where(x => !x.CanPass && x.gameObject != currentGameObject)
                                                           .FirstOrDefault(x => x.CubeData.CubeValue == targetValue)
                                                          ?.gameObject;
            if (destinationObject)
                return destinationObject.transform.position;

            return new Vector3(0f, 0f, 0f);
        }
    }
}