using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetectedState : EnemyState
{
    E_Apple EnemyApple;

    public EnemyPlayerDetectedState(EnemyStateMachine stateMachine, E_Apple enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
        EnemyApple = enemy;
    }


}
