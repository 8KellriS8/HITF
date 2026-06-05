using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    public AudioSource audioSource_hit;
    public AudioSource audioSource_hardhit;
    public AudioSource audioSource_takehit;
    public AudioSource audioSource_takehit1;
    public AudioSource warning;
    public GameObject collider1;
    public GameObject collider2;
    public BaseState current_state;
    public float hp = 100f; 
    public IdleState idleState = new IdleState();
    public AttackState attackState = new AttackState();
    public AgroState agroState = new AgroState();
    public JumpAttackState jumpAttackState = new JumpAttackState();
    [SerializeField] public NavMeshAgent _agent;
    [SerializeField] public Animator _animator;
    public Transform player;
    [SerializeField] public float speed = 0.7f;
    [SerializeField] public float attackRange = 1.25f;
    [SerializeField] public int _outlineWidth = 5;
    [SerializeField] public int _enemyType;
    public Outline outline;
    public GameObject playerObject;
    public bool canMove = true;
    public int land = 0; 
    public PlayerStats playerScript;
    public bool attackCompleted = false;

    public void SwitchState(BaseState newState)
    {
        if (current_state != null)
        {
            current_state.ExitState(this);
        }
        current_state = newState;
        current_state.EnterState(this);
    }
    private void Start()
    {
        if (_enemyType == 1) hp = 0f;
        else hp = 20f;
        hp += 100+PublicInfo.difficulty*25;
        SwitchState(idleState);
        outline = GetComponent<Outline>();
        playerObject = GameObject.FindWithTag("MainCamera");
        playerScript = playerObject.GetComponent<PlayerStats>();
        player = playerObject.transform;
    }
    private void Update()
    {
        Debug.Log(player, playerScript);
        player = playerObject.transform;
        current_state.UpdateState(this);
        _agent.destination = player.position;
    }
    public void SetSpeed(float Speed)
    {
        _agent.speed = Speed;
    }
    public float GetDistanceToPlayer()
    {
        return (transform.position - player.transform.position).magnitude;
    }
    public void EnterNewState(int stage)
    {
        if (stage == 1)
        {

            SetSpeed(9f);
        }
        if (stage == 2)
        {
            land = 2; //Не отпарировано
            SetSpeed(0);
            audioSource_hardhit.Play();
            collider1.SetActive(true);
        }
        if (stage == 3)
        {
            land += 10;
            _animator.SetBool("InRadius", true);
            SwitchState(agroState);
            collider1.SetActive(false);
        }
        if (stage == 4)
        {
            SetSpeed(0);
        }
    }
    public void CheckPlayerPosition()
    {
        transform.LookAt(player);
        attackCompleted = true;
    }
    public void Continue_Movement()
    {
        _animator.SetBool("Got_Hit", false);
        canMove = true;
        if (current_state == agroState)
        {
            SetSpeed(speed);
        }
        else
        {
            SetSpeed(0);
        }
    }
    public void UpdateHp()
    {
        _animator.SetFloat("HP", hp);
        if (hp <= 0)
        {
            collider1.SetActive(false);
            SetSpeed(0);
            collider2.SetActive(false);
        }
    }
    public void Attack(int Done)
    {
        if (Done==1)
        {
            collider2.SetActive(true);
            audioSource_hit.Play();
        }
        else collider2.SetActive(false);
       
    }
}
