using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{

    Rigidbody m_Rigidbody;
    public bool unlocked;
    public bool collid;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        unlocked = false;
        m_Rigidbody.freezeRotation = true;
        collid = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        collid = true;
        if (other.tag == "key")
        {
            m_Rigidbody.freezeRotation = false;
            unlocked = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        collid = true;
        if (other.tag == "key")
        {
            m_Rigidbody.freezeRotation = false;
            unlocked = true;
        }
    }
}
