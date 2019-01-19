using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeOnda2 : MonoBehaviour {

		private GameObject[] particle;
		public GameObject particlePrefab;
			[Header("Native variables")]
				[Range(20,1000)]
public int particlesCount;
	public float particleMaxInitializeVariation;
		private float particleInitializeVariation;
			private float numberOfInitializedParticles = 2;
private float[] x;
private float[] t;
	private float[] y;
			[Range(-0.15f,5)]
		public float distBetweenParticles;
			[Range(-10,10)]
	public float timeIncrease;

	[Space(20)]
	[Header("Simulated consts")]
		[Range(-15,15)]
	public float A;
		[Range(-2,2)]
	public float w;
		[Range(-30,30)]
	public float K;
	public float Fi;

	void Start () {
		particle = new GameObject[particlesCount];

				for(int i = 0; i<particlesCount; i++){
					particle[i] = Instantiate(particlePrefab) as GameObject;
				}

			particleInitializeVariation = particleMaxInitializeVariation;
			x = new float[particle.Length];
			t = new float[particle.Length];
			y = new float[particle.Length];
				for(int i = 0; i<x.Length; i++){
					if(i>0){
						x[i] = x[i-1] + distBetweenParticles;
					}
					else{
						x[i] = 0;
						t[i] = 0;
					}
				}
						
	}
		
	void FixedUpdate () {
			for(int i = 2; i<numberOfInitializedParticles; i++){
				x[i] = x[i-1] + distBetweenParticles;
				t[i]+=timeIncrease;
				y[i] = A * Mathf.Sin(w*t[i] - K*x[i] + Fi);
					
				particle[i].GetComponent<Transform>().position = new Vector3(x[i], y[i], 0);
			}
				particleDrawing();
	}

			void particleDrawing(){
					particle[0].GetComponent<Transform>().position = new Vector3(0, 1, 0);
					particle[1].GetComponent<Transform>().position = new Vector3(0, -1, 0);
				if(numberOfInitializedParticles < particle.Length){
					if(particleInitializeVariation<= 0){
						particleInitializeVariation = particleMaxInitializeVariation;
						numberOfInitializedParticles++;

					}
					else{
						particleInitializeVariation--;
					}
				}
			}

					public void slider_DistBetweenPatricles(float value){
						distBetweenParticles = value;
					}
					public void slider_TimeIncrease(float value){
						timeIncrease = value;
					}
					public void slider_A(float value){
						A = value;
					}
					public void slider_w(float value){
						w = value;
					}
					public void slider_K(float value){
						K = value;
					}
					public void slider_Fi(float value){
						Fi = value;
					}
				public void slider_ParticlesCount(float value){
					particlesCount = (int)value;
				}
				public void slider_ParticleMaxInitializeVariation(float value){
					particleMaxInitializeVariation = value;
				}



}
