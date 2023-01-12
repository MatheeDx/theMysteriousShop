using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PoisonsDB", menuName = "ScriptableObjects/Poison")]

public class Poison : ScriptableObject
{
    public int id;
    public string name;
    public GameObject icon;
    public Color color;
}