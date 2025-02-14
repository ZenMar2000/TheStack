using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    PrimitiveType primitiveToPlace;
    Vector3 randomScaleToUse;

    Vector3 nextShapePreviewPos = new Vector3(-1.4f, 20.6f, 5);
    GameObject previewObject;

    [SerializeField]
    PhysicsMaterial pmaterial;

    void Start()
    {
        GenerateNextShape();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LeftClickLogic();
        }

        if (Input.GetMouseButtonDown(1))
        {
            RightClickLogic();
        }
    }

    private void GenerateNextShape()
    {
        primitiveToPlace = PrimitiveType.Cube;

        if (previewObject)
        {
            Destroy(previewObject);
        }
        randomScaleToUse = new Vector3(Random.Range(0.1f, 0.6f), Random.Range(0.1f, 0.6f), Random.Range(0.1f, 0.6f));

        previewObject = GameObject.CreatePrimitive(primitiveToPlace);
        previewObject.transform.localScale = randomScaleToUse;
        previewObject.name = "PreviewShape";
        previewObject.transform.Rotate(new Vector3(1, 1, 0), 45);
        previewObject.transform.position = nextShapePreviewPos;

    }

    private void LeftClickLogic()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {

            GameObject instantiatedGameObject = GameObject.CreatePrimitive(primitiveToPlace);
            instantiatedGameObject.transform.localScale = randomScaleToUse;
            instantiatedGameObject.transform.position = hit.point + new Vector3(0, 1, 0);
            instantiatedGameObject.transform.rotation = Random.rotation;
            instantiatedGameObject.tag = "StackItem";

            Rigidbody instantiatedRb = instantiatedGameObject.AddComponent<Rigidbody>();
            instantiatedRb.mass = _Utils.DefaultMass * randomScaleToUse.x * randomScaleToUse.y * randomScaleToUse.z;

            Color randomColor = Random.ColorHSV();

            float H, S, V;
            Color.RGBToHSV(randomColor, out H, out S, out V);
            S = 0.8f;
            V = 0.8f;

            randomColor = Color.HSVToRGB(H, S, V);
            instantiatedGameObject.GetComponent<MeshRenderer>().material.color = randomColor;

            //Must be inside Resources folder
            //Texture texture = Resources.Load<Texture>("TextureName");
            //instantiatedGameObject.GetComponent<MeshRenderer>().material.mainTexture = texture

            instantiatedGameObject.AddComponent<ShrinkShape>();

            PhysicsMaterial instantiatedMaterial = instantiatedGameObject.GetComponent<Collider>().material;
            instantiatedMaterial.bounciness = Random.Range(0.1f, 1f);
            instantiatedMaterial.staticFriction = Random.Range(0.4f, 0.8f);
            instantiatedMaterial.dynamicFriction = instantiatedMaterial.staticFriction - 0.2f;

            GenerateNextShape();
        }
    }

    private void RightClickLogic()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            GameObject hitGo = hit.collider.gameObject;
            if (hitGo.tag == _Utils.Tag_StackItem)
            {
                hitGo.GetComponent<ShrinkShape>().PerformShrink();
                gameObject.GetComponent<GameTableLogic>().ReduceCollisionCount();
            }
        }
    }
}
