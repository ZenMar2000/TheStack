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
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        gtl.ReduceCollisionCount();
    }
}
