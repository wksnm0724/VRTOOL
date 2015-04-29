using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ZeemoteManager : MonoBehaviour 
{
	// Use this for initialization
    private static zeemote z = null;

    void Awake()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            Debug.LogError("Error!! ZeemoteManager ONLY run on Android platform!! " +
                "Your current platform is " + Application.platform.ToString() + ", " +
                "system will close it!!");
            gameObject.SetActive(false);
            return;
        }

        if (z == null)
            z = new zeemote();

        if (z == null)
        {
            Debug.LogError("Error!! ZeemoteManager Init faild!!" +
                "system will close it!!");
            gameObject.SetActive(false);
        }

        DontDestroyOnLoad(this);
    }

	void Start () 
    {
        if(!z.isBTEnabled())
            z.EnableBT();
        ZeemoteInput.SetZeemoteManager(GetComponent<ZeemoteManager>());
	}

    void OnGUI()
    {
        if (!IsListening)
        {
            var device_list = z.GetPairedZeemotes();
            z.Connect2(device_list[0]);
        }
        /*
        if (!IsListening)
        {
            var device_list = z.GetPairedZeemotes();
            for (int i = 0; i < device_list.Length; i++)
            {
                if (GUILayout.Button(" 游戏设备： " + device_list[i],
                    new[] { GUILayout.Height(200), GUILayout.Width(800) }))
                {
                    z.Connect2(device_list[i]);
                }
            }

            GUILayout.Label("Voltage=" + ZeemoteInput.GetVoltage() + "V");
        }
         * */
    }

    string[] GetPairedZeemotes()
    {
        return z.GetPairedZeemotes();
    }
    
    public zeemoteevent GetLastEvent()
    {
        lock (z.eventlist)
        {
            if (z.eventlist.Count > 0)
            {
                var rel = z.eventlist[0];
                z.eventlist.RemoveAt(0);
                return rel;
            }
            return null;
        }
    }

	void Update ()
    {
        ZeemoteInput.Update();
	}

    public void Close()
    {
        z.Close();
    }

    public void EnableBT()
    {
        z.EnableBT();
    }

    public void DisableBT()
    {
        z.DisableBT();
    }

    public bool IsBTEnabled
    {
        get { return z.isBTEnabled(); }
    }

    public bool IsListening
    {
        get { return z.IsListening(); }
    }

    public bool IsAlive
    {
        get { return z.IsAlive(); }
    }
}

public class ZeemoteInput
{
    public static void SetZeemoteManager(ZeemoteManager _manager)
    {
        manager = _manager;
    }

    public static void SetOnAttachEvent(EventCallBack callback)
    {
        OnAttach = callback;
    }

    public static void SetOnDetachEvent(EventCallBack callback)
    {
        OnDetach = callback;
    }

    public static bool GetKeyDown(KeyCode zkc)
    {
        Update();
        return keydownlist.Contains(zkc);
    }

    public static bool GetKeyUp(KeyCode zkc)
    {
        Update();
        return keyuplist.Contains(zkc);
    }

    public static bool GetKey(KeyCode zkc)
    {
        Update();
        return keylist.Contains(zkc);
    }

    public static Vector2 GetJoyV2()
    {
        Update();
        return joyPos;
    }

    public static Vector3 GetJoyV3()
    {
        Update();
        Vector3 v3 = new Vector3(joyPos.x, 0, joyPos.y);
        return v3;
    }

    public static float GetVoltage()
    {
        return voltage;
    }

