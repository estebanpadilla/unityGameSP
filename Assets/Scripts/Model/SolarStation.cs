using UnityEngine;
class SolarStation : Structure {

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start() {
        this.range = Instantiate(structureRange, transform.position, Quaternion.identity);
        range.transform.localScale += new Vector3(data.range, data.range, 0);
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
  
    }


}