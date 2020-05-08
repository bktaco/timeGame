using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static UIManager current;

	private Transform canvas;
	private Transform startButton;
	private Transform gameUI;

	private void Awake()
    {
		//If an UIManager exists and it is not this...
		if (current != null && current != this)
		{
			//...destroy this and exit. There can be only one UIManager
			Destroy(gameObject);
			return;
		}

		//This is the current UIManager and it should persist between scene loads
		current = this;
		DontDestroyOnLoad(gameObject);

		canvas = transform.Find("Canvas");
		startButton = canvas.transform.Find("PlayButton");
		gameUI = canvas.transform.Find("GameUI");
	}

	public static void HidePlayButton()
	{
		//If there is no current UIManager, exit
		if (current == null)
			return;

		current.startButton.gameObject.SetActive(false);
	}

}
