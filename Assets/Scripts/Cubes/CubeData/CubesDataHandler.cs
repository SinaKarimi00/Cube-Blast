using System.Collections.Generic;
using UnityEngine;


namespace BlastCube.Cubes
{
    public class CubesDataHandler
    {
        private static int id = 0;
        public static readonly Dictionary<GameObject, int> GeneratedCubes = new Dictionary<GameObject, int>();
        public static readonly List<int> ExistValues = new List<int>();

        public static int GetId()
        {
            return id;
        }

        public static void SaveCubeData(CubeData cubeData)
        {
            id++;
            GeneratedCubes.Add(cubeData.CubeGameObject, cubeData.CubeValue);
            if (!ExistValues.Contains(cubeData.CubeValue))
                ExistValues.Add(cubeData.CubeValue);
        }
    }
}