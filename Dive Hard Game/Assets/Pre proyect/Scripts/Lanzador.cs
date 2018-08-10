using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lanzador : MonoBehaviour {

	float fuerza;
	public Rigidbody2D cuerpo;
	public Transform puntero;
	public Text mText;
	public RectTransform contador;
	public float multiplicadorFuerza;
	float t = 5;
	float timer = 0;
	bool on1 = true;
	bool on2 = true;
	bool click;

	[SerializeField]
	float velocidad, amplitud, anguloInicio;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		click = Input.GetButtonDown("Fire1");

		if (click)
			on1 = false;


		if(on1 == false)
		{
			mText.text = t.ToString();
			t -= Time.deltaTime;

			if (t <= 0)
			{
				Apuntar();
				StartCoroutine(WaitToLaunch());
			}
			else
				CalculaFuerza();
		}

		if(on2 == false)
		{
			if(click)
				Lanzar();
		}
	}

	void Lanzar()
	{
		cuerpo.AddForce(puntero.up * -1 * fuerza*multiplicadorFuerza, ForceMode2D.Impulse);
		Destroy(GetComponent<Lanzador>());
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

	IEnumerator WaitToLaunch()
	{
		mText.text = "Apuntar!!!!";
		yield return new WaitForSeconds(1);
		on2 = false;
	}
}
