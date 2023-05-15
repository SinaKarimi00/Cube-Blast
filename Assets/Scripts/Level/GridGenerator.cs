using BlastCube.Level.Wall;
using UnityEngine;


namespace BlastCube.Level
{
    public class GridGenerator
    {
        private LevelFrame levelFrameComponent;

        public void CreateFrame(LevelConfig levelConfig)
        {
            GameObject levelFrame = Object.Instantiate(GetPrefab("Levels/LevelFrame"));
            levelFrameComponent = levelFrame.GetComponent<LevelFrame>();
            CreateLand(levelConfig);
            WallGenerator wallGenerator = new WallGenerator(levelConfig, levelFrameComponent);
            wallGenerator.CreateWalls();
        }

        private void CreateLand(LevelConfig levelConfig)
        {
            Transform landsTransform = levelFrameComponent.LandsParent;
            int finalLineWidth = 3;
            int middleOfWidth = levelConfig.GridWidth / 2;
            int middleOfHeight = levelConfig.GridHeight / 2;
            for (int x = 0; x < levelConfig.GridWidth; x++)
            {
                for (int z = 0; z < levelConfig.GridHeight; z++)
                {
                    if (z == finalLineWidth && x == middleOfWidth)
                    {
                        GameObject finalLine =
                            Object.Instantiate(GetPrefab("FinalLine"), new Vector3(x, 0f, z), Quaternion.identity, landsTransform);
                        ManageCollider(finalLine, 4, 1);
                    }
                    else
                    {
                        GameObject generatedLand =
                            Object.Instantiate(GetPrefab("land"), new Vector3(x, 0f, z), Quaternion.identity, landsTransform);

                        if (x == middleOfWidth && z == middleOfHeight)
                            ManageCollider(generatedLand, 1, levelConfig.GridHeight);
                    }
                }
            }

            void ManageCollider(GameObject generatedLand, int colliderHeight, int gridHeight)
            {
                BoxCollider collider = generatedLand.GetComponent<BoxCollider>();
                collider.enabled = true;
                collider.size = new Vector3(levelConfig.GridWidth, colliderHeight, gridHeight);
            }
        }

        private GameObject GetPrefab(string prefabAddress) => Resources.Load<GameObject>(prefabAddress);

        public LevelFrame LevelFrameComponent()
        {
            return levelFrameComponent;
        }
    }
}