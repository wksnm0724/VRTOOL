using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectItem : MonoBehaviour {


	/// <summary>
	/// 0 转盘模式  1平铺模式
	/// </summary>
	public int model=0;
	public GUISkin mySkin;
	/// <summary>
	/// 菜单的个数
	/// </summary>
	public static readonly int  itemCount=5; 

	/// <summary>
	/// 当前处于选中状态的索引
	/// </summary>
	public int currentIndex=0;

    /// <summary>
    /// 记录所有的位置
    /// </summary>
	List<Vector3> allPosition=new List<Vector3>();
	List<Vector3> allPosition1=new List<Vector3>();
 	// Use this for initialization
	void Start () {

		//初始化几个物体的位置

		for (int i=1; i<=itemCount; i++) {
		
			GameObject obj=GameObject.Find("home/pCube"+i);
			if(obj!=null)
			{
				allPosition.Add(obj.transform.position);
			}
		}

		for (int i=1; i<=itemCount; i++) {
			
			GameObject obj=GameObject.Find("home1/pCube"+i);
			if(obj!=null)
			{
				allPosition1.Add(obj.transform.position);
			}
		}
	
	}
	
	// Update is called once per frame
	void Update () {

		//Click ();

		//TestRay ();

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
	
			ItemMove(0);
				}

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			ItemMove(1);
	}

		if (model == 0) {
						for (int i=1; i<=5; i++) {


				int j=(i - 1 + currentIndex) % 5;
				float sudu=0;

				if(j==2||j==3)
				{
					sudu=15;
				}
				if(j==1||j==4)
				{
					sudu=5;
				}
				if(j==0)
				{
					sudu=3;
				}
								GameObject obj = GameObject.Find ("home/pCube" + i);
								if (obj != null) {
										obj.transform.position = Vector3.MoveTowards (
					obj.transform.position,
					allPosition [(i - 1 + currentIndex) % 5],
						Time.deltaTime * sudu
										);
								}
						}
				}

		if (model == 1) {

			for (int i=1; i<=5; i++) {

				int j=(i - 1 + currentIndex) % 5;
				float sudu=0;
				if(j==2||j==3)
				{
					sudu=15;
				}
				if(j==1||j==4)
				{
					sudu=5;
				}
				if(j==0)
				{
					sudu=3;
				}
				GameObject obj = GameObject.Find ("home/pCube" + i);
				if (obj != null) {
					obj.transform.position = Vector3.MoveTowards (
						obj.transform.position,
						allPosition1 [j],
						Time.deltaTime * sudu
						);
				}
			}

				}
	}
	


	void OnGUI()
	{

		if(GUI.Button(new Rect(0,0,200,200),"change"))
		{
			GameObject[] objs=GameObject.FindGameObjectsWithTag("Turntable");

			//Application.LoadLevel("2");
		     if(model==0)
			{
				model=1;



			}
			else
			{
				model=0;
			}

			foreach(GameObject obj in objs)
			{
				if(obj.renderer!=null)
				{
				obj.renderer.enabled=model==1?false:true;
				}
			}
		}


	}

	GameObject GetRayObj()
	{
		GameObject obj = new GameObject ();


	}

	void RayChange()
	{
          
	}

	/// <summary>
	/// Items the move.
	/// </summary>
	/// <param name="direction">.</param>
	public void ItemMove(int direction)
	{
		   ChangeTexture (currentIndex,false);
			switch(direction)
			{
			case 0:
				currentIndex+=1;
			  
				break;
			case 1:
				currentIndex-=1;
				break;
			default:
				currentIndex+=1;
				break;
			}
		currentIndex=(currentIndex+itemCount)%itemCount;
		ChangeTexture (currentIndex,true);

			
			
	}

	void ChangeTexture(int index,bool selected)
	{
		int MiddleIndex = itemCount - index + 1;
		if (MiddleIndex == 6) {
			MiddleIndex=1;
		}

		string objname = "home/pCube" +MiddleIndex;
		GameObject obj = GameObject.Find (objname);
		
		if (obj != null) {
			string temp=selected?"_c":"";
			string textname="Home/ModuleTexture/pCube"+MiddleIndex+temp;
			Debug.Log(textname);
			Texture txt=(Texture)Resources.Load(textname);

			GameObject wall=GameObject.Find("home_wall/pCube25");
			if(txt!=null)
			{
				obj.renderer.material.mainTexture=txt;
				//wall.renderer.material.mainTexture=txt;
			}
			
		}
	}



	void Click()
	{
//		if(Input.GetMouseButtonDown(0))
//		{
//			if(Input.mousePosition.x<Screen.width/2.0f)
//			{
//				ItemMove(0);
//			}
//			else
//			{
//				ItemMove(1);
//			}
//		}
//		
				//手机触摸屏的代码
       if (Input.touchCount != 1 )
			return;
		Touch touch = Input.GetTouch (0);
		if (touch.phase == TouchPhase.Ended)
		{
			if(touch.position.x<Screen.width/2.0f)
			{
				ItemMove(0);
			}
			else
			{
				ItemMove(1);
			}
		}

	}


	void TestRay()
	{

		if (Input.GetKeyDown (KeyCode.A)) {

			Debug.Log ("you click the key a");
			Vector3 middlePoint=new Vector3(
				Screen.width/2,
				Screen.height/2,
				0);

			Ray ray = Camera.main.ScreenPointToRay (middlePoint);//从摄像机发出到点击坐标的射线
			RaycastHit hitInfo;
			if (Physics.Raycast (ray, out hitInfo)) {
				Debug.DrawLine (ray.origin, hitInfo.point);//划出射线，只有在scene视图中才能看到
				GameObject gameObj = hitInfo.collider.gameObject;
				Debug.Log ("click object name is " + gameObj.name);
			}
		}
	}

	/// <summary>
	/// 修改背景图
	/// </summary>
	void ChangeBackground()
	{
		//当选择时 
	}
}

public class ItemInfo
{
	public Vector3 position;
	public string  tip="";
}

public enum Applications
{

}
