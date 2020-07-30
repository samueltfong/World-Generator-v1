using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
    // Variables
    public static Map testMap = new Map(30);

    // Start is called before the first frame update
    void Start() {
        testMap = WorldGenerator.generateMap(testMap, 0, 60);
        WorldGenerator.getSurrTiles(testMap, 2, 2, 1);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
