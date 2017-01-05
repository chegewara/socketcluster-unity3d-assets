
public interface ISocketclusterCallbacks  {
	void OnReady(string data);
	void OnConnect(string data);
	void OnDisconnect(string data);
	void OnEvent(string data);
	void OnSubscribe(string data);
	void OnUnsubscribe(string data);
	void OnMessage(string data);
	void OnAuthenticate(string data);
	void OnDeauthenticate(string data);
	void OnError(string data);

	void OnAllMessages (string data);
}
