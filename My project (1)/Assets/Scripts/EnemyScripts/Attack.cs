using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject playerObject;
    public PlayerStats playerScript;
    public int power;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerObject = GameObject.FindWithTag("MainCamera");
        playerScript = playerObject.GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("MainCamera")) return;
        playerScript.TakeHit(power);
    }
}
