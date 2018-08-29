using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Floor : MonoBehaviour {

    //[SerializeField]
    //Edificio alturaDeEdificio;
    float floorHeigth = 0;
    Player player;
    Rigidbody2D playerRig;
    int Finalscore;
    [SerializeField]
    GameObject restartMenu;
    [SerializeField]
    Text textoPuntaje;
    private void Start()
    {
        restartMenu.SetActive(false);
        player = GameObject.Find("Player").GetComponent<Player>() ;
        playerRig = player.GetComponent<Rigidbody2D>();
        //floorHeigth = Mathf.Abs(player.position.y - alturaDeEdificio.transform.position.y);
    }
    // Update is called once per frame
    void FixedUpdate () {
        transform.position = new Vector3(player.transform.position.x, floorHeigth, transform.position.z);
        if (player.transform.position.y <= floorHeigth)
        {
            Finalscore = (int)(player.bloodInGame + (Mathf.Abs(playerRig.velocity.y * 1000))); // sujeto a cambios
            print(playerRig.velocity.y);
            playerRig.velocity = Vector2.zero;
            playerRig.angularVelocity = 0;
            player.transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
            //this coud be change
            StartCoroutine(RestartProtocole());            
        }
	}
    //this coud be change
    IEnumerator RestartProtocole()
    {
    
        yield return new WaitForSeconds(2f);
        restartMenu.SetActive(true);
        //yield return new WaitForFixedUpdate();
        //textoPuntaje.text = "0";
        //yield return new WaitForFixedUpdate();
        //textoPuntaje.text = ((int)(Finalscore / 4f)).ToString();
        //yield return new WaitForFixedUpdate();
        //textoPuntaje.text = ((int)(Finalscore / 2f)).ToString();
        //yield return new WaitForFixedUpdate();
        //textoPuntaje.text = ((int)(Finalscore * 3 / 4f)).ToString();
        //yield return new WaitForFixedUpdate();
        textoPuntaje.text = (Finalscore).ToString();
        yield return null;
    }
}
