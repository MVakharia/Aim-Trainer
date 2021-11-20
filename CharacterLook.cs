using UnityEngine;

public class CharacterLook : MonoBehaviour
{
    private void Update()
    {
        if (!GameManager.Singleton.Paused)
        {
            HorizontalLook();   
        }
    }   

    private void HorizontalLook () => transform.Rotate(new Vector3(0, Input.GetAxisRaw("Mouse X"), 0) * GameManager.Singleton.Sensitivity);
}