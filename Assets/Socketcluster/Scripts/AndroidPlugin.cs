using UnityEngine;

public class AndroidPlugin : MonoBehaviour {

	public static AndroidJavaObject scSocket = null;
	public static AndroidJavaObject context = null;
	public bool autoStartService = true;

	public string userClientFilePath = null;

	public ConnectOptions options;

	[System.Serializable]
	public struct ConnectOptions
	{
		[System.Serializable]
		public struct Query {
			public string serviceKey;
		}
		public Query query;
		public string hostname;
		public int port;
		public string channelPrefix;
		public bool secure;

		public ConnectOptions(string h, int p, bool s, string ch = "", string key = ""){
			hostname = h;
			port = p;
			secure = s;
			channelPrefix = ch;
			query.serviceKey = key;
		}

		public override string ToString(){
			return JsonUtility.ToJson(this);
		}
	}

	void Start () {
		if (autoStartService) {
			StartService ();
		}
	}

	public void StartService () 
	{
		if (scSocket == null) {
			using (AndroidJavaClass activityClass = new AndroidJavaClass ("com.unity3d.player.UnityPlayer")) {
				context = activityClass.GetStatic<AndroidJavaObject> ("currentActivity");
			}

			using (AndroidJavaClass pluginClass = new AndroidJavaClass ("org.eu.chege.socketcluster.unityplugin.SocketclusterService")) {
				
				if (pluginClass != null) {
					scSocket = pluginClass.CallStatic<AndroidJavaObject> ("GetInstance");
					scSocket.Call("SetContext", context);
					if (userClientFilePath != "")
						scSocket.Call("SetPath", userClientFilePath);

					scSocket.Call("StartSocketService");

				}
			}
		}
	}

}
