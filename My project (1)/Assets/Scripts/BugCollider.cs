/*
using UnityEngine;

public class BugCollider : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        BugMove parentScript = GetComponentInParent<BugMove>();
        if (!other.CompareTag("Shroom")) return
        if (parentScript != null)
        {
            parentScript.hasReached = true;
            other.SetActive(false);
        }
    }
}
*/