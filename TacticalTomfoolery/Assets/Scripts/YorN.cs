using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YorN : MonoBehaviour
{
    bool m_Yes = false;
    bool m_Yes_1 = false;
    bool m_No = false;
    bool m_No_1 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "yes")
        {
               
            m_Yes = true;
            if (m_Yes)
            {
                StartCoroutine(ExecuteAfterTimeYes(1));
                if (m_Yes_1 == true)
                {
                    //DO WHATEVER 
                    Debug.Log("Hi");
                }
            }
        }
        if (other.gameObject.tag == "no")
        {
            m_No = true;
            if (m_No)
            {
                StartCoroutine(ExecuteAfterTimeNo(1));
                if (m_No_1 == true)
                {
                    //DO WHATEVER 
                }
            }
        }
    }

    IEnumerator ExecuteAfterTimeYes(float time)
    {
        yield return new WaitForSeconds(time);

        m_Yes_1 = true;
    }
    IEnumerator ExecuteAfterTimeNo(float time)
    {
        yield return new WaitForSeconds(time);

        m_No_1 = true;
    }
}
