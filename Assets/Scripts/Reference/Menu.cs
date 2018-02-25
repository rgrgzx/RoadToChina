using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu
{
    public enum Ingredient { tomato, beef, pepper, bean, bun, dumpling };
    public enum Type { PotMenu, SteamerMenu };
    public enum Dish { TomatoBeef, PepperBean, Bun, Dumpling, Wrong}

    public static List<Dish> getMenu(Type type)
    {
        List<Dish> res = new List<Dish>();
        switch (type)
        {
            case Type.PotMenu:
                res.Add(Dish.TomatoBeef);
                res.Add(Dish.PepperBean);
                break;
            case Type.SteamerMenu:
                res.Add(Dish.Bun);
                res.Add(Dish.Dumpling);
                break;
        }
        return res;
    }

    public static HashSet<Ingredient> getCookBook(Dish dish)
    {
        HashSet<Ingredient> res = new HashSet<Ingredient>();
        switch (dish)
        {
            case Dish.TomatoBeef:
                res.Add(Ingredient.tomato);
                res.Add(Ingredient.beef);
                break;
            case Dish.PepperBean:
                res.Add(Ingredient.pepper);
                res.Add(Ingredient.bean);
                break;
            case Dish.Bun:
                res.Add(Ingredient.bun);
                break;
            case Dish.Dumpling:
                res.Add(Ingredient.dumpling);
                break;
        }
        return res;
    }


}
