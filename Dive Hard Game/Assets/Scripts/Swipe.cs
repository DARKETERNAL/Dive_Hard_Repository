using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class Swipe : PassiveMechanics
{
    Vector2 intial, final, vecMov;
    [SerializeField]
    float minDis, magnitud;
    Rigidbody2D me;
    protected override void Execution() //start
    {
        me = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
            intial = Input.mousePosition;
        if (Input.GetButtonUp("Fire1"))
        {
            final = Input.mousePosition;
            vecMov = (final - intial).normalized;
            if (Vector2.Distance(final, intial) >= minDis)
                me.AddForce(vecMov * magnitud, ForceMode2D.Impulse);
        }
    }
=======
public class Swipe : MonoBehaviour {

	bool tap, isUp, isDraging = false;
	int counter;
	float timer; 

	[SerializeField]
	float coldDown, magnitud;
	[SerializeField]
	int maxCounter;

	Vector2 starTouch, swipeDelta;
	Rigidbody2D mRB;

	private void Start()
	{
		mRB = GetComponent<Rigidbody2D>();
		counter = maxCounter;
	}

	private void Update()
	{		
		tap = false;

		#region Mouse Inputs
		if (Input.GetMouseButtonDown(0))
		{
			tap = true;
			isDraging = true;
			starTouch = Input.mousePosition;
		}
		else if (Input.GetMouseButtonUp(0))
		{
			Reset();
		}

		#endregion

		#region Mobile Inputs
		if (Input.touches.Length > 0)
		{
			if (Input.touches[0].phase == TouchPhase.Began)
			{
				tap = true;
				isDraging = true;
				if(starTouch == Vector2.zero)
					starTouch = Input.touches[0].position;
			}
			else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
			{
				Reset();
			}
		}

		#endregion

		swipeDelta = Vector2.zero;
		//Calcular Distancia
		if (isDraging)
		{
			if (Input.touches.Length > 0)
				swipeDelta = Input.touches[0].position - starTouch;
			if (Input.GetMouseButton(0))
				swipeDelta = (Vector2)Input.mousePosition - starTouch;
		}


		//Pasar la Zona muerta
		if (swipeDelta.magnitude > 200 && counter > 0)
		{
			mRB.AddForce(swipeDelta * magnitud,ForceMode2D.Impulse);
			counter--;
			Reset();
		}

		//ColdDown
		if(counter < maxCounter)
		{
			if(!isUp)
			{
				timer += Time.deltaTime;

				if (timer >= coldDown)
					isUp = true;
			}
			else
			{
				timer = 0;
				isUp = false;
				counter++;
			}
		}

		print(counter);
	}

	private void Reset()
	{
		starTouch = swipeDelta = Vector2.zero;
		isDraging = false;
	}
>>>>>>> 24ab2908bed852e6f7ff84551c8fb0633bb5d671
}
