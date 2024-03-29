using UnityEngine;


namespace BlastCube.Player
{
    public class PlayerMovement
    {
        private readonly GameObject playerGameObject;
        private readonly float maxMapLength = 4f;
        private readonly float minMapLength = 0f;

        public PlayerMovement(GameObject playerGameObject)
        {
            this.playerGameObject = playerGameObject;
        }

        public void Move(Vector3 destination)
        {
            if (destination.x < maxMapLength && destination.x > minMapLength)
            {
                playerGameObject.transform.position = new Vector3(destination.x, 1f, 0f);
            }
        }
    }
}