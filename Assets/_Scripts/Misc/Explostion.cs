using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explostion : MonoBehaviour
{
    public float ExplosionRadius { get; set; }
    private void Trigger()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.transform.position, ExplosionRadius);
    
        foreach(Collider2D hit in hits)
        {
            if(hit.TryGetComponent<IKnockBackable>(out IKnockBackable knockBackableObj))
            {
                int direction = hit.transform.position.x - transform.position.x > 0 ? 1 : -1;
                knockBackableObj.KnockBack(new KnockBackDetails(direction , 5f));
            }

            if(hit.TryGetComponent<IDamageable>(out IDamageable damageableObj))
            {
                damageableObj.Damage(new DamgeDetails(50f, transform.transform));
            }    
        }
    }

    private void TriggerFinishAnimation()
    {
        this.gameObject.SetActive(false);
    }
}
