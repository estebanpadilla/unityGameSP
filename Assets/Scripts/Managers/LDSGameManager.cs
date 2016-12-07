using UnityEngine;

public class LDSGameManager : MonoBehaviour  {

	//Game objects
	public GameObject uiManager;
	public GameObject stronghold;
	public GameObject solarStation;
	public GameObject battery;
	public GameObject relay;
	public GameObject repairStation;
	public GameObject repairDrome;
	public GameObject miner;
	public GameObject asteroid;

	private LDSDataManager dataManager;
	public Player player;


	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake() {
		this.dataManager = new LDSDataManager();
		this.dataManager.loadLDSObjectsData();
		this.player = new Player();
	}

	 /// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start() {
		Debug.Log("LDSGameManager Star()");
		Instantiate(uiManager, Vector3.zero, Quaternion.identity);
		LDSData data = dataManager.findGameObjectData("stronghold");
		GameObject sg0 = Instantiate(stronghold, Vector3.zero, Quaternion.identity);
		Stronghold strongholdSc = sg0.GetComponent<Stronghold>();
		strongholdSc.Data = data;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addSolarStation() {
		LDSData data = dataManager.findGameObjectData("solarStation1");
		if (player.hasEnoughCash( data.price )) {
			GameObject go = Instantiate(solarStation, Vector3.zero, Quaternion.identity);
			SolarStation script = go.GetComponent<SolarStation>();
			script.Data = data;
		}
	}

	public void addBattery() {
		LDSData data = dataManager.findGameObjectData("battery1");
		if ( player.hasEnoughCash(data.price )) {
			GameObject go = Instantiate(battery, Vector3.zero, Quaternion.identity);
			Battery script = go.GetComponent<Battery>();
			script.Data = data;
		}
	}

	public void addRelay() {
		LDSData data = dataManager.findGameObjectData("relay1");
		if (player.hasEnoughCash(data.price)) {
			GameObject go = Instantiate(relay, Vector3.zero, Quaternion.identity);
			Relay script = go.GetComponent<Relay>();
			script.Data = data;
		}
	}

	public void addRepairStation(){
		LDSData data = dataManager.findGameObjectData("repairStation1");
		if ( player.hasEnoughCash(data.price )) {
			GameObject go = Instantiate(repairStation, Vector3.zero, Quaternion.identity);
			RepairStation script = go.GetComponent<RepairStation>();
			script.Data = data;
		}
	}

	public void addMiner() {
		LDSData data = dataManager.findGameObjectData("miner1");
		if ( player.hasEnoughCash(data.price )) {
			GameObject go = Instantiate(miner, Vector3.zero, Quaternion.identity);
			Miner script = go.GetComponent<Miner>();
			script.Data = data;
		}
	}
}
