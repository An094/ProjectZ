using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class PlayerAttackState : PlayerAbilityState
{
    private int AttackCounter;
    private float LastAttackedTime;
    int xInput;
    private List<Transform> AttackPostion;

    public PlayerAttackState(PlayerStateMachine stateMachine, Player player, string animName, PlayerData playerData, List<Transform> attackPosition) : base(stateMachine, player, animName, playerData)
    {
        AttackCounter = - 1;
        AttackPostion = attackPosition;
    }

    public override void AniamtionTrigger()
    {
        base.AniamtionTrigger();

        ///TODO: Handle attack 
        Collider2D[] hits = Physics2D.OverlapCircleAll(AttackPostion[AttackCounter].position, PlayerData.MeleeAttackRadius[AttackCounter], PlayerData.WhatIsEnemy);

        if (hits.Length > 0 )
        {
            foreach(Collider2D hit in hits )
            {
                if(hit.TryGetComponent<IDamageable>(out IDamageable damageable))
                {
                   
                    if(!damageable.Damage(new DamgeDetails(PlayerData.AttackDamage, Player.transform)))
                    {
                        if (Player.gameObject.TryGetComponent<IKnockBackable>(out IKnockBackable PlayerKnockBackable))
                        {
                            PlayerKnockBackable.KnockBack(new KnockBackDetails(-Player.FacingDirection, 5f));
                        }
                    }
                    else
                    {
                        Quaternion quaternion = Quaternion.identity;

                        if(Player.FacingDirection == 1)
                        {
                            quaternion.SetEulerRotation(0f, 180f, 0f);
                        }
                        GameObject.Instantiate(PlayerData.HitAnimation, AttackPostion[AttackCounter].position, quaternion);
                        //GameObject.Instantiate(PlayerData.BloodParticle, AttackPostion.position, quaternion);
                        GameManager.Instance.PlayHitSFX();
                    }

                }

                if(hit.TryGetComponent<IKnockBackable>(out IKnockBackable knockBackable))
                {
                    knockBackable.KnockBack(new KnockBackDetails(Player.FacingDirection, PlayerData.KnockBackStrength));
                }
            }
        }
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        LastAttackedTime = Time.time;
        IsAbilityDone = true;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        //if (Time.time < LastAttackedTime + 0.1f)
        //{
        //    return;
        //}


        IsAbilityDone = false;// use this for only attack state.

        if (Time.time > LastAttackedTime + 1.5f) 
        {
            AttackCounter = 0;
        }
        else
        {
            AttackCounter = AttackCounter < 2 ? AttackCounter + 1 : 0;
        }

        GameManager.Instance.PlayerAttackSFX(true, AttackCounter + 1);
        //Player.SetVelocityZero();

        Player.Animator.SetInteger("AttackCounter", AttackCounter);
        int attackDir = xInput != 0 ? xInput : Player.FacingDirection;
        Player.SetVelocityX(attackDir * 0.1f);
        Player.SetVelocityY(1f);
    }

    public override void Exit()
    {
        base.Exit();
       // Player.SetVelocityZero();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = Player.InputHandler.NormalInputX;

        //Player.CheckIfShouldFlip(xInput);
        
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
