using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_RangerRollState : E_PlayerNearState
{
    int RollingDirection;
    bool WallInfront;
    public E_RangerRollState(EnemyStateMachine stateMachine, E_Ranger enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
        CheckIfShouldFlip = false;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        IsDone = true;
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void DoCheck()
    {
        base.DoCheck();

        WallInfront = Ranger.WallInfront();
    }

    public override void Enter()
    {
        base.Enter();
        RollingDirection = Ranger.FacingDirection;

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override bool IsOnCooldown()
    {
        return Time.time < LastTimeFinish + EnemyData.RollCooldown;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!IsExiting)
        {
            if (!WallInfront)
            {
                Ranger.SetVelocityX(9.0f * RollingDirection);
            }
            else
            {
                StateMachine.ChangeState(Ranger.playerDetectedState);
            }
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
