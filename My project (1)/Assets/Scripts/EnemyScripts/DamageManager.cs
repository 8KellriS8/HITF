using UnityEngine;

public class DamageManager : MonoBehaviour
{
    private EnemyStateManager parentScript;
    public Damage DamageScript;
    private bool f = true;
    private GameObject effectObj;
    void Start()
    {
        parentScript = GetComponentInParent<EnemyStateManager>();
        effectObj = GameObject.Find("HitEffect");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent == null) return;
        DamageScript = other.transform.GetComponent<Damage>();
        if (other.CompareTag("Weapon") && other.transform.parent.name == "Near-Far Interactor")
        {
            if (parentScript.canMove && parentScript.current_state == parentScript.jumpAttackState)
            {
                parentScript._animator.SetBool("Fall", true);
                parentScript.land = 1; //1 - Спарирован
                if (f)
                {
                    parentScript.hp -= DamageScript.dmg*3f;
                    f = false;
                    
                    if (effectObj != null)
                    {
                        Vector3 contactPoint = other.ClosestPoint(transform.position);

                        effectObj.transform.position = contactPoint;

                        if (effectObj.TryGetComponent<ParticleSystem>(out ParticleSystem particleSys))
                        {
                            particleSys.Stop();
                            particleSys.Play();
                        }
                    }
                }
            }
            else if (parentScript.canMove && parentScript._animator.GetBool("Got_Hit") == false)
            {
                parentScript._animator.SetBool("Got_Hit", true);
                parentScript.canMove = false;
                parentScript.hp -= DamageScript.dmg;
            }

            parentScript.SetSpeed(0);
            parentScript.UpdateHp();
        }
    }
}