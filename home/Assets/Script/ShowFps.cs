using UnityEngine;
using System.Collections;

public class ShowFps : MonoBehaviour {

	private GUIText fpsText;			//显示的帧率
	private float lastInterval = 0.0f;	//最后更新FPS的时间
	private int frames = 0;				//上次更新FPS到现在的总帧数

	// Use this for initialization
	void Start () {
		frames = 0;
		lastInterval = Time.realtimeSinceStartup;
	}

	void OnDisable(){
		if (fpsText)
						DestroyImmediate (fpsText.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		++frames;
		float timeNow = Time.realtimeSinceStartup;

		//每隔1秒计算一次帧率
		if (timeNow > lastInterval + 1.0f) 
		{
			if(!fpsText)
			{
				GameObject gObject = new GameObject("FPS Display");
				gObject.AddComponent<GUIText>();
				gObject.hideFlags = HideFlags.HideAndDontSave;
				gObject.transform.position = new Vector3(0,0,0);
				fpsText = gObject.guiText;
				fpsText.pixelOffset = new Vector2(5, 55);
			}

			//计算帧率
			float fps = frames / (timeNow - lastInterval);
			
			//显示帧率
			fpsText.text = fps.ToString("f2") + "FPS";
			
			//数据重置
			frames = 0;
			lastInterval = timeNow;
		}
	}
}
