using UnityEngine;


namespace BlastCube.Level.Wall
{
    public class RightWall : Wall
    {
        public RightWall(LevelConfig levelConfig, LevelFrame levelFrame) : base(levelConfig, levelFrame)
        {
        }

        public override void Create()
        {
            for (int z = 0; z < levelConfig.GridHeight; z++)
            {
                for (int y = 0; y < 5; y++)
                    Object.Instantiate(GetPrefab("wall"), new Vector3(levelConfig.GridWidth, y, z),
                                       Quaternion.identity, levelFrame.RightWallParent);
            }
        }
    }
}