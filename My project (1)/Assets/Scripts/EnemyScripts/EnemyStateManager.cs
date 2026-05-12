using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    BaseState current_state;
    public IdleState idleState = new IdleState();
    public AttackState attackState = new AttackState();
    public AgroState agroState = new AgroState();
    public JumpAttackState jumpAttackState = new JumpAttackState();
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] public Transform player;
    [SerializeField] public float speed = 1.1f;
    [SerializeField] public float attackRange = 1.25f;
    [SerializeField] public int _outlineWidth = 5;
    public Outline outline;
    public PlayerStats playerScript;

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
}
