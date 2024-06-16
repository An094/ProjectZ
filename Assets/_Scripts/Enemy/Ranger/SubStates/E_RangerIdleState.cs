using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_RangerIdleState : EnemyState
{
    public E_RangerIdleState(EnemyStateMachine stateMachine, Enemy enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
    }
}
