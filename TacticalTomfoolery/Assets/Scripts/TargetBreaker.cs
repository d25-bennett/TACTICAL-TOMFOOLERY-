using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBreaker : MonoBehaviour
{
    public GameObject cube;
    public GameObject bullet;
    public GameObject BrokenCube;

    public Transform breakPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "boom")
        {
            Destroy(cube);
            Instantiate(BrokenCube,breakPoint.position, breakPoint.rotation);
        }
    }
}
