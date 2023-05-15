using UnityEngine;


public class CubeAddForced : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private int forceValue;
    [SerializeField] private Rigidbody rigidbody;


    // [ContextMenuItem("AddForce")]
    [ContextMenu("addForce")]
    public void AddForce()
    {
        //calc direction
        var myPosition = transform.position;
        var delta = destination.position - myPosition;
        // var normalizedDirection = direction.normalized;


        var xDirectionManipolator = 1;
        var yDirectionManipolator = 1;
        var zDirectionManipolator = 1;

        if (delta.x < 0)
            xDirectionManipolator = -1;

        if (delta.y < 0)
            yDirectionManipolator = -1;

        if (delta.z < 0)
            zDirectionManipolator = -1;

        var velocityInXDirection = Mathf.Sqrt(Mathf.Abs(2 * delta.x)) * xDirectionManipolator;
        var velocityInYDirection = Mathf.Sqrt(Mathf.Abs(2 * delta.y * 9.8f)) * yDirectionManipolator;
        var velocityInZDirection = Mathf.Sqrt(Mathf.Abs(2 * delta.z)) * zDirectionManipolator;

        var ShootVelocity = new Vector3(velocityInXDirection, velocityInYDirection, velocityInZDirection);
        rigidbody.velocity = ShootVelocity;
        // rigidbody.AddForce(normalizedDirection * forceValue);
    }
}
