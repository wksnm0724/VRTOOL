using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class zeemoteevent
{
    public enum EventType
    {
        JoyEvent,
        KeyDown,
        KeyUp,
        Voltage,
        Attach,
        Detach,
        Dummy = 0xffffe
    }

    public EventType _type = EventType.Dummy;
    public object[] _args = null;

    public zeemoteevent(EventType type, params object[] args)
    {
        _type = type;
        _args = args;
    }
}

public class zeemote : AndroidJavaProxy
{
    protected AndroidJavaObject z;

    public List<zeemoteevent> eventlist = new List<zeemoteevent>(); 

    public zeemote() : base("com.zeemote.bt.Zeemote$ZeemoteListener")
    {
        AndroidJavaClass zc = new AndroidJavaClass("com.zeemote.bt.Zeemote");
        z = zc.CallStatic<AndroidJavaObject>("Create",this);
    }

    public string[] GetPairedZeemotes()
    {
        if (z == null)
            return null;
        return z.Call<string[]>("GetPairedZeemotes");
    }

    public void Connect2(string devicestr)
    {
        z.Call("Connect2",devicestr);
    }

    public bool isBTEnabled()
    {
        return z.Call<bool>("IsBTEnabled");
    }

    public void EnableBT()
    {
        z.Call("EnableBT");
    }

    public void DisableBT()
    {
        z.Call("DisableBT");
    }

    public void Close()
    {
        z.Call("Close");
    }

    public bool IsListening()
    {
        return z.Call<bool>("IsListening");
    }

    public bool IsAlive()
    {
        return z.Call<bool>("IsAlive");
    }

    public void OnKeyUp(char key)
    {
        lock (eventlist)
        {
            eventlist.Add(new zeemoteevent(zeemoteevent.EventType.KeyUp, key));
        }      
    }

    public void OnKeyDown(char key)
    {
        lock (eventlist)
        {
            eventlist.Add(new zeemoteevent(zeemoteevent.EventType.KeyDown, key));
        }     
    }

    public void OnJoy(int x, int y)
    {
        lock (eventlist)
        {
            eventlist.Add(new zeemoteevent(zeemoteevent.EventType.JoyEvent, x, y));
        }
    }

    public bool OnError(string id, string what)
    {

        return false;
    }

    public void OnDeviceDetatched()
    {
        lock (eventlist)
        {
            eventlist.Add(new zeemoteevent(zeemoteevent.EventType.Detach));
        }
    }

    public void OnDeviceAttached()
    {
        lock (eventlist)
        {
            eventlist.Add(new zeemoteevent(zeemoteevent.EventType.Attach));
        }
    }

    public void OnVoltage(short voltage)
    {
        lock (eventlist)
        {
            eventlist.Add(new zeemoteevent(zeemoteevent.EventType.Voltage, voltage));
        }
    }
}
