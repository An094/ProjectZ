using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thron : MonoBehaviour
{

    private Player player;

    private void OnEnable()
    {
        StartCoroutine(DisableThorn(5f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(collision.TryGetComponent<Player>(out player))
            {
                player.IsEntangled = true;
            }

            StopAllCoroutines();
            StartCoroutine(DisableThorn(2f));
        }
    }

    IEnumerator DisableThorn(float duration)
    {
        yield return new WaitForSeconds(duration);
        if (player != null)
        {
            player.IsEntangled = false;
        }
        //gameObject.SetActive(false);
        ObjectPoolManager.ReturnObjectToPool(gameObject);
    }
}
