using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class Store : MonoBehaviour {

	static public Item[] storeItems = new Item[11];
	static public int itemIndex;

	//Unity
	Button btn;
	static public Sprite mSprites;
	public string[] mStrings;
	public Image imagen;
	public Text text;
	public Text pocket;
	public Text price;
    public Text nivel;

	private void Start()
	{
		btn = GetComponent<Button>();
	}

	private void Update()
	{
  
		pocket.text = "Dinero:   " +  Singleton.blood.ToString();
		price.text = "Costo:  " + (storeItems[itemIndex].Price()).ToString();
        nivel.text = "Nivel "+ (storeItems[itemIndex].nivel).ToString();

        if (Singleton.blood < storeItems[itemIndex].Price() || storeItems[itemIndex].nivel >= storeItems[itemIndex].pricelvl.Length)
			btn.interactable = false;


	}

	public void Buy()
	{
		Singleton.blood -= storeItems[itemIndex].Price();
			
		storeItems[itemIndex].nivel ++;

        Singleton.storeLevels[itemIndex] = storeItems[itemIndex].nivel;

	}

	public void Change()
	{
		if (mSprites != imagen.sprite)
			imagen.sprite = mSprites;

		if (text.text != mStrings[itemIndex])
			text.text = mStrings[itemIndex];


        if (Singleton.blood < storeItems[itemIndex].Price())
        {
            btn.interactable = false;
        }
        else
        {
            btn.interactable = true;
        }
	}

}
