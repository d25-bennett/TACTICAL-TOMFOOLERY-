using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSystem : MonoBehaviour
{
    public bool finished;

    private GameObject[] targets;
    private int curTargetNum;

    void Start()
    {
        targets = new GameObject[transform.childCount];
        finished = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            targets[i] = transform.GetChild(i).gameObject;
        }

        StartPuzzle();
    }

    public void StartPuzzle()
    {

        curTargetNum = 0;
        targets[curTargetNum].GetComponent<TargetHit>().MakeActive();

    }

    public void curTargetHit()
    { 
        if (curTargetNum < targets.Length)
        {
            curTargetNum++;
            targets[curTargetNum].GetComponent<TargetHit>().MakeActive();

        }
        else
        {
            finished = true;
        }
    }
}
