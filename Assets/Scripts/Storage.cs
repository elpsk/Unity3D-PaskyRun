using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Storage
{
	public void SaveLevelOptions (LevelOptions options)
	{
		BinaryFormatter formatter = new BinaryFormatter ();
		FileStream saveFile = File.Create (Application.persistentDataPath + Commons.kFileStoreOptions);

		formatter.Serialize (saveFile, options);
		saveFile.Close ();
	}

	public LevelOptions LoadLevelOptions ()
	{
		if (File.Exists (Application.persistentDataPath + Commons.kFileStoreOptions)) {

			BinaryFormatter formatter = new BinaryFormatter ();
			FileStream saveFile = File.Open (Application.persistentDataPath + Commons.kFileStoreOptions, FileMode.Open);

			LevelOptions data = (LevelOptions)formatter.Deserialize (saveFile);

			saveFile.Close ();

			return data;
		}

		return null;
	}



	public void SaveData (int level)
	{
		BinaryFormatter formatter = new BinaryFormatter ();
		FileStream saveFile = File.Create (Application.persistentDataPath + Commons.kFileStoreData);

		Settings data = new Settings ();
		data.levelsCompleted = level;

		formatter.Serialize (saveFile, data);
		saveFile.Close ();
	}

	public int LoadData ()
	{
		if (File.Exists (Application.persistentDataPath + Commons.kFileStoreData)) {
			
			BinaryFormatter formatter = new BinaryFormatter ();
			FileStream saveFile = File.Open (Application.persistentDataPath + Commons.kFileStoreData, FileMode.Open);

			Settings data = (Settings)formatter.Deserialize (saveFile);

			saveFile.Close ();

			return data.levelsCompleted;
		}

		return 1;
	}

}
