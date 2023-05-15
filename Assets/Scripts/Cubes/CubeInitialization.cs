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

        public GameObject InitializeMergedCube(Cube shotCube, Cube collisionCube)
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

        public GameObject InitializeShootAbleCube(GameObject cubeParentObject)
        {
            CubeGenerator cubeGenerator = new CubeGenerator();
            CubeData cubeData = new CubeData();
            cubeData.InitializeCubePosition = CubePosition();
            Transform cubeParent = cubeParentObject.transform;
            GameObject cube = cubeGenerator.GenerateCube(GetCubePrefab(), cubeData, cubeParent);
            cube.GetComponent<Cube>().CanPass = true;
            return cube;

            Vector3 CubePosition() => cubeParentObject.transform.position + new Vector3(0f, 0f, 1f);
            GameObject GetCubePrefab() => Resources.Load<GameObject>("cube");
        }
    }
}