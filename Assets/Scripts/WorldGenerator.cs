using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour {
    // Variables
    public static readonly int waterID = 0;
    public static readonly int landID = 1;

    /**
     * Generates a map using parameters of the map to change, the seed
     * of the map, as well as the percentage of tiles that should be
     * land.
     * 
     * @param seed - If zero, a random value will be supplied.
     */
    public static Map generateMap(Map inputMap, int seed, int landChance) {
        Map outputMap = new Map(inputMap.getMapSize()); // Creates a new map using the size of the input map

        // Generate a seed or use one provided by the user
        if (seed == 0) {
            seed = (int)System.DateTime.Now.Ticks;
        }

        seed = Mathf.Abs(seed);
        Debug.Log("Seed is " + seed);
        Random.InitState(seed);

        // Loop through every tile and set one to a random number between 1-100
        for (int x = 0; x < inputMap.getMapSize(); x++) {
            for (int y = 0; y < inputMap.getMapSize(); y++) {
                int tileNumber = Random.Range(0, 101);

                // Translate the nubmer to a single digit
                if (tileNumber <= landChance) {
                    tileNumber = landID;
                }
                else {
                    tileNumber = waterID;
                }
                outputMap.setMaptile(x, y, tileNumber);
                
            }
        }

        // Once each tile is filled in, change the outer tiles to water
        for (int x = 0; x < inputMap.getMapSize(); x++) {
            for (int y = 0; y < inputMap.getMapSize(); y++) {
                if (x == 0 || x == inputMap.getMapSize() - 1) {
                    outputMap.setMaptile(x, y, 0);
                }
                if (y == 0 || y == inputMap.getMapSize() - 1) {
                    outputMap.setMaptile(x, y, 0);
                }
            }
        }

        return outputMap;
    }

    public static Map smoothMap(Map inputMap, int maxReps) {
        Map outputMap = inputMap;

        for (int currReps = 0; currReps <= maxReps; currReps++) {
            for (int x = 1; x < outputMap.getMapSize() - 1; x++) {
                for (int y = 1; y < outputMap.getMapSize() - 1; y++) {
                    if(getSurrTiles(outputMap, x, y, waterID) > 4) {
                        outputMap.setMaptile(x, y, waterID);
                    }
                    else if(getSurrTiles(outputMap, x, y, waterID) < 4) {
                        outputMap.setMaptile(x, y, landID);
                    }
                }
            }
        }

        Debug.Log("Done smoothing!");
        return outputMap;
    }

    public static int getSurrTiles(Map inputMap, int scanX, int scanY, int searchNum) {
        int count = 0;

        for (int x = scanX - 1; x <= scanX + 1; x++) {
            for (int y = scanY - 1; y <= scanY + 1; y++) {
                if(inputMap.getMapTile(x, y) == searchNum && (x != scanX || y != scanY)) {
                    count++;
                }
            }
        }

        //Debug.Log("There are " + count + " tiles with id " + searchNum + " next to " + scanX + ", " + scanY);
        return count;
    }

    public static int surroundingWaterCount(Map inputMap, int scanX, int scanY) {
        int count = 0;

        for (int x = scanX - 1; x <= scanX + 1; x++) {
            for (int y = scanY - 1; y <= scanY + 1; y++) {
                if(inputMap.getMapTile(x, y) == waterID && (x != scanX || y != scanY)) {
                    count++;
                }
            }
        }

        //Debug.Log("There are " + count + " water tiles next to " + scanX + ", " + scanY);
        return count;
    }

}