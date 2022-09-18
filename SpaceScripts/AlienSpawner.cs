using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    public Alien alienPrefab;

    private float spawnRate = 2.0f;

    private float spawnDistance = 12f;

    private float trajectoryVariance = 15.0f;

    void Start(){
        InvokeRepeating(nameof(Spawn), this.spawnRate, this. spawnRate);
    }



    void Spawn(){
        for (int i = 0; i < this.spawnRate; i++){
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Alien alien = Instantiate(this.alienPrefab, spawnPoint, rotation);
            alien.SetTrajectory(rotation * -spawnDirection);

        }
    }
}
