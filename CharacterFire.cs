using UnityEngine;

public class CharacterFire : MonoBehaviour
{
    [SerializeField]
    GameObject mainCamera;

    private Ray HitRay => new Ray(mainCamera.transform.position, mainCamera.transform.forward);

    private RaycastHit hitInfo;

    private bool RayHitObject => Physics.Raycast(HitRay, out hitInfo, Mathf.Infinity);

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void MarkTargetAsHitByRay ()
    {
        hitInfo.collider.gameObject.GetComponent<Target>().MarkAsHitByRaycast();
    }

    private void Fire ()
    {
        if (RayHitObject && hitInfo.collider.tag == "Target")
        {
            MarkTargetAsHitByRay();
        }
    }
}