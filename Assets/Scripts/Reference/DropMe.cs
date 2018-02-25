using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class DropMe : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Image containerImage;
	public Image receivingImage;
	private Color normalColor;
    public Menu.Type cookerMenu;
    public Sprite defaultImg;
    private List<Menu.Dish> myMenu;
    private HashSet<Menu.Ingredient> currentDish;
    private Menu.Dish dish;
    private GameObject timer;

    public void OnEnable ()
	{
        GetComponent<Image>().sprite = defaultImg;
        myMenu = Menu.getMenu(cookerMenu);
        currentDish = new HashSet<Menu.Ingredient>();
        timer= this.gameObject.transform.GetChild(0).gameObject;
        dish = Menu.Dish.Wrong;
    }
	
	public void OnDrop(PointerEventData data)
	{
		if (receivingImage == null)
			return;

    //get ingredient this time
        var originalObj = data.pointerDrag;
        if (originalObj == null)
          return;
        var dragMe = originalObj.GetComponent<DragMe>();
        if (dragMe == null)
             return;
        var thisIngredient = dragMe.type;
        currentDish.Add(thisIngredient);

        //check if it is in menu, m is Menu.Dish
        bool accept = false;
        
        HashSet<Menu.Ingredient> book;
        foreach (var m in myMenu)
        {
            book = Menu.getCookBook(m);
            if (book == null) continue;
            if (book.SetEquals(currentDish))
            {
                GetComponent<Image>().sprite = GetComponent<DishImage>().getSprite(m);
                timer.GetComponent<Timer>().RunTime();
                dish = m;
                return;
            }
            if (book.Contains(thisIngredient)) accept = true;
        }
        if (!accept)
        {
            currentDish.Remove(thisIngredient);
            return;
        }


        if (isWrong()) {
            GetComponent<Image>().sprite = GetComponent<DishImage>().Wrong.GetComponent<SpriteRenderer>().sprite;
            return;
        }

        Sprite dropSprite = GetDropSprite (data);
		if (dropSprite != null)
			receivingImage.sprite = dropSprite;
	}

    public Menu.Dish getDish()
    {
        return dish;
    }

    private bool isWrong()
    {
        HashSet<Menu.Ingredient> book;
        bool result=false;
        bool tmp;
        foreach (var m in myMenu)
        {
            book = Menu.getCookBook(m);
            tmp = false;
            foreach(var i in currentDish)
            {
                result = true;
                if (!book.Contains(i)) tmp=true;
            }
            if (!tmp) return false;
        }
        return result;
    }

	public void OnPointerEnter(PointerEventData data)
	{
		if (containerImage == null)
			return;
		
		Sprite dropSprite = GetDropSprite (data);

	}

	public void OnPointerExit(PointerEventData data)
	{
		//if (containerImage == null)
			//return;
		
		//containerImage.color = normalColor;
	}
	
	private Sprite GetDropSprite(PointerEventData data)
	{
		var originalObj = data.pointerDrag;
		if (originalObj == null)
			return null;
		
		var dragMe = originalObj.GetComponent<DragMe>();
		if (dragMe == null)
			return null;
		
		var srcImage = originalObj.GetComponent<Image>();
		if (srcImage == null)
			return null;
		
		return srcImage.sprite;
	}

    public void clear()
    {
        currentDish.Clear();
        GetComponent<Image>().sprite = defaultImg;
        timer.GetComponent<Timer>().ClearTime();
        dish = Menu.Dish.Wrong;
    }


}
