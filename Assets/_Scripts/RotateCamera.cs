using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField]
    Transform cameraAnchorTransform;

    [SerializeField]
    float RotationSpeed = 0.5f;
    void FixedUpdate()
    {
        if (Input.GetMouseButton(2))
        {
            cameraAnchorTransform.Rotate(new Vector3(0,1,0), -Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime);
        }
    }
}
