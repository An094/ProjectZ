using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;
using static UnityEngine.ParticleSystem;

public class SwordsSummoner : MonoBehaviour
{
    [SerializeField] private GameObject SwordAndPortalPref;
    [SerializeField] private List<Transform> swordsTransform;
    private List<PortalAndSword> portalAndSwords;
    // Start is called before the first frame update
    void Start()
    {
        portalAndSwords = new List<PortalAndSword>();
    }

    public void TriggerSummoner()
    {
        StartCoroutine(SummonSwords());
    }

    public IEnumerator FinalMove()
    {
        for(int i = 0; i< portalAndSwords.Count; ++i)
        {
            portalAndSwords[i].FinalMove();
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator SummonSwords()
    {
        for (int i = 0; i < swordsTransform.Count / 2; i++)
        {
            yield return StartCoroutine(SummonSword(i));
        }
    }

    IEnumerator SummonSword(int Index)
    {
        GameObject SwordNPortalObj = Instantiate(SwordAndPortalPref, swordsTransform[Index].position, swordsTransform[Index].rotation);
        portalAndSwords.Add(SwordNPortalObj.GetComponent<PortalAndSword>());

        SwordNPortalObj = Instantiate(SwordAndPortalPref, swordsTransform[swordsTransform.Count - 1 - Index].position, swordsTransform[swordsTransform.Count - 1 - Index].rotation);
        portalAndSwords.Add(SwordNPortalObj.GetComponent<PortalAndSword>());

        yield return new WaitForSeconds(1f);
    }

    public void Fire(int NumberOfBeam = 3)
    {
        List<int> SNPindices = GenerateUniqueRandomNumbers(0, swordsTransform.Count - 1, NumberOfBeam);

        foreach(var index in SNPindices)
        {
            portalAndSwords[index].Fire();
        }
    }

    public List<int> GenerateUniqueRandomNumbers(int min, int max, int count)
    {
        List<int> numbers = new List<int>();

        HashSet<int> uniqueNumbers = new HashSet<int>();
        System.Random rand = new System.Random();

        while (uniqueNumbers.Count < count)
        {
            int randomNumber = rand.Next(min, max + 1);
            if (!uniqueNumbers.Contains(randomNumber))
            {
                uniqueNumbers.Add(randomNumber);
            }
        }

        numbers.AddRange(uniqueNumbers);
        return numbers;
    }
}
