using BlastCube.Cubes;
using UnityEngine;


namespace BlastCube.Player
{

    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField] private Rigidbody cubeRigidBody;
        public Rigidbody CubeRigidBody => cubeRigidBody;
        private readonly float waiteTime = 0.5f;

        private void OnTriggerExit(Collider other)
        {
            cubeRigidBody = null;
            Invoke(nameof(InitializeCube), waiteTime);
        }

        private void OnTriggerStay(Collider other)
        {
            if (cubeRigidBody == null)
                cubeRigidBody = other.GetComponent<Rigidbody>();
        }

        private void InitializeCube()
        {
            CubeInitialization cubeInitialization = new CubeInitialization();
            GameObject cube = cubeInitialization.InitializeShootAbleCube(gameObject);
        }
    }
}