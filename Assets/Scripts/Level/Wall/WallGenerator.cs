using System.Collections.Generic;


namespace BlastCube.Level.Wall
{
    public class WallGenerator
    {
        private readonly List<Wall> walls = new List<Wall>();

        public WallGenerator(LevelConfig levelConfig, LevelFrame levelFrame)
        {
            WallFactory wallFactory = new WallFactory();
            walls.AddRange(wallFactory.CreateInstances(levelConfig, levelFrame));
        }

        public void CreateWalls()
        {
            foreach (Wall wall in walls)
                wall.Create();
        }
    }
}