using System.Collections.Generic;


namespace BlastCube.Level.Wall
{
    public class WallFactory
    {
        public List<Wall> CreateInstances(LevelConfig levelConfig, LevelFrame levelFrame)
        {
            List<Wall> walls = new List<Wall>();
            walls.Add(new LeftWall(levelConfig, levelFrame));
            walls.Add(new RightWall(levelConfig, levelFrame));
            walls.Add(new FrontWall(levelConfig, levelFrame));
            return walls;
        }
    }
}