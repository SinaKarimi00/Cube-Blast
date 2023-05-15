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

        public GameObject InitializeMergedCube(CubeData shotCubeData, CubeData collisionCubeData)
        {
            CubeGenerator cubeGenerator = new CubeGenerator();
            CubeData mergedCubeData = new CubeData();
            mergedCubeData.CubeValue = shotCubeData.CubeValue * 2;
            mergedCubeData.InitializeCubePosition = NewCubePosition();
            return cubeGenerator.GenerateCube(cubePrefab, mergedCubeData, GetParent());

            Vector3 NewCubePosition()
            {
                if (shotCubeData.Id > collisionCubeData.Id)
                    return collisionCubeData.CubeGameObject.transform.position;

                return shotCubeData.CubeGameObject.transform.position;
            }

            Transform GetParent() => collisionCubeData.CubeGameObject.transform.parent;
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