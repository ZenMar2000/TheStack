using UnityEngine;

public class DestroyOnFall : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
