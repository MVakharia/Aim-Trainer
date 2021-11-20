using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float rotationY;

    private float Sensitivity => GameManager.Singleton.Sensitivity;

    void Update()
    {
        if(!GameManager.Singleton.Paused)
        {
            VerticalLook();
        }
    }

    private void VerticalLook ()
    {
        rotationY += Input.GetAxisRaw("Mouse Y") * Sensitivity;

        rotationY = Mathf.Clamp(rotationY, -90, 90);

        transform.localRotation = Quaternion.Euler(-rotationY, 0F, 0F);
    }
}