using System.Linq;
using BlastCube.Base;
using BlastCube.Cubes;
using UnityEngine;


namespace BlastCube.GameMind
{
    public class MergeManager : IManager, IListener
    {
        public MergeManager()
        {
            EventManager eventManager = new EventManager();
            eventManager.Register(this);
        }

        public void InitializeGameObject()
        {
        }

        public void HandleEvent(IEvent generalEvent)
        {
            if (!(generalEvent is OnCrash onCrashEvent)) return;

            CubeData shotCubeData = onCrashEvent.shotCubeData;
            CubeData collisionCubeData = onCrashEvent.shotCubeData;
            if (ValueCheck() && ExistenceCheck(shotCubeData.CubeGameObject)
                             && ExistenceCheck(collisionCubeData.CubeGameObject))
            {
                CubeInitialization cubeInitialization = new CubeInitialization();
                GameObject mergedCube = cubeInitialization.InitializeMergedCube(shotCubeData, collisionCubeData);
                CubeRouting cubeRouting = new CubeRouting();
                Rigidbody rigidbody = mergedCube.GetComponent<Rigidbody>();
                CubeMovement cubeMovement = new CubeMovement();
                Vector3 destination = cubeRouting.GetRoute(onCrashEvent.shotCubeData.CubeValue * 2, mergedCube);
                cubeMovement.Move(rigidbody, destination);
                RemoveMergedCubes();
            }

            bool ValueCheck() => onCrashEvent.shotCubeData.CubeValue == onCrashEvent.collisionCubeData.CubeValue;

            bool ExistenceCheck(GameObject goalCube) => CubesDataHandler.GeneratedCubes.Keys.ToList().Contains(goalCube.gameObject);

            void RemoveMergedCubes()
            {
                Object.Destroy(onCrashEvent.shotCubeData.CubeGameObject);
                Object.Destroy(onCrashEvent.collisionCubeData.CubeGameObject);
                CubesDataHandler.GeneratedCubes.Remove(onCrashEvent.shotCubeData.CubeGameObject);
                CubesDataHandler.GeneratedCubes.Remove(onCrashEvent.collisionCubeData.CubeGameObject);
            }
        }
    }
}