using System;
using UnityEngine;

public class ObjectRotate : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    [SerializeField] float yMinLimit = -20f;
    [SerializeField] float yMaxLimit = 80f;

    private float horizontalAngle;
    private float verticalAngle;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        horizontalAngle = angles.y;
        verticalAngle = angles.x;

    }

    void Update()
    {
        if(Input.GetMouseButton(0)) {
            
            horizontalAngle += Input.GetAxis("Mouse X") * rotationSpeed;
            verticalAngle -= Input.GetAxis("Mouse Y") * rotationSpeed;
            verticalAngle = Mathf.Clamp(verticalAngle, yMinLimit, yMaxLimit);

            transform.rotation = Quaternion.Euler(verticalAngle, horizontalAngle, 0);
        }
    }
}
