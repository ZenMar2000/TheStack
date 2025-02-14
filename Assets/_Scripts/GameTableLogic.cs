using UnityEngine;

public class GameTableLogic : MonoBehaviour
{
    Rigidbody rb;
    Quaternion originalRotation;
    int collisions = 0;
    float angleSpeed = 0.1f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalRotation = rb.rotation;
    }

    void FixedUpdate()
    {
        if (collisions == 0)
        {
            rb.MoveRotation(Quaternion.Lerp(rb.rotation, originalRotation, angleSpeed));
        }

        rb.position = Vector3.zero;
    }

    public void IncreaseCollisions()
    {
        collisions++;
    }
    public void ReduceCollisionCount()
    {
        if (collisions > 0)
        {
            collisions--;
            //Debug.Log("Reduced collision. Tot: " + collisions);
        }
    }
}
