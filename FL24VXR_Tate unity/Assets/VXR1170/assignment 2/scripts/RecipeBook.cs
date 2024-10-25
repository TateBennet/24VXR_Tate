using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBook : MonoBehaviour
{

    public List<Ingredient> ingredients = new List<Ingredient>();
    public List<Recipe> recipes = new List<Recipe>();
    public List<int> usedIngredients = new List<int>();

    public Transform[] recipeSpawn;

    public int chosenRecipeID;

    [SerializeField]
    //private PanLogic;

    public float earnings;

    private bool gameStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        ingredients.Add(new Ingredient("Bun",0,Resources.Load("Ingredients/Bun") as  GameObject, 1));
        ingredients.Add(new Ingredient("Beef", 1, Resources.Load("Ingredients/Beef") as GameObject, 5));
        ingredients.Add(new Ingredient("Cheese", 2, Resources.Load("Ingredients/Cheese") as GameObject, 4));
        ingredients.Add(new Ingredient("Tomato", 3, Resources.Load("Ingredients/Tomato") as GameObject, 2));
        ingredients.Add(new Ingredient("Lettuce", 4, Resources.Load("Ingredients/Lettuce") as GameObject, 3));

        //recipes.Add(new Recipe("Recipe 1", 0, 3, 5, RandomIngredientList(), 20));
        //recipes.Add(new Recipe("Recipe 2", 1, 5, 10, RandomIngredientList(), 40));
        //recipes.Add(new Recipe("Recipe 3", 2, 3, 7, RandomIngredientList(), 50));
        //recipes.Add(new Recipe("Recipe 4", 3, 2, 8, RandomIngredientList(), 30));

    }

    //void RandomIngredientList() { }

    // Update is called once per frame
    void Update()
    {
        
    }
}
