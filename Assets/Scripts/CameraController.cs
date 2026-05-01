using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 5f;

    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        xRotation = angles.x;
        yRotation = angles.y;
    }

    void Update()
    {
        if (Input.GetMouseButton(1)) // Right mouse button
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            yRotation += mouseX * rotationSpeed;
            xRotation -= mouseY * rotationSpeed;

            // Clamp vertical rotation (VERY IMPORTANT)
            xRotation = Mathf.Clamp(xRotation, 10f, 80f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        }
    }
}