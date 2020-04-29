using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clipboardRenderer : MonoBehaviour
{

	public Material[] mat;
	MeshRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
		rend = GetComponent<MeshRenderer>();
		StartText();
    }

	public void StartText()
	{
		rend.material = mat[0];
	}

	public void MorseText()
	{
		rend.material = mat[1];
	}

	public void EndText()
	{
		rend.material = mat[2];
	}

}
