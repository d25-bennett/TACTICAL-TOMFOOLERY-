using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paperSystem : MonoBehaviour
{
    private GameObject[] paper;

    void Start()
    {
        paper = new GameObject[transform.childCount];
    //    for (int i = 0; i < transform.childCount; i++)
     //   {
     //       paper[i].SetActive(true);
     //   }
   


    }
   
    public void SpawnPaper1()
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

  
}
