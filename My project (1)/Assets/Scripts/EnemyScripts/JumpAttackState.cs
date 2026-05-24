using UnityEngine;

public class JumpAttackState : BaseState
{
    public float timeRemaining = 2f;
    private bool timerIsRunning = false;
    public override void EnterState(EnemyStateManager manager)
    {
        manager.GetComponentInChildren<Renderer>().enabled = true;
        manager.outline.OutlineWidth = manager._outlineWidth;
        timerIsRunning = true;
        manager.transform.LookAt(manager.player);
    }
    public override void ExitState(EnemyStateManager manager)
    {
        if (manager.land == 12)
        {
            manager.transform.position += manager.transform.forward * 1.7f;
        }
        Debug.Log(manager.land);
    }
    public override void UpdateState(EnemyStateManager manager)
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                manager.outline.OutlineWidth = 0;
                manager._animator.SetBool("J_attack", true);
                manager._animator.SetBool("IsTrigered", false);
            }
        }
        else
        {
            if (manager.GetDistanceToPlayer() < manager.attackRange*2f)
            {
                manager.SetSpeed(0);
            }
        }
    }
}