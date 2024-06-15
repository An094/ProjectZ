using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAndSword : MonoBehaviour
{
    [SerializeField] private GameObject Portal;
    [SerializeField] private GameObject Sword;
    [SerializeField] private Animator PortalAnimator;
    [SerializeField] private Transform DefaultSwordPosition;
    [SerializeField] private Transform BeamPosition;
    [SerializeField] private GameObject BeamAttack;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SummonSword());
    }

    private IEnumerator SummonSword()
    {
        yield return new WaitForSeconds(1f);
        PortalAnimator.Play("Idle");
        float RandomX = Random.Range(-0.25f, 0.2f);
        Sword.transform.DOLocalMoveX(RandomX, 0.5f);
    }

    public void Fire()
    {
        Instantiate(BeamAttack, BeamPosition.transform.position, transform.rotation);
    }
}
