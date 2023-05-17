using UnityEngine;


namespace BlastCube.Cubes
{
    public class CubeInitialization
    {
        private readonly GameObject cubePrefab;

        public CubeInitialization()
        {
            cubePrefab = Resources.Load<GameObject>("cube");
        }

        public Cube InitializeMergedCube(Cube shotCube, Cube collisionCube)
        {
            CubeGenerator cubeGenerator = new CubeGenerator();
            CubeData mergedCubeData = new CubeData();
            mergedCubeData.CubeValue = shotCube.CubeData.CubeValue * 2;
            mergedCubeData.InitializeCubePosition = NewCubePosition();
            return cubeGenerator.GenerateCube(cubePrefab, mergedCubeData, GetParent());

            Vector3 NewCubePosition()
            {
                if (shotCube.CubeData.Id > collisionCube.CubeData.Id)
                    return collisionCube.CubePosition;

                return shotCube.CubePosition;
            }

            Transform GetParent() => collisionCube.ParentTransform;
        }

        public void InitializeShootAbleCube(GameObject cubeParentObject)
        {
            CubeGenerator cubeGenerator = new CubeGenerator();
            CubeData cubeData = new CubeData();
            cubeData.InitializeCubePosition = CubePosition();
            Transform cubeParent = cubeParentObject.transform;
            Cube cube = cubeGenerator.GenerateCube(GetCubePrefab(), cubeData, cubeParent);
            cube.CanPass = true;

            Vector3 CubePosition() => cubeParentObject.transform.position + new Vector3(0f, 0f, 1f);
            GameObject GetCubePrefab() => Resources.Load<GameObject>("cube");
        }
    }
}