using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : GrabbableObjectSimHand
{
    public GameObject pelletPrefab;
    public float shootingForce;
    public Transform spawnPoint;

    public override void OnInteractionStarted()
    {
        GameObject spawnedPellet = Instantiate(pelletPrefab, spawnPoint.position, spawnPoint.rotation);
        spawnedPellet.GetComponent<Rigidbody>().AddForce(spawnedPellet.transform.forward * shootingForce);
        Destroy(spawnedPellet, 2);
    }
}
