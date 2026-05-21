using UnityEngine;

public class IdleState : BaseState
{
    public override void EnterState(EnemyStateManager manager)
    {
        manager.SetSpeed(0);
        manager.GetComponentInChildren<Renderer>().enabled = false;
    }
    public override void ExitState(EnemyStateManager manager)
    {

    }
    public override void UpdateState(EnemyStateManager manager)
    {
        if (manager.playerScript.noise > 50) 
        {
            manager.SwitchState(manager.jumpAttackState);
            manager._animator.SetBool("IsTrigered", true);
        }
    }
}
