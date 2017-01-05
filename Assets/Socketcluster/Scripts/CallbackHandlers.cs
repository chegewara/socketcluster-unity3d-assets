using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CallbackHandlers : MonoBehaviour, ISocketclusterCallbacks {

	public void OnEvent (string data)
	{
		BroadcastMessage ("OnEvent", data);
	}

	public void OnReady (string data)
	{
		BroadcastMessage ("OnReady");
	}

	public void OnConnect (string data)
	{
		BroadcastMessage ("OnConnect");
	}

	public void OnAllMessages(string data){
		throw new System.NotImplementedException ();
	}

	public void OnSubscribe (string data)
	{
		throw new System.NotImplementedException ();
	}

	public void OnUnsubscribe (string data)
	{
		throw new System.NotImplementedException ();
	}

	public void OnMessage (string data)
	{
		BroadcastMessage ("OnMessage");
	}

	public void OnAuthenticate (string data)
	{
		throw new System.NotImplementedException ();
	}

	public void OnDeauthenticate (string data)
	{
		throw new System.NotImplementedException ();
	}

	public void OnError (string data)
	{
		throw new System.NotImplementedException ();
	}

	public void OnDisconnect (string data)
	{
		BroadcastMessage ("OnDisconnect");
	}

}
