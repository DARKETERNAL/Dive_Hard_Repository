using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConTienda : StoreObjectsParent
{
    

	[SerializeField]
	GameObject BloodParticles;


    protected override void Start()
    {
        base.Start();
        // float t = (ActualLevel / 2f);
        // Probability *= t;
    }

	protected void BloodSplash(float spawTime , float fuerzaDeLanzamiento , int cantidadDeParticulas,Transform player)
	{
		GameObject blood =  Instantiate(BloodParticles, player.position , Quaternion.identity);

		ParticleSystem particle = blood.GetComponent<ParticleSystem>();

		particle.startSpeed = fuerzaDeLanzamiento;
		particle.emission.SetBurst(0, new ParticleSystem.Burst(0, (short)cantidadDeParticulas , (short)cantidadDeParticulas , 1 , 0.010f));

		if (!particle.isPlaying)
			particle.Play();

		Destroy(blood, spawTime);
	}


}
