using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UberAudio;

public class Lanzador : MonoBehaviour {

	float fuerza;
	public Rigidbody2D cuerpo;
	Swipe swipe;
	public Transform puntero;
	public Text mText;
	public RectTransform contador;
	public float multiplicadorFuerza;
	float t = 8;
	float timer = 0;
	bool running = true;
	bool aim = true;
	bool oneTimeAim = true;
	public bool jumping = true;
	bool click;

	[SerializeField]
	float velocidad, amplitud, anguloInicio;

	//Secuencia del principio
	PlayableDirector mDirector;
	public SpriteRenderer tapSprite;
	public TimelineAsset timeline;

	// Use this for initialization
	void Start () {
		swipe = cuerpo.gameObject.GetComponent<Swipe>();
		swipe.enabled = false;
		mDirector = GetComponent<PlayableDirector>();
		GetComponentInChildren<SpriteRenderer>().enabled = false;

		tapSprite.enabled = false;
		Invoke("TapSignal", 5);


		timeline.GetOutputTrack(3).muted = false;
		timeline.GetOutputTrack(4).muted = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		click = Input.GetButtonDown("Fire1");

		if (click)
		{
			if (IsInvoking("TapSignal"))
				CancelInvoke("TapSignal");

			tapSprite.enabled = false;

			running = false;
			mDirector.enabled = true;
		}


		if(running == false)
		{
			
			if (t < 0)
			{
				mText.text = "0.00";
				if (aim)
				{
					Apuntar();
				}
				GetComponentInChildren<SpriteRenderer>().enabled = true;
			}
			else
			{
				CalculaFuerza();

				mText.text = System.Math.Round(t, 2).ToString();
				t -= Time.deltaTime;
			}
		}

		if(jumping == false)
		{
			
			if (click)
			{
				timeline.GetOutputTrack(3).muted = true;
				timeline.GetOutputTrack(4).muted = false;
				running = true;
				aim = false;
				tapSprite.enabled = false;
			}
		}
		if (mDirector.time > 9.98)
		{

				cuerpo.simulated = true;
				Lanzar();
		}
	}

	void Lanzar()
	{
        AudioManager.Instance.Play("Trampoline");
        cuerpo.AddForce(puntero.up * -1 * fuerza*multiplicadorFuerza, ForceMode2D.Impulse);
		Destroy(GetComponent<Lanzador>());
		swipe.enabled = true;
		mText.text = 0.ToString();
        
	}

	void Apuntar()
	{
		timer += Time.deltaTime;
		transform.eulerAngles = new Vector3(0, 0, ((Mathf.Sin(timer * velocidad)) * amplitud) + anguloInicio);
	}

	void CalculaFuerza()
	{
		if (click)
		{
			fuerza++;
			contador.localScale = new Vector3(1, fuerza * 1, 1);
		}
	}

	void TapSignal()
	{
		tapSprite.enabled = true;
	}
}
