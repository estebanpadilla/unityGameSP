using UnityEngine;

public class LDSGameManager : MonoBehaviour  {

	private LDSDataManager ldsDataManager;
	public GameObject uiManager;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake() {
		this.ldsDataManager = new LDSDataManager();
		this.ldsDataManager.loadLDSObjectsData();
	}

	 /// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start() {
		Debug.Log("LDSGameManager Star()");
		Instantiate(uiManager, Vector3.zero, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addSolarStation() {

	}

	public void addBattery() {

	}

	public void addRelay() {

	}

	public void addRepaitStation(){

	}

	public void addMiner() {
		Debug.Log("Add Miner");
	}
}
