using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperSystem : MonoBehaviour
{
    private GameObject[] paper;
    private int picesSlotted = 0;
    public EventManager events;


    void Start()
    {
        paper = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            paper[i] = transform.GetChild(i).gameObject;
            paper[i].SetActive(false);
        }
   


    }
   
    public void SpawnCupboardPaper()
    {
        paper[0].SetActive(true);

    }

    public void SpawnVHSPaper()
    {
        paper[1].SetActive(true);
        paper[2].SetActive(true);
        paper[3].SetActive(true);
    }

    public void SpawnTargetPaper()
    {
        paper[4].SetActive(true);
    }

    public void PaperPlaced()
    {

        picesSlotted++;

        if (picesSlotted == 3)
        {
            events.EndVoice();
        }
        else if (picesSlotted == 1)
        {
            events.PickUpPaper();
        }
    }
  
}
