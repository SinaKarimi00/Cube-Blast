using System.Collections.Generic;
using BlastCube.Base;
using BlastCube.GameMind;
using BlastCube.Level;
using BlastCube.Player;


namespace BlastCube
{
    public class ManagersFactory
    {
        public List<IManager> CreateManagerInstances()
        {
            List<IManager> managerClasses = new List<IManager>();

            managerClasses.Add(new LevelManager());
            managerClasses.Add(new PlayerManager());
            managerClasses.Add(new MergeManager());
            managerClasses.Add(new EndGameManager());

            return managerClasses;
        }
    }
}