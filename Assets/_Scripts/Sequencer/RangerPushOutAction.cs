using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangerPushOutAction", menuName = "Action/PushOut")]
public class RangerPushOutAction : SequencerAction
{
    private GameObject RangerObj;
    private Animator RangerAnimator;
    public GameObject LightingShield;

    private Rigidbody2D RangerRigidbody;

    private E_Ranger ranger;

    public override void Initialize(GameObject obj)
    {
        base.Initialize(obj);

        RangerObj = obj;
        RangerAnimator = obj.GetComponent<Animator>();
        RangerRigidbody = obj.GetComponent<Rigidbody2D>();
        ranger = RangerObj.GetComponent<E_Ranger>();
    }

    public override IEnumerator StartSequence(Sequencer context)
    {
        RangerRigidbody.velocity = Vector3.zero;
        RangerAnimator.SetBool("PlayerDetected", false);
        RangerAnimator.SetBool("CastSpell", true);
        yield return new WaitForSeconds(0.75f);
        RangerAnimator.SetBool("CastSpell", false);
        RangerAnimator.SetBool("CastSpell", true);
        Vector3 RangerShieldPosition = ranger.PlayerCheck.position;
        Instantiate(LightingShield, RangerShieldPosition, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        RangerAnimator.SetBool("CastSpell", false);
    }
}
