using UnityEngine;

public class AgroState : BaseState
{
    public override void EnterState(EnemyStateManager manager)
    {
        Debug.Log("Entered Agro State");
        manager.SetSpeed(manager.speed);
    }
    public override void ExitState(EnemyStateManager manager)
    {

    }
    public override void UpdateState(EnemyStateManager manager)
    {
        Debug.Log(manager.GetDistanceToPlayer() < manager.attackRange);
        if (manager.GetDistanceToPlayer() < manager.attackRange) 
        {
            manager.SwitchState(manager.attackState);
            return;
        }
    }
}
