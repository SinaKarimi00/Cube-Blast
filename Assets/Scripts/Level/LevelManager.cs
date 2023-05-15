using BlastCube.Base;
using BlastCube.Cubes;
using UnityEngine;


namespace BlastCube.Level
{
    public class LevelManager : IManager
    {
        public void InitializeGameObject()
        {
            int levelNumber = 2;
            LevelConfig levelConfig = Resources.Load<LevelConfig>($"LevelConfigs/Level{levelNumber}");
            GridGenerator gridGenerator = new GridGenerator();
            gridGenerator.CreateFrame(levelConfig);
            CreateBlastCube(gridGenerator.LevelFrameComponent(), levelConfig);
        }

        private void CreateBlastCube(LevelFrame levelFrameComponent, LevelConfig levelConfig)
        {
            string cubePrefabAddress = "cube";
            Transform blastCubeParent = levelFrameComponent.BlastCubesParent;
            CubeGenerator cubeGenerator = new CubeGenerator();
            foreach (CubeData cube in levelConfig.Cubes)
                cubeGenerator.GenerateCube(GetCubePrefab(), cube, blastCubeParent);


            GameObject GetCubePrefab() => Resources.Load<GameObject>(cubePrefabAddress);
        }
    }
}