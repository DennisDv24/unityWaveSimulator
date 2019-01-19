using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Policy;

public class ControladorDeOnda : MonoBehaviour {

Vector2[] particle;
private PolygonCollider2D pc2d;
	[Header("Native variables")]
		[Range(20,1000)]
public int particlesCount;
	public float particleMaxInitializeVariation;
		private float particleInitializeVariation;
			private float numberOfInitializedParticles = 2;
private float[] x;
private float[] t;
	private float[] y;
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
		pc2d = GetComponent<PolygonCollider2D>();
		particle = new Vector2[particlesCount];
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
	
	void Update () {
		pc2d.points = particle;

			for(int i = 2; i<numberOfInitializedParticles; i++){
				x[i] = x[i-1] + distBetweenParticles;
				t[i]+=timeIncrease;
				y[i] = A * Mathf.Sin(w*t[i] - K*x[i] + Fi);
					
				particle[i] = new Vector2(x[i], y[i]);
			}
				particleDrawing();

	}

			void particleDrawing(){
					particle[0] = new Vector2(0,1);
					particle[1] = new Vector2(0,-1);
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
}
 