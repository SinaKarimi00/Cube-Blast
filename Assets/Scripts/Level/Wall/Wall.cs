

using UnityEngine;


namespace BlastCube.Level.Wall
{
    public abstract class Wall
    {
        protected readonly LevelConfig levelConfig;
        protected readonly LevelFrame levelFrame;

        protected Wall(LevelConfig levelConfig, LevelFrame levelFrame)
        {
            this.levelConfig = levelConfig;
            this.levelFrame = levelFrame;
        }
        protected GameObject GetPrefab(string prefabAddress) => Resources.Load<GameObject>(prefabAddress);

        public virtual void Create() { }
    }
}