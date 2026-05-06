using UnityEngine;

public class BugCollider : MonoBehaviour
{
     private void OnTriggerEnter(Collider other)
    {
        BugMove parentScript = GetComponentInParent<BugMove>();

        if (parentScript != null)
        {
            parentScript.hasReached = true;
            Debug.Log("Свойство hasReached изменено через дочерний объект!");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Shroom")) return
        other.SetActive(false);
        transform.parent.hasReached = false;
    }
}
