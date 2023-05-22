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

        public void HandleEvent(IEvent invokedEvent)
        {
            if (!(invokedEvent is OnCrash onCrashEvent)) return;

            Cube shotCube = onCrashEvent.shotCube;
            Cube collisionCube = onCrashEvent.collisionCube;
            if (ValueCheck() && ExistenceCheck(shotCube)
                             && ExistenceCheck(collisionCube))
            {
                CubeInitialization cubeInitialization = new CubeInitialization();
                Cube mergedCube = cubeInitialization.InitializeMergedCube(shotCube, collisionCube);
                CubeRouting cubeRouting = new CubeRouting();
                mergedCube.Collided = true;
                CubeMovement cubeMovement = new CubeMovement();
                Vector3 destination = cubeRouting.GetRoute(onCrashEvent.shotCube.CubeData.CubeValue * 2, mergedCube.gameObject);
                cubeMovement.Move(mergedCube.CubeRigidbody, destination);
                RemoveMergedCubes();
            }

            else
                shotCube.Collided = true;

            bool ValueCheck() => onCrashEvent.shotCube.CubeData.CubeValue == onCrashEvent.collisionCube.CubeData.CubeValue;

            bool ExistenceCheck(Cube goalCube) => CubesDataHandler.GetGeneratedCubes.Contains(goalCube);

            void RemoveMergedCubes()
            {
                Object.Destroy(onCrashEvent.shotCube.gameObject);
                Object.Destroy(onCrashEvent.collisionCube.gameObject);
                CubesDataHandler.GetGeneratedCubes.Remove(onCrashEvent.shotCube);
                CubesDataHandler.GetGeneratedCubes.Remove(onCrashEvent.collisionCube);
            }
        }
    }
}