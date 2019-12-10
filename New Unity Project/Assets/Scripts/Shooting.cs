using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform Spawn;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Rigidbody PrefabShot;
            PrefabShot = (Rigidbody)Instantiate(projectile, Spawn.position, projectile.rotation);

            PrefabShot.velocity = Spawn.TransformDirection(Vector3.forward * 40);
        }
    }
}
