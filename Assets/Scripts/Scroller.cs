using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scroller : MonoBehaviour
{

	public float speed = 0.12f;
	public Rigidbody2D player;

	private float playerOffsetValue = -9.62f;

	void Start ()
	{
		if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer) {
			speed = 0.2f;
		}
	}

	void Update ()
	{
		if (SceneManager.GetActiveScene ().name == Commons.kSceneMenu) {
			Vector2 offset = new Vector2 (Time.time * speed, 0);
			GetComponent<Renderer> ().material.mainTextureOffset = offset;
			return;
		}

		playerOffsetValue = playerOffsetValue + speed;

		Vector2 playerOffset = new Vector2 (playerOffsetValue, player.transform.position.y);
		player.transform.position = playerOffset;

		float skyOffsetValue = playerOffsetValue;
		skyOffsetValue += 2;
		Vector2 skyPosition = new Vector2 (skyOffsetValue, 0);
		GetComponent<Renderer> ().transform.position = skyPosition;
	}

}
