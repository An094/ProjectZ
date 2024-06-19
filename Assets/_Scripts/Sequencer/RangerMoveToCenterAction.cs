using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ranger Move To Center", menuName = "Action/RangerMoveToCenterAction")]
public class RangerMoveToCenterAction : SequencerAction
{
    private SwordsSummoner SwordsSummoner;
    private GameObject Ranger;
    private Animator RangerAnimator;
    private Rigidbody2D RangerRigidbody2D;
    private E_Ranger RangerScript;

    private float TimeToMove = 1f;
    private float StartTime;

    private Vector3 TargetPosition;
    private Vector2 StartPosition;

    public override void Initialize(GameObject obj)
    {
        base.Initialize(obj);

        Ranger = obj;

        RangerAnimator = obj.GetComponent<Animator>();
        RangerRigidbody2D = obj.GetComponent<Rigidbody2D>();
        RangerScript = obj.GetComponent<E_Ranger>();

        SwordsSummoner = FindObjectOfType<SwordsSummoner>().GetComponent<SwordsSummoner>();

        TargetPosition.Set(23.5f, 0f, 0f);
    }

    public override IEnumerator StartSequence(Sequencer context)
    {
        StartTime = Time.time;
        StartPosition = Ranger.transform.position;

        float DefaultGravityScale = RangerRigidbody2D.gravityScale;
        RangerRigidbody2D.gravityScale = 0f;

        //RangerAnimator.SetBool("PlayerDetected", false);
        RangerAnimator.SetBool("InAir", true);

        float elapsedTime = 0f;
        while(elapsedTime < TimeToMove)
        {
            elapsedTime += Time.deltaTime;
            RangerAnimator.SetFloat("yVelocity", 0.1f);//fake jump
            Ranger.transform.position = Vector2.Lerp(StartPosition, TargetPosition, elapsedTime/TimeToMove);
            yield return null;
        }
        RangerAnimator.SetBool("InAir", false);
        RangerAnimator.SetBool("CastSpell", true);

        SwordsSummoner.TriggerSummoner();
        yield return new WaitForSeconds(6f);

        List<int> NumberOfBeamToFire = new List<int>{ 1, 1, 2, 2, 3, 3, 4 };
        for(int i = 0; i < NumberOfBeamToFire.Count; i++) 
        {
            SwordsSummoner.Fire(NumberOfBeamToFire[i]);
            yield return new WaitForSeconds(2f);
        }


        yield return RangerScript.StartCoroutine(SwordsSummoner.FinalMove());

        RangerAnimator.SetBool("CastSpell", false);
        RangerRigidbody2D.gravityScale = DefaultGravityScale;
        RangerScript.StateMachine.ChangeState(RangerScript.inAirState);
    }
}
