using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    public string name;
    public int id;
    public int minCookTime;
    public int maxCookTime;
    public List<int> ingredientIDs;
    public float markup;

    //constructor for ingredient class
    public Recipe(string _name, int _id, int _minCookTime, int _maxCookTime, List<int> _ingredientIDs, float _markup)
    {
        name = _name;
        id = _id;
        minCookTime = _minCookTime;
        maxCookTime = _maxCookTime;
        List<int> ints = _ingredientIDs;
        markup = _markup;
    }
}