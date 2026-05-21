using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    BaseState current_state;
    public IdleState idleState = new IdleState();
    public AttackState attackState = new AttackState();
    public AgroState agroState = new AgroState();
    public JumpAttackState jumpAttackState = new JumpAttackState();
    [SerializeField] public NavMeshAgent _agent;
    [SerializeField] public Animator _animator;
    [SerializeField] public Transform player;
    [SerializeField] public float speed = 1.1f;
    [SerializeField] public float attackRange = 1.25f;
    [SerializeField] public int _outlineWidth = 5;
    public Outline outline;
    public bool land = false;
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
        SwitchState(idleState);
        outline = GetComponent<Outline>();
        GameObject playerObject = GameObject.FindWithTag("MainCamera");
        playerScript = playerObject.GetComponent<PlayerStats>();
    }
    private void Update()
    {
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
            SetSpeed(10);
        }
        if (stage == 2)
        {

        }
        if (stage == 3)
        {
            SwitchState(agroState);
            land = true;
        }
    }
    public void CheckPlayerPosition()
    {
        transform.LookAt(player);
        attackCompleted = true;
    }
}
