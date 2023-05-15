using UnityEngine;


namespace BlastCube.Cubes
{
    public class CubeMovement
    {
        public void Move(Rigidbody rigidbody, Vector3 route)
        {
            if (route != Vector3.zero)
            {
                Vector3 destination = (route - rigidbody.transform.position).normalized;
                destination *= 3;
                destination += new Vector3(0f, 20f, 0f);
                rigidbody.AddForce(destination);
            }
            else
            {
                rigidbody.AddForce(new Vector3(0f, 10f, 0f));
            }
            rigidbody.AddTorque(new Vector3(2f, 0f, 0f));
        }
    }
}