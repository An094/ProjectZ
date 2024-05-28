using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected EnemyData EnemyData;

    public Rigidbody2D Rb {  get; private set; }
    public Animator Animator {  get; private set; }

    public EnemyStateMachine StateMachine { get; private set; }
    
    public EnemyAttackState AttackState;

    [SerializeField]
    private Transform GroundCheck;
    [SerializeField]
    private Transform WallCheck;
    [SerializeField]
    private Transform LedgeCheck;
    [SerializeField]
    private Transform PlayerCheck;

    private Vector2 Workspace;
    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }

    protected virtual void Awake()
    {
        StateMachine = new EnemyStateMachine();
    }

    protected virtual void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

        FacingDirection = 1;
    }

    protected virtual void Update()
    {
        CurrentVelocity = Rb.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    protected virtual void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicUpdate();
    }

    public void SetVelocityX(float velocity)
    {
        Workspace.Set(velocity, CurrentVelocity.y);
        Rb.velocity = Workspace;
        CurrentVelocity = Workspace;
    }

    public void SetVelocityY(float velocity)
    {
        Workspace.Set(CurrentVelocity.x, velocity);
        Rb.velocity = Workspace;
        CurrentVelocity = Workspace;
    }
    public void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0f, 180f, 0f);
    }

    private void TriggerAttack()
    {
        AttackState.TriggerAttack();
    }

    private void FinishAttack()
    {
        AttackState.FinishAttack();
    }

    public bool IsGrounded() => Physics2D.OverlapCircle(GroundCheck.position, EnemyData.GroundCheckRadius, EnemyData.WhatIsGround);
    public bool IsTouchingWall() => Physics2D.Raycast(WallCheck.position, Vector2.right * FacingDirection, EnemyData.WallCheckRadius, EnemyData.WhatIsGround);
    public bool LedgeVertical() => Physics2D.Raycast(LedgeCheck.position, Vector2.down, EnemyData.LedgeCheckRadius, EnemyData.WhatIsGround);
    public bool CheckPlayerInMinAgroRange() => Physics2D.Raycast(PlayerCheck.position, Vector2.right * FacingDirection, EnemyData.MinAgroDistance, EnemyData.WhatIsPlayer);
    public bool CheckPlayerInMaxAgroRange() => Physics2D.Raycast(PlayerCheck.position, Vector2.right * FacingDirection, EnemyData.MaxAgroDistance, EnemyData.WhatIsPlayer);
    public bool CheckPlayerInCloseRangeAction() => Physics2D.Raycast(PlayerCheck.position, Vector2.right * FacingDirection, EnemyData.CloseRangeActionDistance, EnemyData.WhatIsPlayer);

}
