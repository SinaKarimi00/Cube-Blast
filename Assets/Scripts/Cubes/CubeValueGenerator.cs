using UnityEngine;


namespace BlastCube.Cubes
{
    public class CubeValueGenerator
    {
        public int GetNewValue()
        {
            int randValue = CubesDataHandler.ExistValues[Random.Range(0, CubesDataHandler.ExistValues.Count)];
            int maxValue = 64;

            while (randValue > maxValue)
                randValue = CubesDataHandler.ExistValues[Random.Range(0, CubesDataHandler.ExistValues.Count)];

            return randValue;
        }
    }
}