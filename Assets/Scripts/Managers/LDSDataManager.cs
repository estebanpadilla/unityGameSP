using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class LDSDataManager  {

	Dictionary<string, LDSData> gameObjectsData = new Dictionary<string, LDSData>();	

	public LDSDataManager(){
		
	}
	
	public void loadLDSObjectsData() {

		TextAsset jsonData = Resources.Load(Path.Combine("Data", "spaceMiners")) as TextAsset;
     	string json = jsonData.ToString();
		
		LDSData[] objects;
		objects = LDSJsonHelper.FromJson<LDSData>(json);
		
		if ( objects != null ) {
			foreach(LDSData item in objects) {
				gameObjectsData.Add(item.name, item);
			}
		}
	}

	public LDSData findGameObjectData(string key) {
		return gameObjectsData[key];
	}

}
