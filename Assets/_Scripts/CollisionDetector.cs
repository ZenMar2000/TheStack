using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    int collisions = 0;

    private void OnCollisionEnter(Collision collision)
    {
        collisions++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisions--;
    }
}
