using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterTesting : MonoBehaviour 
{
	public Character Raelin;

	public string speaker;

	// Use this for initialization
	void Start () 
	{
		Raelin = CharacterManager.instance.GetCharacter (speaker, enableCreatedCharacterOnStart: true);
		DialogueSystem.instance.Close();
	}

	public string[] speech;
	int i = 0;

	public Vector2 moveTarget;
	public float moveSpeed;
	public bool smooth;

	public int bodyIndex, expressionIndex = 0;
	public float speed = 5f;
	public bool smoothtransitions = false;

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			if (i < speech.Length)
			{
				Raelin.Say (speech [i], Input.GetKey(KeyCode.A));
			}
			else
				DialogueSystem.instance.Close ();

			i++;
		}

		if (Input.GetKey (KeyCode.M)) 
		{
			Raelin.MoveTo (moveTarget, moveSpeed, smooth);
		}

		if (Input.GetKeyDown (KeyCode.S)) 
		{
			Raelin.StopMoving (true);
		}

		if (Input.GetKeyDown (KeyCode.B)) 
		{
			if (Input.GetKey (KeyCode.T))
				Raelin.TransitionBody (Raelin.GetSprite (bodyIndex), speed, smoothtransitions);
			else
				Raelin.SetBody (bodyIndex);
		}
		if (Input.GetKeyDown (KeyCode.E)) 
		{
			if (Input.GetKey (KeyCode.T))
				Raelin.TransitionExpression (Raelin.GetSprite (expressionIndex), speed, smoothtransitions);
			else
				Raelin.SetExpression (expressionIndex);
		}

		if (Input.GetKeyDown(KeyCode.L))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
		}

		if (Input.GetKeyDown(KeyCode.F))
		{
			if (Input.GetKey(KeyCode.UpArrow))
				Raelin.FaceLeft();
			else if (Input.GetKey(KeyCode.DownArrow))
				Raelin.FaceRight();
			else
				Raelin.Flip();
		}
	}
}
