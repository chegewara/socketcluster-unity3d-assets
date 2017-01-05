using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCExample : MonoBehaviour {
	AndroidJavaObject scSocket;

	public InputField channelInput;
	public InputField messageInput;
	public Text connectedStatus;
	public Text randomEvent;
	public Text channel;
	public Text message;

	public class Message
	{
		public string data;
		public string channel;
	}

	public class EventMsg
	{
		public string data;
		public string eventName;
	}

	public void Publish () {
		if (channelInput.text != null && messageInput.text != null) {
			scSocket.Call("Publish", channelInput.text, messageInput.text);
		}
	}

	public void UnregisterEvent () {
		scSocket.Call("UnregisterEvent", "rand");
	}

	public void RegisterEvent () {
		scSocket.Call("RegisterEvent", "rand");
	}

	public void Subscribe () {
		scSocket.Call("Subscribe", channelInput.text);
	}

	public void Unsubscribe () {
		scSocket.Call("Unsubscribe", channelInput.text);
	}

	void Update () {
		if (scSocket == null) {
			scSocket = AndroidPlugin.scSocket;
		}
	}


	// Broadcast message receivers

	public void OnReady (){
		connectedStatus.color = Color.blue;
		connectedStatus.text = "Ready";
		Connect ();
	}

	public void OnEvent (string data) {
		EventMsg msg = JsonUtility.FromJson<EventMsg> (data);
		if (msg.eventName == "rand") 
			randomEvent.text = msg.data;
	}

	public void OnMessage (string data) {
		Message msg = JsonUtility.FromJson<Message> (data);
		channel.text = msg.channel;
		message.text = msg.data;
	}

	public void OnConnect () {
		connectedStatus.color = Color.green;
		connectedStatus.text = "Connected";
		AndroidPlugin.scSocket.Call ("Subscribe", "sample");
	}

	public void OnDisconnect () {
		connectedStatus.color = Color.red;
		connectedStatus.text = "Disconnected";
	}

	public void Connect () {
		AndroidPlugin.scSocket.Call("Connect", GetComponent<AndroidPlugin>().options.ToString() );
	}

	public void Disconnect(){
		AndroidPlugin.scSocket.Call("Disconnect");
	}

}
