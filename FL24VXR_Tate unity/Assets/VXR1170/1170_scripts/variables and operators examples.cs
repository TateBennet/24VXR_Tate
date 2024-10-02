using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class variablesandoperatorsexamples : MonoBehaviour
{

    /*
     * Variables: (int, float, string, bool)
    Arithmetic Operators (=,-,*,/,%)
    Assignment Operators (=,+=,-=)
    Comparison Operators (==, !=, >,<,>=,<=)
    Logical Operators (&&, ||, !)
    Increment/Decrement Operators (++, --)
    Dot Operator (.)
     */

    //Variables
    int health = 100;
    int itemPrice;
    float money = 156.77f;
    string myName = "tate";
    bool isAlive = true;
    int skillpoints = 0;
    int strength = 0;
    int intelligence = 0;

    //Arithmetic Operators
    int damage = 20;
    void injury()
    {
        health = health - damage;
    }

    void income()
    {
        money = money * 2;
    }

    void healthPotion()
    {
        health = health + 50;
    }

    void purchaseItem()
    {
          money = money / itemPrice;
    }

    void hpAboveZero()
    {
        if(health % 2 == 0)
        {
            bool isAlive = false;
        }
    }

    //Comparison Operators (==, !=, >,<,>=,<=)
    void healthChecks()
    {
        if (health == 100)
        {
            string healthStatus = "full health!";
        }
        if(health != 100)
        {
            string healthStatus = "you are injured!";
        }
        if (health >= 100)
        {
            string healthStatus = "OVERHEAL!";
        }
        if (health < 100)
        {
            string healthStatus = "you are injured!";
        }
    }

    //Logical Operators(&&, ||, !)
    void haveMoney()
    {
        if(isAlive && money > 0)
        {
            string moneyStatus = "you have money!";
        }
    }

    void payWithMoneyOrLife()
    {
        if (isAlive == !false || money != 0)
        {
            string question = "Pay with money or your life?";
        }
    }

    //Increment/Decrement Operators(++, --)

    void strengthSkill()
    {
        if (skillpoints > 0)
        {
            strength++;
            intelligence--;
        }
    }

    //Dot Operator (.)
    void nameCheck()
    {
        if (myName.Length > 30)
        {
            string warning = "name is too long!";
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
