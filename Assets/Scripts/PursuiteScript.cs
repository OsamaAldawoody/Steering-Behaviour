using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuiteScript : MonoBehaviour
{
    public float Mass = 15;
    public float MaxVelocity = 3;
    public float MaxForce = 15;
    

    public Transform target;
    private Vector3 futurePosition;
    private Vector3 velocity;
    private float T = 3;
    private GameObject Seeker;

    void Start()
    {
        velocity = Vector3.zero;
        Seeker = GameObject.FindGameObjectWithTag("Seeker");
    
    }

    // Update is called once per frame
    void Update()
    {
        pursue(target);
    }

    void pursue(Transform target)
    {
        Vector3 distance = target.position - transform.position;
        T = distance.magnitude / MaxForce;
        futurePosition = target.transform.position + target.GetComponent<SeekScript>().getVelocity() * T;
        seek(futurePosition);
    }

    public void seek(Vector3 target)
    {

        Vector3 desiredVelocity = target - transform.position;
        desiredVelocity = desiredVelocity.normalized * MaxVelocity;

        Vector3 steeringVelocity = desiredVelocity - velocity;
        steeringVelocity = Vector3.ClampMagnitude(steeringVelocity, MaxForce);
        steeringVelocity = steeringVelocity / Mass;

        velocity = Vector3.ClampMagnitude(steeringVelocity + velocity, MaxVelocity);
        transform.position += velocity * Time.deltaTime;
        transform.forward = velocity.normalized;

    }
    public Vector3 getVelocity()
    {
        return velocity;
    }
}
