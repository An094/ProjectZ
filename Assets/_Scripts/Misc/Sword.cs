using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private float speed;

    [SerializeField]
    private float gravity;
    [SerializeField]
    private float damageRadius;

    protected Rigidbody2D rb;

    protected bool isGravityOn;
    protected bool hasHitGround;
    protected float Dmg;

    [SerializeField]
    protected LayerMask whatIsGround;
    [SerializeField]
    protected LayerMask whatIsPlayer;
    [SerializeField]
    private Transform damagePosition;

    private Vector3 TouchGroundPosition;

    public virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void OnEnable()
    {
        rb.gravityScale = 0.0f;

        isGravityOn = false;
        hasHitGround = false;
        TouchGroundPosition = Vector3.zero;
    }

    public virtual void Update()
    {
        if (!hasHitGround)
        {
            //attackDetails.position = transform.position;

            if (isGravityOn)
            {
                float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
        else
        {
            transform.position = TouchGroundPosition;
        }
    }

    public virtual void FixedUpdate()
    {
        if (!hasHitGround)
        {
            Collider2D damageHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsPlayer);
            Collider2D groundHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsGround);

            if (damageHit)
            {
                OnHitPlayer(damageHit);
            }

            if (groundHit)
            {
                OnHitGround();
            }

        }
        else
        {
            transform.position = TouchGroundPosition;
        }
    }

    public void FireProjectile(float speed, float damage)
    {
        this.speed = speed;
        this.Dmg = damage;

        rb.velocity = transform.up * speed;
    }

    protected virtual void OnHitPlayer(Collider2D player)
    {
        if (player.TryGetComponent<IDamageable>(out IDamageable playerConbatController))
        {
            playerConbatController.Damage(new DamgeDetails(Dmg, transform));
        }
        //Destroy(gameObject);
        ObjectPoolManager.ReturnObjectToPool(gameObject);
    }

    protected virtual void OnHitGround()
    {
        TouchGroundPosition = transform.position;
        hasHitGround = true;
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;
        StartCoroutine(ReturnToPoolAfterTime());
    }

    private IEnumerator ReturnToPoolAfterTime()
    {
        float ElapsedTime = 0f;
        while(ElapsedTime < 10f)
        {
            ElapsedTime += Time.deltaTime;
            yield return null;
        }
        ObjectPoolManager.ReturnObjectToPool(gameObject);
    }
}
