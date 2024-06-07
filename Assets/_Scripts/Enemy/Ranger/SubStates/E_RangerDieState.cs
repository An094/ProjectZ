using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_RangerDieState : EnemyState
{
    public E_RangerDieState(EnemyStateMachine stateMachine, Enemy enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
    }
}
