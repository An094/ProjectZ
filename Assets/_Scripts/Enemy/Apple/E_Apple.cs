using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Apple : Enemy
{
    public E_AppleIdleState IdleState { get; private set; }
    public E_AppleMoveState MoveState { get; private set; }
    protected override void Awake()
    {
        base.Awake();

        IdleState = new E_AppleIdleState(StateMachine, this, "Idle", EnemyData);
        MoveState = new E_AppleMoveState(StateMachine, this, "Move", EnemyData);
    }

    protected override void Start()
    {
        base.Start();

        StateMachine.Initialize(MoveState);
        //FacingDirection = -1;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Update()
    {
        base.Update();
    }
}
