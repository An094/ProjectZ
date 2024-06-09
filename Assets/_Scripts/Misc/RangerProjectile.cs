using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerProjectile : Projectile
{
    [SerializeField]
    private ProjectileData projectileData;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private bool HitPlayer = false;
    private Vector2 hitPosition;

    private Player PlayerScript;
    public override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        animator.enabled = false;

        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = projectileData.ProjectileSprite;
    }

    public override void Update()
    {
        if (!HitPlayer)
        {
            base.Update();
        }
        else
        {
            transform.position = hitPosition;
            rb.velocity = Vector2.zero;
        }
    }

    public override void FixedUpdate()
    {
        if (!HitPlayer)
        {
            base.FixedUpdate();
        }
    }

    protected override void OnHitGround()
    {
        hasHitGround = true;
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;

        bool isHitOnWall = IsHitOnWall();
        if (projectileData.Type == ProjectileType.Thorn && isGravityOn && !isHitOnWall)
        {
            if(transform.right.x > 0)
            {
                transform.rotation = Quaternion.identity;
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }

            animator.enabled = true;
            animator.SetBool("Normal", false);
            animator.SetBool("Thorn", true);

            StartCoroutine(CreateThornAfterDisable());
        }
        else
        {
            Destroy(gameObject, 2f);
        }
    }

    protected override void OnHitPlayer(Collider2D player)
    {
        animator.enabled = true;
        animator.SetBool("Normal", false);

        HitPlayer = true;

        hitPosition = transform.position;

        if (player.TryGetComponent<IDamageable>(out IDamageable playerConbatController))
        {
            playerConbatController.Damage(new DamgeDetails(Dmg, transform));
        }

        switch (projectileData.Type)
        {
            case ProjectileType.Normal:
                {
                    break;
                }

            case ProjectileType.Entangle:
                {
                    animator.SetBool("Entangle", true);

                    if(player.TryGetComponent<Player>(out PlayerScript))
                    {
                        PlayerScript.IsEntangled = true;
                    }

                    StartCoroutine(DisableAfterEntangle());

                    break;
                }

            case ProjectileType.Poison:
                {
                    animator.SetBool("Poison", true);
                    StartCoroutine(DisableAfterPoison());
                    break;
                }

            case ProjectileType.Thorn:
                {
                    Destroy(gameObject);
                    break;
                }

            default:
                {
                    break;
                }
        }
    }

    IEnumerator DisableAfterEntangle()
    {
        yield return new WaitForSeconds(2f);
        PlayerScript.IsEntangled = false;
        gameObject.SetActive(false);
    }

    IEnumerator DisableAfterPoison()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }

    IEnumerator CreateThornAfterDisable()
    {
        yield return new WaitForSeconds(1f);

        if(transform.right.x > 0f)
        {
            Instantiate(projectileData.ThornPref, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(projectileData.ThornPref, transform.position, Quaternion.Euler(0f, 180f, 0f));
        }

        gameObject.SetActive(false);
    }

    private bool IsHitOnWall() =>  Physics2D.Raycast(transform.position, transform.right, 0.5f, whatIsGround);
}
