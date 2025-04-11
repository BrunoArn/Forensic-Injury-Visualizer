using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform target;

    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] float distance = 10f;
    [SerializeField] float yMinLimit = -20f;
    [SerializeField] float yMaxLimit = 80f;

    [SerializeField] Vector3 targetOffset = new Vector3(0, 2 ,0);

    private float x = 0f;  
    private float y = 20f;

    void Start()
    {
        if (!target) {
            Debug.Log("defina targer");
            return;
        }

        //inicializa angulos
        Vector3 angles = transform.eulerAngles;
        x = angles.x;
        y = angles.y;

        y = Mathf.Clamp(y, yMinLimit, yMaxLimit);
    }

    void LateUpdate()
    {
        if (!target) return;

        if(Input.GetMouseButton(0)) {
            x += Input.GetAxis("Mouse X") * rotationSpeed;
            y -= Input.GetAxis("Mouse Y") * rotationSpeed;

            y = Mathf.Clamp(y, yMinLimit, yMaxLimit);
        }

        Quaternion rotation = Quaternion.Euler(y, x, 0);

        Vector3 orbitCenter = target.position;
        Vector3 cameraPosition = orbitCenter + rotation * new Vector3(0, 0, -distance);

        transform.position = cameraPosition;
        transform.LookAt(target.position + targetOffset);

        /*
        Vector3 pivot = target.position + targetOffset;

        Vector3 position = pivot + rotation * new Vector3(0, 0, -distance);

        transform.position = position;
        transform.LookAt(pivot);
        */
    }
}
