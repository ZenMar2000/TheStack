using UnityEngine;

public class GameManager : MonoBehaviour
{
    PrimitiveType primitiveToPlace;
    Vector3 nextShapePreviewPos = new Vector3(-7.5f, 23f, 5);
    GameObject previewObject;

    [SerializeField]
    PhysicsMaterial pmaterial;

    void Start()
    {
        GenerateNextShape();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                GameObject instantiatedGameObject = GameObject.CreatePrimitive(primitiveToPlace);
                instantiatedGameObject.transform.localScale = Vector3.one * 0.3f;
                instantiatedGameObject.transform.position = hit.point + new Vector3(0, 1, 0);
                instantiatedGameObject.transform.rotation = Random.rotation;

                instantiatedGameObject.AddComponent<Rigidbody>();
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

                instantiatedGameObject.AddComponent<DragWithMouse>();

                instantiatedGameObject.GetComponent<Collider>().material = pmaterial;

                GenerateNextShape();
            }
        }
    }

    private void GenerateNextShape()
    {
        switch (Random.Range(0, 4))
        {
            case 0:
                primitiveToPlace = PrimitiveType.Cube;
                break;

            case 1:
                primitiveToPlace = PrimitiveType.Sphere;
                break;

            case 2:
                primitiveToPlace = PrimitiveType.Capsule;
                break;

            case 3:
                primitiveToPlace = PrimitiveType.Cylinder;
                break;

            default:
                primitiveToPlace = PrimitiveType.Cube;
                break;
        }

        if (previewObject)
        {
            Destroy(previewObject);
        }
        previewObject = GameObject.CreatePrimitive(primitiveToPlace);
        previewObject.name = "PreviewShape";
        previewObject.transform.position = nextShapePreviewPos;

    }
}
