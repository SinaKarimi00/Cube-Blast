using BlastCube.Cubes;
using UnityEngine;


namespace BlastCube.Player
{
    public class PlayerRequirementsFactory
    {
        private readonly Camera camera;

        public PlayerRequirementsFactory()
        {
            camera = Camera.main;
        }

        public PlayerMovement CreateMoveAbility(GameObject playerGameObject) => new PlayerMovement(playerGameObject);

        public ShootHandler CreateShootAbility() => new ShootHandler();

        public PositionHandler CreatePositionHandler() => new PositionHandler(camera);

        public GameObject CreatePlayer(GameObject playerPrefab) => Object.Instantiate(playerPrefab);

        public CubeInitialization CreateCubeInitializer() => new CubeInitialization();
    }
}