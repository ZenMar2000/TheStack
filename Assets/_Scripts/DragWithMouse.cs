using UnityEngine;

public class DragWithMouse : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private Rigidbody rb;
    private Vector3 nextPosition;


    //private void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}

    //private void FixedUpdate()
    //{
    //    if (Vector3.Distance(nextPosition, Vector3.zero) > 0.01f)
    //    {
    //        rb.position = nextPosition;
    //    }
    //}

    //private void OnMouseDown()
    //{
    //    screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    //    offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(GetMousePos());
    //    nextPosition = Vector3.zero;
    //    rb.isKinematic = true;
    //}

    //private void OnMouseDrag()
    //{
    //    nextPosition = Camera.main.ScreenToWorldPoint(GetMousePos()) + offset;
    //}

    //private void OnMouseUp()
    //{
    //    rb.isKinematic = false;
    //    nextPosition = Vector3.zero;
    //}


    //private Vector3 GetMousePos()
    //{
    //    return new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
    //}


}

