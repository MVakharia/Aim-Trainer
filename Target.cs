using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private bool hitByRaycast;

    public void MarkAsHitByRaycast() => hitByRaycast = true;

    private void DestroyTarget()
    {
        CallTargetSpawner();

        Destroy(gameObject);
    }        

    /// <summary>
    /// Tells the target spawner to spawn a new target.
    /// </summary>
    private void CallTargetSpawner ()
    {
        TargetSpawner.Singleton.MarkAsAbleToSpawnTarget();
    }

    private void Update()
    {
        if(hitByRaycast)
        {
            DestroyTarget();
        }
    }

}
