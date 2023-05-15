using System.Collections.Generic;
using System.Linq;
using BlastCube.Base;
using UnityEngine;


namespace BlastCube
{
    public class Main : MonoBehaviour
    {
        private readonly List<IUpdater> updateNeededElements = new List<IUpdater>();

        private void Awake()
        {
            List<IManager> managers = new List<IManager>();
            ManagersFactory managersFactory = new ManagersFactory();
            managers.AddRange(managersFactory.CreateManagerInstances());
            Initialize(managers);
            updateNeededElements.AddRange(GetUpdateNeededElements());

            List<IUpdater> GetUpdateNeededElements() => managers.OfType<IUpdater>().ToList();
        }

        private void Initialize(List<IManager> managers)
        {
            foreach (IManager manager in managers)
                manager.InitializeGameObject();
        }

        private void Update()
        {
            foreach (var item in updateNeededElements)
                item.Updater();
        }
    }
}