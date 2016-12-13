[System.Serializable]
public class GameObjectData
{
    /*Variable for regular structures.*/
    public int identifier;
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
    public int energyUsage;
    public int creationTime;

    /*Variables use on structes that do some type of work.*/
    public int workTime;
    public int workRate;
    public float efficiency;
    public float deficiency;

    /* Variable use on structres that create or produce something like, 
	* solarStation would use to represent the energy produce and the 
	* miner would use to represent the totalMined.*/
    public int productionQty;

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
    public int[] ins;
    public int[] outs;

    public string[] descriptions;
    public string[] pros;
    public string[] cons;



    public GameObjectData Clone()
    {
        GameObjectData gameObjectData = new GameObjectData();
        gameObjectData.identifier = this.identifier;
        gameObjectData.name = this.name;
        gameObjectData.price = this.price;
        gameObjectData.priceLost = this.priceLost;
        gameObjectData.health = this.health;
        gameObjectData.damage = this.damage;
        gameObjectData.armor = this.armor;
        gameObjectData.currentLevel = this.currentLevel;
        gameObjectData.upgradeId = this.upgradeId;
        gameObjectData.upgradePrice = this.upgradePrice;
        gameObjectData.range = this.range;
        gameObjectData.energyUsage = this.energyUsage;
        gameObjectData.creationTime = this.creationTime;
        gameObjectData.workTime = this.workTime;
        gameObjectData.workRate = this.workRate;
        gameObjectData.efficiency = this.efficiency;
        gameObjectData.deficiency = this.deficiency;
        gameObjectData.productionQty = this.productionQty;
        gameObjectData.storageCty = this.storageCty;
        gameObjectData.repairCost = this.repairCost;
        gameObjectData.repairEnergyCost = this.repairEnergyCost;
        gameObjectData.repairMaterialCost = this.repairMaterialCost;
        gameObjectData.repairTime = this.repairTime;
        gameObjectData.repairDamageRatio = this.repairDamageRatio;
        gameObjectData.ins = this.ins;
        gameObjectData.outs = this.outs;
        gameObjectData.descriptions = this.descriptions;
        gameObjectData.pros = this.pros;
        gameObjectData.cons = this.cons;

        return gameObjectData;
    }
}


