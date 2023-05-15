using UnityEngine;


namespace BlastCube.Player
{
    public class ShootHandler
    {
        public void Shoot(Rigidbody cubeRigidbody)
        {
            int power = 50;
            cubeRigidbody.AddForce(Vector3.forward * power);
            cubeRigidbody.transform.SetParent(cubeRigidbody.transform.parent.parent);
        }
    }
}