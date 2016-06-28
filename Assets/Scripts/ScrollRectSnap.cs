using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollRectSnap : MonoBehaviour
{

	public RectTransform panel;
	public Button[] btns;
	public RectTransform center;

	private float[] distance;
	private float[] distReposition;

	private int btnDistance;
	private int minBtnNum;
	private int btnLen;
 
	// Use this for initialization
	void Start ()
	{
	
		btnLen = btns.Length;
		distance = new float[btnLen];
		distReposition = new float[btnLen];

		btnDistance = (int)Mathf.Abs (
			btns [1].GetComponent<RectTransform> ().anchoredPosition.y -
			btns [0].GetComponent<RectTransform> ().anchoredPosition.y);
	}
	
	// Update is called once per frame
	void Update ()
	{
		int i = 0;
		for (; i < btns.Length; ++i) {

			distReposition [i] = 
				center.GetComponent<RectTransform> ().position.y +
			btns [i].GetComponent<RectTransform> ().position.y;

			distance [i] = Mathf.Abs (distReposition [i]);


			if (distReposition [i] > 900) {
				float curX = btns [i].GetComponent<RectTransform> ().anchoredPosition.x;
				float curY = btns [i].GetComponent<RectTransform> ().anchoredPosition.y;

				Vector2 newAnchoredPos = new Vector2 (curX, curY - (btnLen * btnDistance));
				btns [i].GetComponent<RectTransform> ().anchoredPosition = newAnchoredPos;
			}

			if (distReposition [i] < 0) {
				float curX = btns [i].GetComponent<RectTransform> ().anchoredPosition.x;
				float curY = btns [i].GetComponent<RectTransform> ().anchoredPosition.y;

				Vector2 newAnchoredPos = new Vector2 (curX, curY + (btnLen * btnDistance));
				btns [i].GetComponent<RectTransform> ().anchoredPosition = newAnchoredPos;
			}

		}

		float minDistance = Mathf.Min (distance);

		i = 0;
		for (; i < btns.Length; ++i) {
			if (minDistance == distance [i]) {
				minBtnNum = i;
			}
		}

	}

	void LerpToBtn (float position)
	{
		float newX = Mathf.Lerp (panel.anchoredPosition.x, position, Time.deltaTime * 5f);
		Vector2 newPosition = new Vector2 (newX, panel.anchoredPosition.y);
		panel.anchoredPosition = newPosition;
	}
}

