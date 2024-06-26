using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_RangerSkillFallingStarState : E_PlayerFarState
{
    public E_RangerSkillFallingStarState(EnemyStateMachine stateMachine, E_Ranger enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        GameManager.Instance.PlaySFX("Shot");
        Vector2 ArrowShowerPostion = new Vector2(Ranger.Player.transform.position.x, -2.3f);
        GameObject.Instantiate(EnemyData.ArrowShower, ArrowShowerPostion, Quaternion.identity);
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
        return Time.time < LastTimeFinish + EnemyData.FallingStarCooldown;
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
