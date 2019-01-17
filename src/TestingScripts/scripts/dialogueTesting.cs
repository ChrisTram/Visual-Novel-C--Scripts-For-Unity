using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueTesting : MonoBehaviour {

	DialogueSystem ds;

	// Use this for initialization
	void Start () 
	{
		ds = DialogueSystem.instance;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.S)) 
		{
			ds.Say ("What dis tang here be?", "Me");
		}
	}
}
