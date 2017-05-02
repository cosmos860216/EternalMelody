using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.IO;

public class Level : ScriptableObject {
    public List<string> enemyWave1;
    public List<string> enemyWave2;
    public List<string> enemyWave3;
    public string musicName;
    public Image backGround;
}
