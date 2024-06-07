using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_RangerHurtState : EnemyState
{
    public E_RangerHurtState(EnemyStateMachine stateMachine, Enemy enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
    }
}
