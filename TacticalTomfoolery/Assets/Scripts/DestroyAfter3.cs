using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class DestroyAfter3 : MonoBehaviour 
 {
     void OnCollisionEnter(Collision other) 
     {
        Destroy(gameObject, 3);
     }
 }