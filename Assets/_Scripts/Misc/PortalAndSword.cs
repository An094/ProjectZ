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
    //private SwordsSummoner swordsSummoner;
    private Transform SwordTransform;
    private Transform PlayerTransform;
    //private bool CanRegister = false;//TODO
    public int Index;

    private void Awake()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //swordsSummoner = FindObjectOfType<SwordsSummoner>().GetComponent<SwordsSummoner>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SwordTransform = Sword.GetComponent<Transform>();
        StartCoroutine(SummonSword());
    }

    //private void OnEnable()
    //{
    //    swordsSummoner.OnFire += OnFire;
    //}

    //private void OnDisable()
    //{
    //    swordsSummoner.OnFire -= OnFire;
    //}

    //private void OnFire()
    //{
    //    CanRegister = true;
    //}

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if(CanRegister)
//        {
//            CanRegister = false;
//            if (collision.CompareTag("Player"))
//            {
////                swordsSummoner.waitingPNSQueue.Enqueue(Index);
//            }
//        }

//    }

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
       // CanRegister = true;
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
        Sequence FinalMoveSq = DOTween.Sequence().
                                Append(SwordTransform.DORotate(SwordTransform.rotation.eulerAngles, 1f, RotateMode.FastBeyond360))
                                .AppendCallback(() =>
                                {
                                    Vector2 direction = PlayerTransform.position - SwordTransform.position;
                                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                                    SwordTransform.DORotate(new Vector3(0f, 0f, angle - 90), 0.5f, RotateMode.FastBeyond360).OnComplete(() =>
                                    {
                                        GameObject SwordObject = Instantiate(SwordPref, SwordTransform.position, SwordTransform.rotation);
                                        Sword SwordScript = SwordObject.GetComponent<Sword>();
                                        SwordScript.FireProjectile(30f, 20f);
                                        Sword.SetActive(false);
                                    });
                                });
    }
}
