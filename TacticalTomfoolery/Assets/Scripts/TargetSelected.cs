using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelected : MonoBehaviour
{
    public Material Material_1;
    public Material Material_2;

    public Texture[] textures;

    //in the editor this is what you would set as the object you wan't to change
    public GameObject Object;
    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        Object.GetComponent<MeshRenderer>().material = Material_1;
        //or
        //rend = GetComponent<Renderer>();
        //rend.material.mainTexture = textures[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))// CHANGE TO ON LOOK
        {
            Object.GetComponent<MeshRenderer>().material = Material_2;
            //or
            //rend.material.mainTexture = textures[2];
        }
        else
        {
            Object.GetComponent<MeshRenderer>().material = Material_1;
            //or
      
            //rend.material.mainTexture = textures[1];
        }
    }
    }

