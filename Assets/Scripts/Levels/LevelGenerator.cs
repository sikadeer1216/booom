using System;
using System.Collections.Generic;
using UnityEngine;
/**
* Parse a string into a level.
0 - empty space
1 - solid wall
l - solid wall on light
d - solid wall on dark
b - breakable wall
c - collectible
e.g.
1111111111111111111111111\n
10000000b00c00b0000000001\n
1000000011111110000000001\n
0000000000000000000000000\n
1111111111111111111111111\n
*/
[Serializable]
public struct CharBlockPair {
    public char character;
    public GameObject blockPrefab;
}
public class LevelGenerator : MonoBehaviour
{
    public CharBlockPair[] charBlockPairs;
    private Dictionary<char, GameObject> charBlockMap;
    private Dictionary<Vector3Int, LevelObjectScript> posObjectMap;

    public void Initialize() {
        charBlockMap = new Dictionary<char, GameObject>();
        foreach (CharBlockPair cbp in charBlockPairs) {
            charBlockMap[cbp.character] = cbp.blockPrefab;
        }
    }

    public void GenerateLevel(string level, Vector3Int origin) {
        posObjectMap = new Dictionary<Vector3Int, LevelObjectScript>(new Vector3IntEqualityComparer());
        string[] rows = level.Split('\n');
        for (int y = 0; y < rows.Length; y++) {
            string row = rows[y];
            for (int x = 0; x < row.Length; x++) {
                Vector3Int pos = new Vector3Int(origin.x + x, origin.y - y, origin.z);
                char character = row[x];
                charBlockMap.TryGetValue(character, out GameObject objectPrefab);
                if (objectPrefab) {
                    posObjectMap[pos] = Instantiate(objectPrefab, pos, Quaternion.identity)
                        .GetComponent<LevelObjectScript>();
                }
            }
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
