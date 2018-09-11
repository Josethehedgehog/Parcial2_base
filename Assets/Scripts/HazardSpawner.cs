using UnityEngine;

public static class SpawnerExtensions
{
    public static Vector3 GetPointInVolume(this Collider2D collider)
    {
        Vector3 result = Vector3.zero;
        result = new Vector3(Random.Range(collider.bounds.min.x, collider.bounds.max.x), collider.transform.position.y, 0F);

        return result;
    }
}

[RequireComponent(typeof(Collider2D))]
public class HazardSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] hazardTemplate;

    private Collider2D myCollider;

    [SerializeField]
    private float spawnFrequency = 1F;

    int r;

    // Use this for initialization
    private void Start()
    {
        myCollider = GetComponent<Collider2D>();

        InvokeRepeating("SpawnEnemy", 0.2F, spawnFrequency);
    }

    public void Update()
    {
        
        r = Random.Range(0,hazardTemplate.Length);
    }

    private void SpawnEnemy()
    {
        if (hazardTemplate == null)
        {
            CancelInvoke();
        }
        else
        {
            
            if (r == 0)
            {
                Instantiate(hazardTemplate[0], myCollider.GetPointInVolume(), transform.rotation);
            }
            if (r == 1)
            {
                Instantiate(hazardTemplate[1], myCollider.GetPointInVolume(), transform.rotation);
            }
            if (r == 2)
            {
                Instantiate(hazardTemplate[2], myCollider.GetPointInVolume(), transform.rotation);
            }
        }
    }
}