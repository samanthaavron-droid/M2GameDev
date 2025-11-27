using System.Collections;
using UnityEngine;

public class RespawnSystem : MonoBehaviour
{
    public GameObject diamondPrefab;
    public Vector2 position1;
    public Vector2 position2;

    public Collider2D colidr;
    public SpriteRenderer renderr;

    private float rotateSpeed = 90.0f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(HandleCollection(collision));
        }
    }

    private IEnumerator HandleCollection(Collider2D collision)
    {
        colidr = GetComponent<Collider2D>();
        if (colidr != null) 
            colidr.enabled = false; Debug.Log("Collider disabled");

        renderr = GetComponent<SpriteRenderer>();
        if (renderr != null) 
            renderr.enabled = false; Debug.Log("Renderer disabled");
            

        yield return new WaitForSeconds(4f);

        if (diamondPrefab == null)
        {
            Debug.LogError("Diamond prefab is not assigned.");
        }
        else
        {
            GameObject newDiamond = Instantiate(diamondPrefab, GetRandomSpawnPosition(), Quaternion.identity);
            RespawnSystem newResp = newDiamond.GetComponent<RespawnSystem>();
            if (newResp != null)
            {
                newResp.diamondPrefab = diamondPrefab;
                newResp.position1 = position1;
                newResp.position2 = position2;
                newResp.rotateSpeed = rotateSpeed;
            }
        }

        Debug.Log("Diamond respawned.");

        if (colidr.enabled == false)
        {
            colidr.enabled = true;
            Debug.Log("Collider Enabled");
        }
        else
        {
            Debug.Log("Collider not enabled");
        }   

        if (renderr.enabled == false)
        {
            renderr.enabled = true;
            Debug.Log("Renderer Enabled");
        }
        else
        {
            Debug.Log("Renderer not enabled");
        }

        gameObject.SetActive(false);

    }

    private Vector2 GetRandomSpawnPosition()
    {
        const float checkRadius = 0.5f;
        const int maxAttempts = 5;

        for (int i = 0; i < maxAttempts; i++)
        {
            float x = UnityEngine.Random.Range(position1.x, position2.x);
            float y = UnityEngine.Random.Range(position1.y, position2.y);
            Vector2 spawnPosition = new Vector2(x, y);

            bool isOverlapping = Physics2D.OverlapCircle(spawnPosition, checkRadius);
            if (!isOverlapping)
            {
                Debug.Log("Spawned at: " + spawnPosition);  
                return spawnPosition;
            }
        }
        Debug.LogWarning("Could not find a non-overlapping position. Spawning at 0");
        return Vector2.zero;
    }
}