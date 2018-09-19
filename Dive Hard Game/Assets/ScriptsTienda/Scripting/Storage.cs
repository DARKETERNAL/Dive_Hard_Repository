using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour{

	private void Main()
	{
        Store.storeItems[0] = new Item("Altura edificio",0,10,20,30);
		Store.storeItems[1] = new Item("Piernas mas fuertes",1,2,4,6);
		Store.storeItems[2] = new Item("Multiplicador de sangre",2,3,6,9);
		Store.storeItems[3] = new Item("Aumento de gravedad",3,5,10,15);
		Store.storeItems[4] = new Item("Palomas",4,17,30,45);
		Store.storeItems[5] = new Item("Chef",5,3,8,15);
		Store.storeItems[6] = new Item("Meteoros",6,25,50,75);
		Store.storeItems[7] = new Item("Portal",7,12,24,48);
		Store.storeItems[8] = new Item("Aumento swipe",8,17,30,50);
		Store.storeItems[9] = new Item("JetPack",9,14,30,46);
		Store.storeItems[10] = new Item("Ala delta",10,5,9,13);
	}
	
}
