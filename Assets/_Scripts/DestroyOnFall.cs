using UnityEngine;

public class DestroyOnFall : MonoBehaviour
{
    [SerializeField]
    GameObject gameTable;

    GameTableLogic gtl;
    private void Start()
    {
        gtl = gameTable.GetComponent<GameTableLogic>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == _Utils.Tag_StackItem)
        {
            ShrinkShape shrinkShape = collision.GetComponent<ShrinkShape>();
            if (!shrinkShape.HasCollided())
            {
                collision.gameObject.GetComponent<ShrinkShape>().PerformShrink();
                gtl.ReduceCollisionCount();
            }
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
