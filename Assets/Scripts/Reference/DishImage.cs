using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DishImage : MonoBehaviour {
    public GameObject TomatoBeef;
    public GameObject PepperBean;
    public GameObject Bun;
    public GameObject Dumpling;
    public GameObject Wrong;
    // Use this for initialization
    void Start()
    {

    }
    public Sprite getSprite(Menu.Dish dish)
    {
        switch (dish)
        {
            case Menu.Dish.TomatoBeef:
                return TomatoBeef.GetComponent<SpriteRenderer>().sprite;
                break;
            case Menu.Dish.PepperBean:
                return PepperBean.GetComponent<SpriteRenderer>().sprite;
                break;
            case Menu.Dish.Bun:
                return Bun.GetComponent<SpriteRenderer>().sprite;
            case Menu.Dish.Dumpling:
                return Dumpling.GetComponent<SpriteRenderer>().sprite;
        }
        return null;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
