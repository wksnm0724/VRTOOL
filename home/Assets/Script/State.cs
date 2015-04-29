using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class State : MonoBehaviour {

	public Texture t1;
	public Texture t2;
	public Texture t3;

	Rect r10;
	Rect r11;
	Rect r20;
	Rect r21;
	Rect r30;
	Rect r31;

	// Use this for initialization
	void Start () {



	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		float width = Screen.width;
		float height = Screen.height;
		float width1 = width / 2.0f;
		float height1 = height / 2.0f;
		
		r10 = new Rect (width-50-100,100,50,50);
		r20 = new Rect (width-100-100,100,50,50);
		r30 = new Rect (width-150-100,100,50,50);
		
		r11 = new Rect (width1-50-100,100,50,50);
		r21 = new Rect (width1-100-100,100,50,50);
		r31 = new Rect (width1-150-100,100,50,50);


		GUI.DrawTexture (r10,t1);
		GUI.DrawTexture (r11,t1);

		GUI.DrawTexture (r20,t2);
		GUI.DrawTexture (r21,t2);

		GUI.DrawTexture (r30,t3);
		GUI.DrawTexture (r31,t3);
	}
}
