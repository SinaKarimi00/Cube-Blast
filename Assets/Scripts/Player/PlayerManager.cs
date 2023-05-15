using BlastCube.Base;
using UnityEngine;


namespace BlastCube.Player
{
    public class PlayerManager : IManager, IUpdater
    {
        private GameObject playerGameObject;
        private PlayerRequirementsFactory playerRequirementsFactory;
        private PlayerCollision playerCollision;

        public void InitializeGameObject()
        {
            playerRequirementsFactory = new PlayerRequirementsFactory();
            playerGameObject = playerRequirementsFactory.CreatePlayer(Resources.Load<GameObject>("Player"));
            playerRequirementsFactory.CreateCubeInitializer().InitializeShootAbleCube(playerGameObject);
            playerCollision = playerGameObject.GetComponent<PlayerCollision>();
        }

        public void Updater()
        {
            PlayerInputHandler();
        }

        private void PlayerInputHandler()
        {
            if (Input.GetMouseButton(0))
                playerRequirementsFactory.CreateMoveAbility(playerGameObject).Move(Destination());
            else if (Input.GetMouseButtonUp(0) && playerCollision.CubeRigidBody)
                playerRequirementsFactory.CreateShootAbility().Shoot(playerCollision.CubeRigidBody);

            Vector3 Destination() => playerRequirementsFactory.CreatePositionHandler().GetCurrentPosition();
        }
    }
}