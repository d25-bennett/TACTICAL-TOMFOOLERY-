using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHit : MonoBehaviour
{
    public GameObject laser;
    public GameObject Collectible;

    private int score;

    public Transform Respawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            laser.transform.position = Respawn.transform.position;
            //UNHOLD CODE
        }
        else if(collision.gameObject.tag == "coin")
        {
            Destroy(Collectible);
            score = score + 1;
        }
    }
}
