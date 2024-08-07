using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_RangerSkillBeamAttack : E_PlayerFarState
{
    Transform BeamPosition;
    public E_RangerSkillBeamAttack(EnemyStateMachine stateMachine, E_Ranger enemy, string animName, EnemyData enemyData, Transform beamPosition) : base(stateMachine, enemy, animName, enemyData)
    {
        BeamPosition = beamPosition;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        GameManager.Instance.PlaySFX("Shot");
        ObjectPoolManager.SpawnObject(EnemyData.BeamPref, BeamPosition.position, Quaternion.identity);
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        GameManager.Instance.PlaySFX("Draw");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override bool IsOnCooldown()
    {
        return Time.time < LastTimeFinish + EnemyData.BeamAttackCooldown;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
