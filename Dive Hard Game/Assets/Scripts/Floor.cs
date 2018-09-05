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
    int finalScore;
    [SerializeField]
    GameObject restartMenu;
    [SerializeField]
    TextMeshProUGUI textoPuntaje;
	public GameObject BloodParticles;

	bool itCollide;
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
            finalScore = (int)(player.bloodInGame + ((GameObject.Find("trigger").GetComponent<VelocidadFinal>().velFin)/400)); // sujeto a cambios (cambiado por Olarte)v 2.0

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
        textoPuntaje.text = (finalScore).ToString();
        yield return null;
    }


	protected void BloodSplash(float spawTime, float fuerzaDeLanzamiento, int cantidadDeParticulas, Transform player)
	{
		GameObject blood = Instantiate(BloodParticles, player.position, Quaternion.identity);
		ParticleSystem particle = blood.GetComponent<ParticleSystem>();

		particle.startSpeed = fuerzaDeLanzamiento;
		particle.emission.SetBurst(0, new ParticleSystem.Burst(0, (short)cantidadDeParticulas, (short)cantidadDeParticulas, 1, 0.010f));

		if (!particle.isPlaying)
			particle.Play();

		Destroy(blood, spawTime);
	}


	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
			int score = (int)(player.bloodInGame + ((GameObject.Find("trigger").GetComponent<VelocidadFinal>().velFin) / 400));

			playerRig.velocity = new Vector2((playerRig.velocity.x / 5), Mathf.Abs(playerRig.velocity.y / 10));

			if (!itCollide)
			{
				BloodSplash(10, playerRig.velocity.y * 10, score * 5, player.transform);
				itCollide = true;
			}
		}
    }
}
