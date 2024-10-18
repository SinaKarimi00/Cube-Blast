using BlastCube.Cubes;
using UnityEngine;


namespace BlastCube.Player
{
    public class ShootHandler
    {
        public void Shoot(Cube cube)
        {
            int power = 50;
            cube.GetCubeRigidbody().AddForce(Vector3.forward * power);
            cube.transform.SetParent(cube.transform.parent.parent);
            cube.GetTrail().enabled = true;
        }
    }
}