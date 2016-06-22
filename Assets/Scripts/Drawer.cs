using UnityEngine;
using System.Collections;

public class Drawer : MonoBehaviour
{
	public GameObject pixel;
	LevelReader reader;

	public int levelNumber = 1;

	void Start ()
	{
		reader = new LevelReader (levelNumber);
		drawBlocksFromCSV ();
	}

	void drawBlocksFromCSV ()
	{
		int rowIdx = 0;
		int colIdx = 0;

		ArrayList rows = reader.read ();
		foreach (string row in rows) {

			ArrayList cols = new ArrayList (row.Split (','));
			foreach (string col in cols) {

				if (col != Commons.kIdEmpty && col != Commons.kIdStar && col != Commons.kIdEnd) {
					GameObject block = (GameObject)Instantiate (Resources.Load (col));

					if (col != "60" && col != "31" && col != "21" && col != "40" && col != "102" && col != "43") {
						block.AddComponent<BoxCollider2D> ();
					}

					block.transform.position = new Vector3 (colIdx - 10, (rowIdx * -1) + 5, -1);

					if (col == "102" || col == "43") {
						block.tag = Commons.kTagEnd;
					}
				}

				if (col == Commons.kIdStar || col == Commons.kIdEnd) {
					GameObject block = (GameObject)Instantiate (Resources.Load (col));
					block.AddComponent<BoxCollider2D> ().isTrigger = true;
					block.transform.position = new Vector3 (colIdx - 10, (rowIdx * -1) + 5, -1);
				}

				colIdx++;
			}

			colIdx = 0;
			rowIdx++;
		}
	}

}
