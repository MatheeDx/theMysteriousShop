using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "RecipeDB", menuName = "ScriptableObjects/Recipe")]

public class Recipe : ScriptableObject
{
    public int liq;
    public List<Item> items;
    public Item result;
}
