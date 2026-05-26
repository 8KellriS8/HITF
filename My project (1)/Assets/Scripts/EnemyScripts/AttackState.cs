using UnityEngine;

public class AttackState : BaseState
{
    public override void EnterState(EnemyStateManager manager)
    {
        manager.SetSpeed(0);
        manager._animator.SetBool("InRadius", true);
    }
    public override void ExitState(EnemyStateManager manager)
    {

    }
    public override void UpdateState(EnemyStateManager manager)
    {
        manager.SetSpeed(0);
        if (manager.GetDistanceToPlayer() > manager.attackRange && manager.attackCompleted && manager.canMove)
        {
            manager._animator.SetBool("InRadius", false);
            manager.SwitchState(manager.agroState);
            manager.attackCompleted = false;
            return;
        }
    }
}
