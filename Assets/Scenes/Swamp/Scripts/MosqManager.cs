using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class MosqManager : MonoBehaviour
{
    public Vector2 topright;
    public Vector2 bottomleft;

    public GameObject Mosqitoe;

    public static MosqManager instance;

    [SerializeField] private int Krutki;
    void Start()
    {

    }
    private void Awake()
    {
        instance = this;
    }
    void Update()
    {

    }

    private IEnumerator Spawner()
    {
        Krutki++;

        yield return new WaitForSeconds(4f);

        if (Mosqitoe == null)
            Debug.LogError("Mosqitoe prefab not selected");
        else
        {
            GameObject newMosq = Instantiate(Mosqitoe, GetRandomSpawnPosition(), Quaternion.identity);
            Debug.Log("Respawn successful");
        }

    }

    public void MosqMan()
    {
        StartCoroutine(Spawner());
    }

    private Vector2 GetRandomSpawnPosition()
    {
        const float checkRadius = 0.5f;
        const int maxAttempts = 5;

        for (int i = 0; i < maxAttempts; i++)
        {
            float x = UnityEngine.Random.Range(topright.x, bottomleft.x);
            float y = UnityEngine.Random.Range(topright.y, bottomleft.y);
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