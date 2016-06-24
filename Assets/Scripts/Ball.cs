using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
	public float speed = 100;

	public GameObject panel;
	public GameObject quad;

	public Image star1;
	public Image star2;
	public Image star3;

	public Text panelText;
	public Button panelButton;
	public Text panelButtonText;

	public AudioSource starSound;
	public AudioSource bgSound;

	LevelOptions opts;
	int points = 0;

	void Start ()
	{		
		GetComponent<Rigidbody2D> ().transform.position = new Vector2 (-9, 2);
		panel.transform.localScale = new Vector3 (0, 0, 0);

		bgSound.Play ();
	}

	void Update ()
	{
		if (Commons.kDEBUG) {
			if (Input.GetKeyDown ("space")) {
				GetComponent<Rigidbody2D> ().gravityScale *= -1;
				GetComponent<SpriteRenderer> ().flipY = !GetComponent<SpriteRenderer> ().flipY;
			}
		}
			
		checkForTouches ();
		checkForEnd ();
	}

	void checkForTouches ()
	{
		for (int i = 0; i < Input.touchCount; ++i) {
			if (Input.GetTouch (i).phase == TouchPhase.Began) {
				GetComponent<Rigidbody2D> ().gravityScale *= -1;
				GetComponent<SpriteRenderer> ().flipY = !GetComponent<SpriteRenderer> ().flipY;
				break;
			}
		}
	}

	void checkForEnd ()
	{
		if (GetComponent<Rigidbody2D> ().transform.position.y > Commons.kLevelBound ||
		    GetComponent<Rigidbody2D> ().transform.position.y < -Commons.kLevelBound) {
			levelFail ();
		}
	}

	void showPanel ()
	{
		star1.enabled = opts.score > 5;
		star2.enabled = opts.score > 10;
		star3.enabled = opts.score > 15;

		panel.transform.localScale = new Vector3 (1, 1, 1);
		quad.GetComponent<Scroller> ().enabled = false;
	}

	void levelPass ()
	{
		panelText.text = Commons.kStringLevelComplete;
		panelButtonText.text = Commons.kStringGoToNextText;

		showPanel ();
		saveProgress ();
	}

	void levelFail ()
	{
		star1.enabled = false;
		star2.enabled = false;
		star3.enabled = false;

		panelText.text = Commons.kStringGameOver;
		panelButtonText.text = Commons.kStringGoToMenuText;

		panelButton.onClick.RemoveAllListeners ();
		panelButton.onClick.AddListener (() => {
			SceneManager.LoadScene (Commons.kSceneMenu);
		});

		showPanel ();
	}

	void saveProgress ()
	{
		Storage store = new Storage ();
		int level = store.LoadData ();

		if (level > 3)
			return;
		
		if (level == 1) {
			store.SaveData (2);
		}
		if (level == 2) {
			store.SaveData (3);
		}
		if (level == 3) {
			store.SaveData (4);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag (Commons.kTagStar)) {
			other.gameObject.SetActive (false);

			starSound.Play ();

			Storage levelStore = new Storage ();
			opts = levelStore.LoadLevelOptions ();
			opts.score = ++points;
			levelStore.SaveLevelOptions (opts);
		}

		if (other.gameObject.CompareTag (Commons.kTagEnd)) {
			levelPass ();
		}
	}

}
