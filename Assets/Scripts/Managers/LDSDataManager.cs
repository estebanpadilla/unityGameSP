using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class LDSDataManager  {

	Dictionary<string, LDSData> ldsGameObjectsData = new Dictionary<string, LDSData>();	

	public LDSDataManager(){
		
	}
	
	public void loadLDSObjectsData() {

		TextAsset jsonData = Resources.Load(Path.Combine("Data", "spaceMiners")) as TextAsset;
     	string json = jsonData.ToString();
		
		LDSData[] objects;
		objects = LDSJsonHelper.FromJson<LDSData>(json);
		
		if ( objects != null ) {
			foreach(LDSData item in objects) {
				ldsGameObjectsData.Add(item.name, item);
			}
		}
	}
}
