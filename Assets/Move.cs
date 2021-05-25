using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Move : MonoBehaviour
{
    public GameObject joint1;
    public GameObject joint2;
    public float speed = 10f;
    public GameObject audioRobot;

    private const float minPower = 12f;
    private const float maxPower = 330f;

    [Range(minPower, maxPower)] 
    public float power;


    void Start()
    {
        audioRobot.SetActive(false);
        // audioRobot.SetActive(true);
    }

    void FixedUpdate()
    {  
    }

    public void Down1()
    {
        joint2.GetComponent<Rigidbody>().isKinematic = true;
        joint1.GetComponent<Rigidbody>().AddTorque(speed *-1,0,0);
        audioRobot.SetActive(true);

        float Power = power;

        audioRobot.GetComponent<AudioSource>().pitch = (195f - 0.4f * Power)/318f;
        audioRobot.GetComponent<AudioSource>().volume = (87f + 0.7f*Power)/318;
    }

    public void Down2()
    {
        joint2.GetComponent<Rigidbody>().isKinematic = false;
        joint2.GetComponent<Rigidbody>().AddTorque(speed *1,0,0);
        audioRobot.SetActive(true);

        float Power = power;

        audioRobot.GetComponent<AudioSource>().pitch = (195f - 0.4f * Power)/318f;
        audioRobot.GetComponent<AudioSource>().volume = (87f + 0.7f*Power)/318;
    }

    public void Up1()
    {
        joint1.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        audioRobot.SetActive(false);
    }

    public void Up2()
    {
        joint2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        audioRobot.SetActive(false);
    }

}

    
    
    
