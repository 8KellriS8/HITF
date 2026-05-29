using UnityEngine;

public class JumpAttackState : BaseState
{
    public float timeRemaining = 2f;
    private bool timerIsRunning = false;
    private float rangeScale;
    public override void EnterState(EnemyStateManager manager)
    {
        manager.GetComponentInChildren<Renderer>().enabled = true;
        manager.outline.OutlineWidth = manager._outlineWidth;
        timerIsRunning = true;
        manager.warning.Play();
        manager.transform.LookAt(manager.player);
        if (manager._enemyType == 1)
        {
            rangeScale = 2f;
        }
        if (manager._enemyType == 2)
        {
            rangeScale = 1.25f;
        }
    }
    public override void ExitState(EnemyStateManager manager)
    {
        if (manager._enemyType == 1)
        {
            if (manager.land == 12)
            {
                manager.transform.position += manager.transform.forward * 1.6f;
            }
            Debug.Log(manager.land);
        }
        manager.outline.OutlineWidth = 0;
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
                manager._animator.SetBool("J_attack", true);
                manager._animator.SetBool("IsTrigered", false);
                if (manager._enemyType == 2)
                {
                    manager.SetSpeed(10);
                }
            }
        }
        else
        {
            if (manager.GetDistanceToPlayer() < manager.attackRange * rangeScale)
            {
                manager.SetSpeed(0);
                manager._animator.SetBool("InRadius", true);
            }
        }
    }
}