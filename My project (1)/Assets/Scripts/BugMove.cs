using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.Cinemachine.IInputAxisOwner.AxisDescriptor;

public class BugMove : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs = new GameObject[2];
    [SerializeField] private Transform Entities;
    [SerializeField] private PlayerStats player;
    public Transform target;
    public Animator _animator;
    public GameObject end;
    public float speed = 1f;
    public bool hasReached = true;
    public Vector3[] waypoints = new Vector3[6];
    public Vector3[] enemypoints = new Vector3[7];
    public int currentEnemyPoint = 0;
    public int currentWay = 0;
    public GameObject bug;
    public Light light;
    public SphereCollider sphere;
    public int count = 0;
    public TextMeshProUGUI light_text;
    public VRScreenFader fader;
    public GameObject hints;

    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("MainCamera")) return;
        player.inLight = true;
        StartCoroutine(LightIn());
    }

    public void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("MainCamera")) return;
        player.inLight = false;
        StartCoroutine(LightOut());
    }

    void Start()
    {
        player = player.GetComponent<PlayerStats>();
        _animator = bug.GetComponent<Animator>();
    }
    
    void Update()
    {   
        sphere.radius = light.range*4.25f;
        float lighttext = light.range/6*100;
        if (lighttext > 100) lighttext = 100;
        light_text.text = Mathf.FloorToInt(lighttext).ToString();
        if (hasReached)
        {
            count = 0;
            if (light.range > 0.005f)
            {
                light.range -= 0.0001f+(PublicInfo.difficulty - 1) * 0.0001f;
            }
            foreach (Transform child in Entities)
            {
                if (child.gameObject.activeSelf && child.TryGetComponent<EnemyStateManager>(out var enemy))
                {
                    if (enemy.hp > 0) count++;
                }
            }
            if (count != 0) return;
            if (player.noise > 20) 
            {
                TrySpawnEnemy(0);
            }
        }
        else
        {
            if (light.range < 6)
            {
                light.range *= 1.05f;
            }
            hints.SetActive(false);
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWay]/5, speed * Time.deltaTime);
            float stoppingDistance = 1f;
            bug.transform.LookAt(waypoints[currentWay]/5);
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
        if (currentWay!=6)
        {
            TrySpawnEnemy(1f);
        }
        else
        {
            if (PublicInfo.ending)
            {
                end.SetActive(true);
            }
            else
            {
                StartCoroutine(BadEnd());
            }
        }
        _animator.SetBool("Move", false);
    }

    public void TrySpawnEnemy(float spawnChance)
    {
        if (spawnChance == 0)
        {
            float randomRoll = Random.Range(0f, 100f);
            if (randomRoll > currentWay*5+12.5*PublicInfo.difficulty)
            {
                return; 
            }
        }
        int maxIndexAllowed = 0;
        if (currentWay == 0 || currentWay == 1)
        {
            maxIndexAllowed = 0;
        }
        else 
        {
            maxIndexAllowed = 1; 
        }
        int randomIndex = Random.Range(0, maxIndexAllowed + 1);
        GameObject selectedEnemyPrefab = enemyPrefabs[randomIndex];
        float randomAngle = Random.Range(0f, Mathf.PI * 2f);
        float spawnX = Mathf.Cos(randomAngle) * 6f;
        float spawnZ = Mathf.Sin(randomAngle) * 6f;
        Vector3 spawnPosition = new Vector3(spawnX, 0.25f, spawnZ) + enemypoints[currentEnemyPoint];
        GameObject spawnedEnemy = Instantiate(selectedEnemyPrefab, spawnPosition, Quaternion.identity, Entities);
    }
    IEnumerator BadEnd()
	{
		fader.FadeOut(6f); // Ёкран гаснет за 0.5 секунды
		yield return new WaitForSeconds(6f);
		SceneManager.LoadScene(2, LoadSceneMode.Single);
	}
    IEnumerator LightOut()
    {
		fader.FadeOut(12f); // Ёкран гаснет за 0.5 секунды
		yield return new WaitForSeconds(12f);
		player.CheckPosition();
	}
    IEnumerator LightIn()
    {
		fader.FadeIn(1f); // Ёкран гаснет за 0.5 секунды
		yield return new WaitForSeconds(1f);
	}
}
