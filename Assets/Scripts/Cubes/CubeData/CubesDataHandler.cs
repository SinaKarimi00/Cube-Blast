using System.Collections.Generic;


namespace BlastCube.Cubes
{
    public class CubesDataHandler
    {
        private static int id = 0;
        public static readonly List<Cube> GetGeneratedCubes = new List<Cube>();
        public static readonly List<int> ExistValues = new List<int>();

        public static int GetId()
        {
            return id;
        }

        public static void SaveCubeData(Cube cube)
        {
            id++;
            GetGeneratedCubes.Add(cube);
            if (!ExistValues.Contains(cube.CubeData.CubeValue))
                ExistValues.Add(cube.CubeData.CubeValue);
        }
    }
}