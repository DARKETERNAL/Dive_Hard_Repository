using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MundoConTienda : StoreObjectsParent
{
    public bool active;
    [SerializeField]
    float probability;
    public float height, inverseRange = 0.02f;
    public Vector3 offSet;
    public float Probability { get { return probability; } set { probability = Mathf.Clamp(value, 0, 50); } }

	[SerializeField]
	GameObject BloodParticles;

    bool counting;
    float maxPoolingDistance;
    Vector3 player;

    private void Start()
    {
        // float t = (ActualLevel / 2f);
        // Probability *= t;
    }
    protected virtual void FixedUpdate()
    {
        if (active)
            if (Time.timeScale == 1)
                Action();

        if (active)
            DistancePooling();
    }
    protected abstract void Action();
    protected virtual IEnumerator Activation(Player _jugador)
    {
        yield return null;
    }

	protected void BloodSplash(float spawTime , float fuerzaDeLanzamiento , int cantidadDeParticulas,Transform player)
	{
		GameObject blood =  Instantiate(BloodParticles, player.position , Quaternion.identity);
		ParticleSystem particle = blood.GetComponent<ParticleSystem>();


		print(blood.transform.position);
		particle.startSpeed = fuerzaDeLanzamiento;
		particle.emission.SetBurst(0, new ParticleSystem.Burst(0, (short)cantidadDeParticulas , (short)cantidadDeParticulas , 1 , 0.010f));

		if (!particle.isPlaying)
			particle.Play();

		Destroy(blood, spawTime);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (active)
			if (collision.GetComponent<Player>() != null)
			{
				StartCoroutine(Activation(collision.GetComponent<Player>()));
				BloodSplash(10,100,250 , collision.transform);
			}
    }
    protected void BackToPool()
    {
        active = false;
        counting = false;
        transform.position = new Vector3(-500, -500, 0);
    }
     void DistancePooling()
    {
        player = GameObject.Find("Player").GetComponent<Transform>().position;
        if (!counting)
        {
            
            maxPoolingDistance = Vector3.Distance(transform.position, player) + 1;
        }
        counting = true;
        if (Vector3.Distance(transform.position, player) > maxPoolingDistance)
        {
            BackToPool();
        }
    }
}
