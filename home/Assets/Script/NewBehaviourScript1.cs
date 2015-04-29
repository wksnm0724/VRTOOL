using UnityEngine;
using System.Collections;

public class NewBehaviourScript1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape)|| Input.GetKeyDown(KeyCode.Menu) )
		{
			Application.LoadLevel("launcher");
		}
	
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(0,0,300,100),"change"))
		{
			Application.LoadLevel("launcher");
		}
	}
}