    public static void Update()
    {
        if (manager == null)
            return;
        if (lastfamecount == Time.frameCount)
            return;

        keydownlist.Clear();
        keyuplist.Clear();

        zeemoteevent ev = manager.GetLastEvent();

        while (ev != null)
        {
            switch (ev._type)
            {
                case zeemoteevent.EventType.JoyEvent:
                    {
                        int x = (int)ev._args[0], y = (int)ev._args[1];
                        joyPos = new Vector2((x < 0 ? x / 128f : x / 127f), -(y < 0 ? y / 128f : y / 127f));
						if(joyPos.x==-1){
							BaoFengZeemoteManager.Instance.ZeemoteDownBtn("LEFT_BUTTON");
						}else if(joyPos.x==1){
							BaoFengZeemoteManager.Instance.ZeemoteDownBtn("RIGHT_BUTTON");
						}else if(joyPos.y==1){
							BaoFengZeemoteManager.Instance.ZeemoteDownBtn("UP_BUTTON");

						}else if(joyPos.y==-1){
							BaoFengZeemoteManager.Instance.ZeemoteDownBtn("DOWN_BUTTON");
					
						}
						
						if(joyPos.x==0 && joyPos.y==0){
							BaoFengZeemoteManager.Instance.ZeemoteDownBtn("CENTER_POSITION");
						}

                        KeyArrow(KeyCode.LeftArrow, (joyPos.x == -1));
                        KeyArrow(KeyCode.RightArrow, (joyPos.x == 1));
                        KeyArrow(KeyCode.DownArrow, (joyPos.y == -1));
                        KeyArrow(KeyCode.UpArrow, (joyPos.y == 1));
                    }
                    break;
                case zeemoteevent.EventType.KeyDown:
                    {
                        KeyCode k = KeyCode.A + (((char)ev._args[0]) - 'A');
						switch(k+""){
							case "D":
								BaoFengZeemoteManager.Instance.ZeemoteDownBtn("D");
								break;
							case "A":
								BaoFengZeemoteManager.Instance.ZeemoteDownBtn("A");
								break;
							case "B":
								BaoFengZeemoteManager.Instance.ZeemoteDownBtn("B");
								break;
							case "C":
								BaoFengZeemoteManager.Instance.ZeemoteDownBtn("C");
								break;
						}
						
                        if (!keydownlist.Contains(k))
                            keydownlist.Add(k);
                    }
                    break;
                case zeemoteevent.EventType.KeyUp:
                    {
                        KeyCode k = KeyCode.A + (((char)ev._args[0]) - 'A');
                        if (!keyuplist.Contains(k))
                            keyuplist.Add(k);
                    }
                    break;
                case zeemoteevent.EventType.Voltage:
                    voltage = (short)ev._args[0] / 1000.0f;
                    break;
                case zeemoteevent.EventType.Attach:
					BaoFengZeemoteManager.Instance.ZeemoteStatus("CONNECT_SUCCED");
                    if (OnAttach != null)
                        OnAttach();
                    break;
                case zeemoteevent.EventType.Detach:
					BaoFengZeemoteManager.Instance.ZeemoteStatus("CONNECT_FAILED");
                    if (OnDetach != null)
                        OnDetach();
                    break;
            }

            ev = manager.GetLastEvent();
        }

        foreach (var k in keydownlist)
            if (!keylist.Contains(k))
                keylist.Add(k);

        foreach (var k in keyuplist)
            keylist.Remove(k);

        /*
        {
            string log = "";

            log += "\r\nkeydownlist=";
            foreach (var k in keydownlist)
                log += k.ToString() + ",";

            log += "\r\nkeyuplist=";
            foreach (var k in keyuplist)
                log += k.ToString() + ",";

            log += "\r\nkeylist=";
            foreach (var k in keylist)
                log += k.ToString() + ",";

            Debug.Log(log);
        }
        */

        lastfamecount = Time.frameCount;
    }

    public static void KeyArrow(KeyCode zkc, bool yesno)
    {
        if (yesno)
        {
            if (!keylist.Contains(zkc) && !keydownlist.Contains(zkc))
                keydownlist.Add(zkc);
        }
        else
        {
            if (keylist.Contains(zkc) && !keyuplist.Contains(zkc))
                keyuplist.Add(zkc);
        }
    }

    static ZeemoteManager manager = null;

    static List<KeyCode> keydownlist = new List<KeyCode>();
    static List<KeyCode> keyuplist = new List<KeyCode>();
    static List<KeyCode> keylist = new List<KeyCode>();
    public static Vector2 joyPos;
    static float voltage;
    static int lastfamecount = 0;

    public delegate void EventCallBack();
    static EventCallBack OnAttach = null;
    static EventCallBack OnDetach = null;
}

