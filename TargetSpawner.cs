using UnityEngine;
using UnityEngine.UI;

public class TargetSpawner : MonoBehaviour
{
    private static TargetSpawner singleton;

    public static TargetSpawner Singleton
    {
        get
        {
            if (singleton == null)
            {
                singleton = GameObject.FindGameObjectWithTag("Target Spawner").GetComponent<TargetSpawner>();
            }
            return singleton;
        }
    }

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float spawnDistance;

    [SerializeField]
    private Vector2 spawningZone;

    private Vector3 RandomizedSpawningZone => 
        new Vector3(Random.Range(-spawningZone.x, spawningZone.x), Random.Range(-spawningZone.y, spawningZone.y), SpawnDistanceRelativeToPlayer);

    [SerializeField]
    private bool canSpawnTarget;

    [SerializeField]
    private Slider orbSizeSlider;

    private float SpawnDistanceRelativeToPlayer => player.transform.position.z + spawnDistance;

    public void MarkAsUnableToSpawnTarget() => canSpawnTarget = false;

    public void MarkAsAbleToSpawnTarget() => canSpawnTarget = true;

    private void SpawnTarget ()
    {
        GameObject newTarget = Instantiate(target, RandomizedSpawningZone, Quaternion.identity);

        newTarget.transform.localScale = new Vector3(orbSizeSlider.value, orbSizeSlider.value, orbSizeSlider.value);

    }

    private void Start()
    {
        SpawnTarget();
    }

    private void Update()
    {
        if(canSpawnTarget)
        {
            MarkAsUnableToSpawnTarget();
            SpawnTarget();
        }
    }
}
