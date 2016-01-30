using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TwitchDemo : MonoBehaviour {

	private TwitchIRC IRC;
	public Text txt;
	int X;

	void Start()
    {
        IRC = FindObjectOfType<TwitchIRC>();
        //IRC.SendCommand("CAP REQ :twitch.tv/tags"); //register for additional data such as emote-ids, name color etc.
        IRC.messageRecievedEvent.AddListener(OnChatMsgRecieved);
    }

	void OnChatMsgRecieved(string msg)
    {
        //parse from buffer.
        int msgIndex = msg.IndexOf("PRIVMSG #");
        string msgString = msg.Substring(msgIndex + IRC.channelName.Length + 11);
        string user = msg.Substring(1, msg.IndexOf('!') - 1);

        Debug.Log(msgString);

        if(msgString == "vote")
        {
        	X++;
        }

    }

    void Update()
    {
    	txt.text = ""+X;
    }


}
