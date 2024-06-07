using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_RangerLandState : EnemyState
{
    E_Ranger Ranger;
    public E_RangerLandState(EnemyStateMachine stateMachine, E_Ranger enemy, string animName, EnemyData enemyData) : base(stateMachine, enemy, animName, enemyData)
    {
        Ranger = enemy;
    }

}
