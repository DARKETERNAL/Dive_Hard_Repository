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
	public bool canClic;
	bool click;

	[SerializeField]
	float velocidad, amplitud, anguloInicio;

	//Secuencia del principio
	PlayableDirector mDirector;
	public SpriteRenderer tapSprite;
	int fastForward;
	public float sizeScale = 1;


	// Use this for initialization
	void Start () {
		swipe = cuerpo.gameObject.GetComponent<Swipe>();
		swipe.enabled = false;
		mDirector = GetComponent<PlayableDirector>();
		GetComponentInChildren<SpriteRenderer>().enabled = false;

		tapSprite.enabled = true;
		Invoke("TapSignal", 5);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//TimelineFixer
		if (fastForward == 0)
			Time.timeScale = 1;

		if (fastForward == 1)
			Time.timeScale = 2;

		if (fastForward == 2)
			Time.timeScale = 0.3f;

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
			fastForward = 1;
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
			if (canClic)
			{
				if (click)
				{
					running = true;
					aim = false;
					tapSprite.enabled = false;
					fastForward = 1;
				}
			}
				if (aim == false)
					fastForward = 1;
				else
					fastForward = 2;
			
		}

		if (mDirector.time > 9.90)
		{

				cuerpo.simulated = true;
				Lanzar();
			fastForward = 0;
		}
	}

	void Lanzar()
	{
        AudioManager.Instance.Play("Trampoline");
        cuerpo.AddForce(puntero.up * -1 * fuerza*multiplicadorFuerza, ForceMode2D.Impulse);
		Destroy(GetComponent<Lanzador>());
		swipe.enabled = true;
		mText.text = 0.ToString();
		Time.timeScale = 1;
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
			contador.sizeDelta = new Vector2(67,sizeScale *  fuerza);
			contador.anchoredPosition = new Vector2(-160, 5 + (  sizeScale * fuerza/2));

		}
	}

	void TapSignal()
	{
		tapSprite.enabled = true;
	}
}
