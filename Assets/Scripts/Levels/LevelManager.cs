using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private LevelManager instance;
    public LevelGenerator levelGenerator;
    public LevelData startingLevel;
    public Vector3Int levelDimensions;
    public LevelManager GetInstance() {
        return instance;
    }
    // Start is called before the first frame update
    void Awake()
    {
        if (!instance) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        levelGenerator.Initialize();
        levelGenerator.GenerateLevel(startingLevel.levelString, Vector3Int.zero);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
