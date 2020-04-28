using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSystem : MonoBehaviour
{
    public EventManager events;

    private GameObject[] targets;
    private int curTargetNum;

    void Start()
    {
        targets = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            targets[i] = transform.GetChild(i).gameObject;
            targets[i].SetActive(false);
        }
        
        StartPuzzle();
    }

    public void StartPuzzle()
    {

        curTargetNum = 0;
        targets[curTargetNum].SetActive(true);
        targets[curTargetNum].GetComponent<TargetHit>().MakeActive();

    }

    public void curTargetHit()
    { 
        if (curTargetNum < (targets.Length -1))
        {
            curTargetNum++;
            targets[curTargetNum].SetActive(true);
            targets[curTargetNum].GetComponent<TargetHit>().MakeActive();

        }
        else
        {
            events.DestroyedTargets();
        }
    }
}
