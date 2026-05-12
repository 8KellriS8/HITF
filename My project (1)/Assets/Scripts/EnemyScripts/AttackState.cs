using UnityEngine;

public class AttackState : BaseState
{
    public override void EnterState(EnemyStateManager manager)
    {
        manager.SetSpeed(0);
        Debug.Log("1");
    }
    public override void ExitState(EnemyStateManager manager)
    {

    }
    public override void UpdateState(EnemyStateManager manager)
    {
        Debug.Log(manager.GetDistanceToPlayer());
        if (manager.GetDistanceToPlayer() > manager.attackRange)
        {
            manager.SwitchState(manager.agroState);
            return;
        }
    }
}
