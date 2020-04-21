using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class DestroyAfter3 : MonoBehaviour 
 {
     void OnAwake()
     {
        Destroy(gameObject, 3);
     }
	
 }