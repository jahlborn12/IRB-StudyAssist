using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;

public class MainMenu : MonoBehaviour {

	public bool isCam = false;

	private static int num = 0;
	public Sprite[] img;
	public Image pane;

	public static bool mute = false;
	public Camera music;

	void Start()
	{	
	}
	void Update () 
	{
		if(isCam)
		{
			transform.Rotate(0,Time.deltaTime*5,0);
		}
	}
	public void ClickStart()
	{
		Application.LoadLevel ("Game");
	}
	public void ClickMenu()
	{
		Application.LoadLevel ("MainMenu");
	}
	public void ClickHow()
	{
		Application.LoadLevel ("Howto");
		num = 0;
	}

	public void ClickNext()
	{
		if(num < 7)
		{
			num++;
			pane.sprite = img [num];
		}
		else
		{
			num = 0;
			Application.LoadLevel ("MainMenu");
		}
	}

	public void ClickBack()
	{
		if(num > 0)
		{
			num--;
			pane.sprite = img [num];
		}
		else
		{
			num = 0;
			Application.LoadLevel ("MainMenu");
		}
	}
	public void clickMute()
	{
		music.GetComponent<AudioSource>().mute = !music.GetComponent<AudioSource>().mute;
		mute = !mute;
	}
}