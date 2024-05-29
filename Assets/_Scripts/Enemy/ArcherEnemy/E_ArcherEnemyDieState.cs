using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ArcherEnemyDieState : EnemyDieState
{
    public E_ArcherEnemyDieState(EnemyStateMachine stateMachine, Enemy enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
    }
}
