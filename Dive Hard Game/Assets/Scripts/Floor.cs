using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    TextMeshProUGUI textoPuntaje;
    private void Start()
    {
        
        player = GameObject.Find("Player").GetComponent<Player>() ;
        playerRig = player.GetComponent<Rigidbody2D>();
        //floorHeigth = Mathf.Abs(player.position.y - alturaDeEdificio.transform.position.y);
        restartMenu.SetActive(false);
    }
    // Update is called once per frame
    void FixedUpdate () {
        transform.position = new Vector3(player.transform.position.x, floorHeigth, transform.position.z);
        if (player.transform.position.y <= floorHeigth+5)
        {
            Finalscore = (int)(player.bloodInGame + ((GameObject.Find("trigger").GetComponent<VelocidadFinal>().velFin)/400)); // sujeto a cambios (cambiado por Olarte)v 2.0

            playerRig.velocity = Vector2.zero;
            playerRig.angularVelocity = 0;
            player.transform.position = new Vector3(transform.position.x, transform.position.y+5, player.transform.position.z);

            
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerRig.velocity = new Vector2((playerRig.velocity.x / 5), Mathf.Abs(playerRig.velocity.y / 10));

        }
    }
}
