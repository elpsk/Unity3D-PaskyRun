using UnityEngine;
using System.Collections;
using System.IO;

public class LevelReader
{
	FileInfo theSourceFile = null;
	StreamReader reader = null;
	string text = null;
	ArrayList list = null;

	public LevelReader (int num)
	{
		TextAsset csvfile = Resources.Load (Commons.kLevelPrefix + num) as TextAsset;

		list = new ArrayList ();

		string[] linesFromfile = csvfile.text.Split ('\n');
		for (uint i = 0; i < linesFromfile.Length; i++) {
			list.Add (linesFromfile [i]);
		}
	}

	public ArrayList read ()
	{
		return list;
	}
		
}
