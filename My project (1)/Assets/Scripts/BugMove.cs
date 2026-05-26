using UnityEngine;

public class BugMove : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs = new GameObject[2];
    [SerializeField] private Transform Entities;
    [SerializeField] private PlayerStats player;
    public Transform target;
    public float speed = 1f;
    public bool hasReached = true;
    public Vector3[] waypoints = new Vector3[6];
    public Vector3[] enemypoints = new Vector3[7];
    public int currentEnemyPoint = 0;
    public int currentWay = 0;
    public GameObject bug;
    public int count = 0;

    void Start()
    {
        player = player.GetComponent<PlayerStats>();
    }
    
    void Update()
    {   if (hasReached)
        {
            count = 0;
            foreach (Transform child in Entities)
            {
                if (child.gameObject.activeSelf && child.TryGetComponent<EnemyStateManager>(out var enemy))
                {
                    if (enemy.hp > 0) count++;
                }
            }
            if (count != 0) return;
            if (player.noise > 50) 
            {
                TrySpawnEnemy(0);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWay]/5, speed * Time.deltaTime);
            float stoppingDistance = 1f;
            bug.transform.LookAt(waypoints[currentWay]/5);
            bug.transform.Rotate(0, 180, 0);
            if (Vector3.Distance(transform.position, waypoints[currentWay] / 5) < stoppingDistance)
            {
                OnTargetReached();
            }
        }
    }

    void OnTargetReached()
    {
        hasReached = true;
        currentWay += 1;
        currentEnemyPoint += 1;
        TrySpawnEnemy(1f);
    }

    public void TrySpawnEnemy(float spawnChance)
    {
        if (spawnChance == 0)
        {
            float randomRoll = Random.Range(0f, 100f);
            if (randomRoll > currentWay*5+25)
            {
                return; 
            }
        }
        int maxIndexAllowed = 0;
        if (currentWay == 0)
        {
            maxIndexAllowed = 0;
        }
        else if (currentWay == 1 || currentWay == 2)
        {
            maxIndexAllowed = 1;
        }
        else if (currentWay == 3 || currentWay == 4)
        {
            maxIndexAllowed = 2; 
        }
        else 
        {
            maxIndexAllowed = 3; 
        }
        int randomIndex = Random.Range(0, maxIndexAllowed + 1);
        GameObject selectedEnemyPrefab = enemyPrefabs[randomIndex];
        float randomAngle = Random.Range(0f, Mathf.PI * 2f);
        float spawnX = Mathf.Cos(randomAngle) * 6f;
        float spawnZ = Mathf.Sin(randomAngle) * 6f;
        Vector3 spawnPosition = new Vector3(spawnX, 0.25f, spawnZ) + enemypoints[currentEnemyPoint];
        GameObject spawnedEnemy = Instantiate(selectedEnemyPrefab, spawnPosition, Quaternion.identity, Entities);
    }
}
