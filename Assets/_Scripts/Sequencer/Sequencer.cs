using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequencer : MonoBehaviour
{
    public List<SequencerAction> SequencerActions;

    private void Awake()
    {
        foreach (var action in SequencerActions)
        {
            action.Initialize(gameObject);
        }
    }
    public void IntializeSequence()
    {
        StartCoroutine(ExecuteSequencer());
    }

    private IEnumerator ExecuteSequencer()
    {
        foreach(var action in SequencerActions)
        {
            yield return StartCoroutine(action.StartSequence(this));
        }
    }
}
