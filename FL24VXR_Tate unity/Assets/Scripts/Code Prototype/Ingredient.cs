using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Ingredient
{
    public string name;
    public int id;
    public GameObject prefab;
    public int dollarValue;

    //constructor for ingredient class
    public Ingredient(string _name, int _id, GameObject _prefab, int _dollarValue)
    {
        name = _name;
        id = _id;
        prefab = _prefab;
        dollarValue = _dollarValue;
    }
}
