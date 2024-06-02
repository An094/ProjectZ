using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieState : EnemyState
{
    public EnemyDieState(EnemyStateMachine stateMachine, Enemy enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isAnimationFinished)
        {
            if(EnemyData.IsTriggerExplositionAfterDead)
            {
                GameObject Explosion = GameObject.Instantiate(EnemyData.Explosion, Enemy.transform.position, Enemy.transform.rotation);

                if(Explosion.TryGetComponent<Explostion>(out Explostion explostionScript))
                {
                    explostionScript.ExplosionRadius = EnemyData.ExplosionRadius;
                }
            }
            GameObject.Destroy(Enemy.gameObject);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
