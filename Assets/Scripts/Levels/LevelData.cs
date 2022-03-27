using UnityEngine;

[CreateAssetMenu(menuName = "Level", fileName = "Level New")]
public class LevelData : ScriptableObject
{
    [TextArea(1, 10)]
    public string levelString;
    public LevelData left;
    public LevelData right;
    public LevelData up;
    public LevelData down;
}
