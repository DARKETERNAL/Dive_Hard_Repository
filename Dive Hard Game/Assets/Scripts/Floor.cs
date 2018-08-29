using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Floor : MonoBehaviour {

    [SerializeField]
    Edificio alturaDeEdificio;
    float floorHeigth;
    Transform player;
    private void Start()
    {
        player = GameObject.Find("Player").transform;
        floorHeigth = Mathf.Abs(player.position.y - alturaDeEdificio.transform.position.y);
    }
    // Update is called once per frame
    void FixedUpdate () {
        if (player.position.y <= floorHeigth)
        {
            //this coud be change
            StartCoroutine(RestartProtocole());
        }
	}
    //this coud be change
    IEnumerator RestartProtocole()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        yield return null;
    }
}
