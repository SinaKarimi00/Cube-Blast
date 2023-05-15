using UnityEngine;


namespace BlastCube.Player
{
    public class PlayerMovement
    {
        private readonly GameObject playerGameObject;

        public PlayerMovement(GameObject playerGameObject)
        {
            this.playerGameObject = playerGameObject;
        }

        public void Move(Vector3 destination)
        {
            playerGameObject.transform.position = new Vector3(destination.x, 1f, 0f);
        }
    }
}