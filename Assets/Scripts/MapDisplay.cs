using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapDisplay : MonoBehaviour {
    // Variables
    public Text textMapDisplay;

    void Awake() {
        textMapDisplay = this.GetComponent<Text>();
    }

    private void Update() {
        if(Input.GetMouseButton(0)) {
            textMapDisplay.text = mapToString(test.testMap);
        }
        if(Input.GetKeyUp(KeyCode.B)) {
            test.testMap = WorldGenerator.generateMap(test.testMap, 0, 55);
            textMapDisplay.text = mapToString(test.testMap);
        }
        if(Input.GetKeyUp(KeyCode.Space)) {
            test.testMap = WorldGenerator.smoothMap(test.testMap, 1);
            textMapDisplay.text = mapToString(test.testMap);
        }
        if (Input.GetKeyUp(KeyCode.N)) {
            test.testMap = WorldGenerator.generateMap(test.testMap, 0, 55);
            test.testMap = WorldGenerator.smoothMap(test.testMap, 1);
            textMapDisplay.text = mapToString(test.testMap);
        }
        if (Input.GetKeyUp(KeyCode.M)) {
            test.testMap = WorldGenerator.generateMap(test.testMap, 0, 55);
            test.testMap = WorldGenerator.smoothMap(test.testMap, 5);
            textMapDisplay.text = mapToString(test.testMap);
        }
    }

    // Methods
    // Returns the raw numbers of the map
    public static string mapToStringNumbers(Map inputMap) {
        string outputString = "";

        // Loop through each of the maps tiles
        for (int y = 0; y < inputMap.getMapSize(); y++) {
            for (int x = 0; x < inputMap.getMapSize(); x++) {
                // Add the current tile to the string
                outputString += inputMap.getMapTile(x, y) + " ";

                if (x == inputMap.getMapSize() - 1) {
                    outputString += "\n";
                }
            }
        }

        return outputString;
    }

    // Returns the word version of the map
    public static string mapToString(Map inputMap) {
        string outputString = "";

        // Loop through each of the maps tiles
        for (int y = 0; y < inputMap.getMapSize(); y++) {
            for (int x = 0; x < inputMap.getMapSize(); x++) {

                string insertCharacter = "";
                // Parse the nubmers
                switch (inputMap.getMapTile(x,y)) {
                    case 0:
                        insertCharacter = " ";
                        break;
                    case 1:
                        insertCharacter = "o";
                        break;
                }
                outputString += insertCharacter + " ";

                // Start a new line when the scanning as reached the last index
                if(x == inputMap.getMapSize() - 1) {
                    outputString += "\n";
                }

            }
        }

        return outputString;
    }
}
