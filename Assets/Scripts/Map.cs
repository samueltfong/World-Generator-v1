using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map {
    // Variables
    public int[,] map;
    public int mapSize;

    // Constructor
    public Map(int inputMapSize) {
        mapSize = inputMapSize;
        map = new int[mapSize, mapSize];
    }

    // Methods
    

    // Getters
    public int getMapSize() {
        return mapSize;
    }

    public int getMapTile(int getX, int getY) {
        return map[getX, getY];
    }

    // Setters
    public void setMaptile(int setX, int setY, int value) {
        map[setX, setY] = value;
    }
}