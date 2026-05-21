using UnityEngine;

public class AgroState : BaseState
{
    public override void EnterState(EnemyStateManager manager)
    {
        manager.SetSpeed(manager.speed);
        manager._animator.SetBool("InRadius", false);
    }
    public override void ExitState(EnemyStateManager manager)
    {

    }
    public override void UpdateState(EnemyStateManager manager)
    {
        if (manager.GetDistanceToPlayer() < manager.attackRange) 
        {
            manager.SwitchState(manager.attackState);
            return;
        }
    }
}
