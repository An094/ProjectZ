using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangerPushOutAction", menuName = "Action/PushOut")]
public class RangerPushOutAction : SequencerAction
{
    private GameObject RangerObj;
    private Animator RangerAnimator;

    public override void Initialize(GameObject obj)
    {
        base.Initialize(obj);

        RangerObj = obj;
        RangerAnimator = obj.GetComponent<Animator>();
    }

    public override IEnumerator StartSequence(Sequencer context)
    {
        RangerAnimator.SetBool("PlayerDetected", false);
        RangerAnimator.SetBool("PushOut", true);
        //yield return new WaitForSeconds(RangerAnimator.GetCurrentAnimatorStateInfo(0).length);
        yield return new WaitForSeconds(1.5f);
        RangerAnimator.SetBool("PushOut", false);
    }
}
