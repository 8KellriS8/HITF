using UnityEngine;

public class DamageManager : MonoBehaviour
{
    private EnemyStateManager parentScript;

    void Start()
    {
        parentScript = GetComponentInParent<EnemyStateManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent == null) return;
        if (other.CompareTag("Weapon") && other.transform.parent.name == "Near-Far Interactor")
        {
            if (parentScript.current_state == parentScript.jumpAttackState)
            {
                parentScript._animator.SetBool("Fall", true);
                parentScript.land = 1; //1 - Спарирован
            }
            else if (parentScript.canMove)
            {
                parentScript._animator.SetBool("Got_Hit", true);
                parentScript.canMove = false;
            }
            parentScript.SetSpeed(0);
        }
    }
}