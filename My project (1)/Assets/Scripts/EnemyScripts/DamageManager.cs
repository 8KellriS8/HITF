using UnityEngine;

public class DamageManager : MonoBehaviour
{
    private EnemyStateManager parentScript;
    public BugMove bugScript;
    public Damage DamageScript;
    private bool f = true;
    private GameObject effectObj;
    void Start()
    {
        bugScript = GameObject.Find("LightObjects").GetComponent<BugMove>();
        parentScript = GetComponentInParent<EnemyStateManager>();
        effectObj = GameObject.Find("HitEffect");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent == null) return;
        DamageScript = other.transform.GetComponent<Damage>();
        if (other.CompareTag("Weapon") && other.transform.parent.name == "Near-Far Interactor")
        {
            if (parentScript.canMove && parentScript.current_state == parentScript.jumpAttackState && parentScript.land!=2)
            {
                if (f)
                {
                    parentScript.audioSource_takehit1.Play();
                    parentScript._animator.SetBool("Fall", true);
                    parentScript.land = 1; //1 - Спарирован
                    parentScript.hp -= DamageScript.dmg*3f;
                    f = false;
                    bugScript.TrySpawnEnemy(0);
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
                parentScript.audioSource_takehit.Play();
                parentScript._animator.SetBool("Got_Hit", true);
                parentScript.canMove = false;
                parentScript.hp -= DamageScript.dmg;
            }

            parentScript.SetSpeed(0);
            parentScript.UpdateHp();
        }
    }
}