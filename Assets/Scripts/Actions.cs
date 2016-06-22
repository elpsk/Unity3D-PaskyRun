using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Actions : MonoBehaviour
{

	public float fadeSpeed = 1.5f;

	// Use this for initialization
	void Start ()
	{
		if (SceneManager.GetActiveScene ().name == "Splash") {
			StartCoroutine (DismissSplash ());
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void LoadLevel (string name)
	{
		SceneManager.LoadScene (name);
	}

	IEnumerator DismissSplash ()
	{
		yield return new WaitForSeconds (1.2f);
		LoadLevel (Commons.kSceneMenu);
	}

}
