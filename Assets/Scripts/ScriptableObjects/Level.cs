using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Level : ScriptableObject
{
    public int number;
    public new string name = "Level ";
    public List<GameObject> levelObjects = new List<GameObject>();
}
