using UnityEngine;

public class ShrinkShape : MonoBehaviour
{
    Rigidbody rb;
    bool shrinking = false;
    float shrinkSpeed = 0.9f;

    private bool haveCollided = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (shrinking)
        {
            if (transform.localScale.x > 0.01)
            {
                transform.localScale = transform.localScale * shrinkSpeed;
                rb.mass = _Utils.DefaultMass * transform.localScale.x * transform.localScale.y * transform.localScale.z;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void PerformShrink()
    {
        shrinking = true;
    }

    public bool HasCollided()
    {
        bool previousState = haveCollided;
        if (haveCollided == false)
        {
            haveCollided = true;
        }
        return previousState;
    }
}
