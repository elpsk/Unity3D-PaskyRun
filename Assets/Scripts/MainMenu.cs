using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

	public Button btnLevel1;
	public Button btnLevel2;
	public Button btnLevel3;

	void Start ()
	{
		int levelsPassed = 1;
		Storage store = new Storage ();
		levelsPassed = store.LoadData ();

		btnLevel2.interactable = levelsPassed >= 2;
		btnLevel3.interactable = levelsPassed >= 3;
	}

	void Update ()
	{
	
	}

}
