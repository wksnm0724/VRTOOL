using UnityEngine;
using System.Collections;

public class InitData : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// 初始化5个系统模块
	/// </summary>
	void InitModules()
	{
		Data.allModeule.Clear ();

		//媒体中心
		Module mediaCenter = new Module ();
		mediaCenter.Id = 1;
		mediaCenter.No = "mediaCenter";
		mediaCenter.name = "媒体中心";
		mediaCenter.Description = "看以看到本地的视频等等";
		mediaCenter.ApkName = "com.picovr.mediacenter";
		Data.allModeule.Add (mediaCenter);


		//在线影院
		Module movie = new Module ();
		movie.Id = 2;
		movie.No = "movie";
		movie.name = "在线影院";
		movie.Description = "可以看到在线影院的信息";
		movie.ApkName = "com.picovr.movie";
		Data.allModeule.Add (movie);


		//设置
		Module settings = new Module ();
		settings.Id = 3;
		settings.No = "settings";
		settings.name = "设置";
		settings.Description = "对系统的配置进行设置";
		settings.ApkName = "com.picovr.settings";
		Data.allModeule.Add (settings);

		//应用程序
		Module application = new Module ();
		application.Id = 4;
		application.No = "application";
		application.name = "应用程序";
		application.Description = "查看系统的应用程序";
		application.ApkName = "com.picovr.application";
		Data.allModeule.Add (application);

		//游戏纵横
		Module game = new Module ();
		game.Id = 5;
		game.No = "game";
		game.name = "游戏纵横";
		game.Description = "查看游戏的信息";
		game.ApkName = "com.picovr.game";
		Data.allModeule.Add (game);
	}
}
