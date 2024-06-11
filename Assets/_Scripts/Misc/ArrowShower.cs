using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShower : MonoBehaviour
{
    private Collider2D Collider;
    // Start is called before the first frame update
    void Start()
    {
        Collider = GetComponent<BoxCollider2D>();
        Collider.enabled = false;
    }

    public void EnableCollider()
    {
        Collider.enabled = true;
    }

    public void DisableCollider()
    {
        Collider.enabled = false;
    }

    public void DisableObject()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(collision.TryGetComponent<IDamageable>(out IDamageable playerDamageale))
            {
                playerDamageale.Damage(new DamgeDetails(10f, transform));
            }
        }
    }

}
