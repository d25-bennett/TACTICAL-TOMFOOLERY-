using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    public bool active = false;

    private bool hit;
    private GameObject targetLightObj;
    private Light targetLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet" && !hit && active)
        {
            BeenHit();
        }
    }

    void Start()
    {
        targetLightObj = this.gameObject.transform.GetChild(0).gameObject;
       
    }

    public void MakeActive()
    {
        active = true;
        targetLightObj.SetActive(true);
    }

    void BeenHit()
    {
        hit = true;
        targetLightObj.SetActive(false);
        this.transform.parent.GetComponent<TargetSystem>().curTargetHit();
    }

}
