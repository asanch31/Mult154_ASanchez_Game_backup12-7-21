///
/// Code modified from https://learn.unity.com/tutorial/hide-h1zl/?courseId=5dd851beedbc2a1bf7b72bed&projectId=5e0b9220edbc2a14eb8c9356&tab=materials&uv=2019.3#
/// Author: Penny de Byl
///
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public enum BMode
    {
        SEEK,
        FLEE,
        PURSUE,
        EVADE,
        WANDER,

    }

    NavMeshAgent agent;
    private GameObject target;
    private Rigidbody rbBody;
    public BMode mode;


    float currentSpeed
    {
        get { return rbBody.velocity.magnitude; }
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        agent = this.GetComponent<NavMeshAgent>();
        rbBody = target.GetComponent<Rigidbody>();
    }

    public void Seek(Vector3 location)
    {

        
        agent.SetDestination(location);
    }

    public void Flee(Vector3 location)
    {

        
        Vector3 fleeVector = location - this.transform.position;
        agent.SetDestination(this.transform.position - fleeVector);
    }

    public void Pursue()
    {
        
        Vector3 targetDir = target.transform.position - this.transform.position;

        float relativeHeading = Vector3.Angle(this.transform.forward, this.transform.TransformVector(target.transform.forward));

        float toTarget = Vector3.Angle(this.transform.forward, this.transform.TransformVector(targetDir));
        
        if ((toTarget > 200 && relativeHeading < 45) || currentSpeed < 0.01f)
        {
            Seek(target.transform.position);
            return;
        }

        float lookAhead = targetDir.magnitude / (agent.speed + currentSpeed);
        Seek(target.transform.position + target.transform.forward * lookAhead);
    }

    public void Evade()
    {

        print("e");
        Vector3 targetDir = target.transform.position - this.transform.position;
        float lookAhead = targetDir.magnitude / (agent.speed + currentSpeed);
        Flee(target.transform.position + target.transform.forward * lookAhead);
    }


    Vector3 wanderTarget = Vector3.zero;
    public void Wander()
    {

        print("w");
        float wanderRadius = 5;
        float wanderDistance = 5;
        float wanderJitter = 1;

        wanderTarget += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter,
                                        0,
                                        Random.Range(-1.0f, 1.0f) * wanderJitter);
        wanderTarget.Normalize();
        wanderTarget *= wanderRadius;

        Vector3 targetLocal = wanderTarget + new Vector3(0, 0, wanderDistance);
        //Vector3 targetWorld = this.gameObject.transform.InverseTransformVector(targetLocal);

        Seek(transform.position + targetLocal);
    }

   

   

    public bool CanSeeTarget()
    {

        print("ct");
        RaycastHit raycastInfo;
        Vector3 targetXZPos = new Vector3(target.transform.position.x, 1.5f, target.transform.position.z);
        Vector3 thisXZPos = new Vector3(transform.position.x, 1.5f, transform.position.z);

        Vector3 rayToTarget = targetXZPos - thisXZPos;
        if (Physics.Raycast(this.transform.position, rayToTarget, out raycastInfo))
        {
            if (raycastInfo.transform.gameObject.tag == "Player")
                return true;
        }
        return false;
    }

    

}