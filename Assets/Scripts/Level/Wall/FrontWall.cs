using UnityEngine;


namespace BlastCube.Level.Wall
{
    public class FrontWall : Wall
    {
        public FrontWall(LevelConfig levelConfig, LevelFrame levelFrame) : base(levelConfig, levelFrame)
        {
        }

        public override void Create()
        {
            for (int x = 0; x < levelConfig.GridWidth; x++)
            {
                for (int y = 0; y < 5; y++)
                    Object.Instantiate(GetPrefab("wall"), new Vector3(x, y, levelConfig.GridHeight),
                                       Quaternion.identity, levelFrame.FrontWallParent);
            }
        }
    }
}