using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;


[Serializable]
public class LevelOptions
{
	public int score;
}

public class LevelConfig : MonoBehaviour
{

	public Text level;
	public Text score;
	public Text time;

	Storage store = new Storage ();
	LevelOptions opts;

	void Start ()
	{
		refreshData ();
	}

	void Update ()
	{
		refreshData ();
	}

	public string ConvertToTime (double timeSeconds)
	{
		int mySeconds = System.Convert.ToInt32 (timeSeconds);

		int myHours = mySeconds / 3600;
		mySeconds %= 3600;

		int myMinutes = mySeconds / 60;
		mySeconds %= 60;

		string mySec = mySeconds.ToString (),
		myMin = myMinutes.ToString (),
		myHou = myHours.ToString ();

		if (myHours < 10) {
			myHou = myHou.Insert (0, "0");
		}
		if (myMinutes < 10) {
			myMin = myMin.Insert (0, "0");
		}
		if (mySeconds < 10) {
			mySec = mySec.Insert (0, "0");
		}

		return myMin + ":" + mySec;
	}

	void refreshData ()
	{
		opts = store.LoadLevelOptions ();
		if (opts == null) {
			store.SaveLevelOptions (new LevelOptions ());
			opts = store.LoadLevelOptions ();
		}

		level.text = "Level : 1";
		score.text = "Score : " + opts.score;
		time.text = "Time : " + ConvertToTime (Time.timeSinceLevelLoad);
	}
		
}
