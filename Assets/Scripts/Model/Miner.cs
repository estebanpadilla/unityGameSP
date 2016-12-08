using UnityEngine;
class Miner : Structure {
    
    void Start() {
        this.range = Instantiate(structureRange, transform.position, Quaternion.identity);
        range.transform.localScale += new Vector3(data.range, data.range, 0);
        range.transform.parent = gameObject.transform;
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray; 
    }
}