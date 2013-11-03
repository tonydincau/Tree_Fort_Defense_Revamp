using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	void Start ()
	{
	
	}
	
	void Update ()
	{
		//Escape on Android is the back button
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();	
	}
	
	public void OnClickStart()
	{
		//Load Level_001
		Application.LoadLevel(1);
	}
}