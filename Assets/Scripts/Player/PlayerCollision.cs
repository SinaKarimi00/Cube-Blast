using BlastCube.Cubes;
using UnityEngine;


namespace BlastCube.Player
{

    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField] private Cube cubeComponent;
        public Cube CubeComponent => cubeComponent;
        private readonly float waiteTime = 0.5f;

        private void OnTriggerExit(Collider other)
        {
            cubeComponent = null;
            Invoke(nameof(InitializeCube), waiteTime);
        }

        private void OnTriggerStay(Collider other)
        {
            if (cubeComponent == null)
                cubeComponent = other.GetComponent<Cube>();
        }

        private void InitializeCube()
        {
            CubeInitialization cubeInitialization = new CubeInitialization();
            cubeInitialization.InitializeShootAbleCube(gameObject);
        }
    }
}