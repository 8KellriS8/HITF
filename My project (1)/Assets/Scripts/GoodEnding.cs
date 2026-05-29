using UnityEngine;
using System.Collections;

public class GoodEnding : MonoBehaviour
{
    public GameObject player;
    public PlayerStats script;
    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("MainCamera")) return;
        script = player.GetComponent<PlayerStats>();
        script.End();
    }
}
