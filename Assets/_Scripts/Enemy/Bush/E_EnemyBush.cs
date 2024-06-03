using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_EnemyBush : Enemy
{
    public Transform PatrolStartPosition;
    public Transform PatrolFinishPosiion;
    [SerializeField] Transform AttackPostion;

    public SpriteRenderer Renderer { get; private set; }
    public Collider2D Collider { get; private set; }

    public E_EnemyBushMoveState MoveState {  get; private set; }
    public E_EnemyBushDigState DigState { get; private set; }
    public E_EnemyBushRiseUpState RiseState { get; private set; }
    public E_EnemyWaitState WaitState { get; private set; }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        StateMachine.CurrentState.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        StateMachine.CurrentState.AnimationTrigger();
    }

    public override bool Damage(DamgeDetails attackDetail)
    {
        return base.Damage(attackDetail);
    }

    public override void KnockBack(KnockBackDetails details)
    {
        base.KnockBack(details);
    }

    protected override void Awake()
    {
        base.Awake();

        MoveState = new E_EnemyBushMoveState(StateMachine, this, "Move", EnemyData, AttackPostion);
        DigState = new E_EnemyBushDigState(StateMachine, this, "Dig", EnemyData);
        RiseState = new E_EnemyBushRiseUpState(StateMachine, this, "Rise", EnemyData);
        WaitState = new E_EnemyWaitState(StateMachine, this, "Wait", EnemyData);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Start()
    {
        base.Start();

        Renderer = GetComponent<SpriteRenderer>();
        Collider = GetComponent<Collider2D>();

        transform.position = PatrolStartPosition.position;

        FacingDirection = -1;

        StateMachine.Initialize(WaitState);
    }

    protected override void Update()
    {
        base.Update();
    }
}
