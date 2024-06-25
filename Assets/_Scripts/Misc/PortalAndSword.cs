using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;

//using System.Numerics;
using UnityEngine;

public class PortalAndSword : MonoBehaviour
{
    [SerializeField] private GameObject Portal;
    [SerializeField] private GameObject Sword;
    [SerializeField] private GameObject Mask;
    [SerializeField] private Animator PortalAnimator;
    [SerializeField] private Transform DefaultSwordPosition;
    [SerializeField] private Transform BeamPosition;
    [SerializeField] private GameObject BeamAttack;
    [SerializeField] private GameObject SwordPref;
    private Transform SwordTransform;
    private Transform PlayerTransform;

    // Start is called before the first frame update
    void Start()
    {
        SwordTransform = Sword.GetComponent<Transform>();

        PlayerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

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

    public IEnumerator FinalForm()
    {
        PortalAnimator.Play("Close");
        yield return new WaitForSeconds(0.5f);
        Portal.SetActive(false);
        Mask.SetActive(false);
    }

    public void FinalMove()
    {
        Vector2 direction = PlayerTransform.position - SwordTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Sequence FinalMoveSq = DOTween.Sequence().
                                Append(SwordTransform.DORotate(SwordTransform.rotation.eulerAngles, 1f, RotateMode.FastBeyond360))
                                .Append(SwordTransform.DORotate(new Vector3(0f, 0f, angle - 90), 0.5f, RotateMode.FastBeyond360))
                                //.Append(SwordTransform.DOMove(PlayerTransform.position, 1.5f).SetEase(Ease.InOutQuad));
                                .AppendCallback(() =>
                                {
                                    GameObject SwordObject = Instantiate(SwordPref, SwordTransform.position, SwordTransform.rotation);
                                    Sword SwordScript = SwordObject.GetComponent<Sword>();
                                    SwordScript.FireProjectile(20f, 20f);
                                    Sword.SetActive(false);
                                });
    }
}
