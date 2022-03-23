using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekScript : MonoBehaviour
{
    public float seekWeight = 15;
    public float MaxVelocity = 3;
    public float MaxForce = 15;

    private Vector3 velocity;
    public Transform target;
    public Transform body;

    void Start()
    {
        velocity = Vector3.zero;
    }


    void Update()
    {
       
        seek(new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z));
        
    }

    public void seek(Vector3 target)
    {

        Vector3 desiredVelocity = target - transform.position;
        desiredVelocity = desiredVelocity.normalized * MaxVelocity;

        Vector3 steeringVelocity = desiredVelocity - velocity;
        steeringVelocity = Vector3.ClampMagnitude(steeringVelocity, MaxForce);
        steeringVelocity = steeringVelocity / seekWeight;

        velocity = Vector3.ClampMagnitude(steeringVelocity + velocity, MaxVelocity);
        transform.position += velocity * Time.deltaTime;
        transform.forward = velocity.normalized;
        
    }

    
    public Vector3 getVelocity()
    {
        return velocity;
    }
}
