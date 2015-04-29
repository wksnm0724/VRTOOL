using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	public Texture dian;
	float width;
	float height;

	int item_width;
	int item_height;


	Rect rect1;
	Rect rect2;
	// Use this for initialization
	void Start () {


		item_width = 20;
		item_height = 20;
	
		//rect2 = new Rect (width/2.0f-item_width,height/4.0f*3-item_height/2.0f,item_width,item_height);
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetKeyDown(KeyCode.Escape)|| Input.GetKeyDown(KeyCode.Home) )
//		{
//			Application.Quit();
//		}
	
	}
	
	void OnGUI()
	{
		width = Screen.width;
		height = Screen.height;

		rect1 = new Rect (width/4.0f-10,
		                  height/2.0f-10,
		                  item_width,
		                  item_height);
		rect2 = new Rect (width/4.0f*3-10,
		                  height/2.0f-10,
		                  item_width,
		                  item_height);

		//绘制两个两个点

		GUI.DrawTexture (rect1,dian);
		GUI.DrawTexture (rect2,dian);

		GUI.Label (new Rect(0,0,100,50),width+"  "+height);
		GUI.Label (new Rect(Screen.width-100,0,100,50),width+"  "+height);


	}
}
