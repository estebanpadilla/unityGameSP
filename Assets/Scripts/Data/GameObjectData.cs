[System.Serializable]
public enum GameObjectType
{
    None,
    Stronghold,
    SolarStation,
    EnergyStorage,
    Relay,
    Miner,
    RepairStation,
    MaterialStorage,
    Asteroid
}

[System.Serializable]
public class GameObjectData
{
    /*Variable for regular structures.*/
    public GameObjectType gameObjectType;
    public GameObjectType identifier;
    public string name;
    public int price;
    public float priceLost;
    public int health;
    public int damage;
    public int armor;
    public int currentLevel;
    public string upgradeId;
    public int upgradePrice;
    public int range;
    public int energyRequire;
    public int creationTime;

    /*Variables use on structes that do some type of work.*/
    public float workTime;
    public int workRate;
    public float efficiency;
    public float deficiency;

    /* Variable use on structres that create or produce something like, 
	* solarStation would use to represent the energy produce and the 
	* miner would use to represent the totalMined.*/
    public float productionQty;

    /* Variable use on structures that need to store any type of value, 
	* like a battery, stronghold, asteroid or in repairStation to tell 
	* the amout of drome it can store */
    public int storageCty;

    /*Variable use on structes that need to be repair at some point.*/
    public int repairCost;
    public int repairEnergyCost;
    public int repairMaterialCost;
    public int repairTime;
    public int repairDamageRatio;

    //Connections
    public GameObjectType[] ins;
    public GameObjectType[] outs;

    public string[] descriptions;
    public string[] pros;
    public string[] cons;



    public GameObjectData Clone()
    {
        GameObjectData data = new GameObjectData();
        data.gameObjectType = this.gameObjectType;
        data.identifier = this.identifier;
        data.name = this.name;
        data.price = this.price;
        data.priceLost = this.priceLost;
        data.health = this.health;
        data.damage = this.damage;
        data.armor = this.armor;
        data.currentLevel = this.currentLevel;
        data.upgradeId = this.upgradeId;
        data.upgradePrice = this.upgradePrice;
        data.range = this.range;
        data.energyRequire = this.energyRequire;
        data.creationTime = this.creationTime;
        data.workTime = this.workTime;
        data.workRate = this.workRate;
        data.efficiency = this.efficiency;
        data.deficiency = this.deficiency;
        data.productionQty = this.productionQty;
        data.storageCty = this.storageCty;
        data.repairCost = this.repairCost;
        data.repairEnergyCost = this.repairEnergyCost;
        data.repairMaterialCost = this.repairMaterialCost;
        data.repairTime = this.repairTime;
        data.repairDamageRatio = this.repairDamageRatio;
        data.ins = this.ins;
        data.outs = this.outs;
        data.descriptions = this.descriptions;
        data.pros = this.pros;
        data.cons = this.cons;

        return data;
    }
}


