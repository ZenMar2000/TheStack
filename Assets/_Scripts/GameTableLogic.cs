using UnityEngine;

public class GameTableLogic : MonoBehaviour
{
    Rigidbody rb;
    Quaternion originalRotation;
    int collisions = 0;
    float angleSpeed = 0.01f;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == _Utils.Tag_StackItem)
        {
            if (collision.gameObject.GetComponent<ShrinkShape>().HasCollided() == false)
            {
                collisions++;
                //Debug.Log("Added collision. Tot: " + collisions);
            }
        }
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
