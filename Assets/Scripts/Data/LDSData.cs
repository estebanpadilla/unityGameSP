[System.Serializable]
public class LDSData
{
    /*Variable for regular structures.*/
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
    public int efficiency;
    public int deficiency;

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
    public string[] descriptions;
    public string[] pros;
    public string[] cons;
}

