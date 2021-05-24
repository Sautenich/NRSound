using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Movement : MonoBehaviour
{
    public Slider mainSlider;
    public GameObject jointImg;
    public Text jointText;
    private Rigidbody rb;
    bool rot;
    public GameObject audioRobot;

    [Range(12, 330)]
    public float power;

    public float speed = 1f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioRobot.SetActive(false);
    }

    void FixedUpdate()
    {
        audioRobot.GetComponent<AudioSource>().pitch = ((power - 12f)/318f) * -0.5f;
        Rot();
        MovementOnSoundOn(); 
    }

    void Rot()
    {
        jointImg.transform.rotation = Quaternion.Euler(mainSlider.value, 180, 90);
        jointText.text = "Joint: " + mainSlider.value.ToString(); 
        // Quaternion a = jointImg.transform.rotation; 
        // Debug.Log(a.eulerAngles);
        // Debug.Log(a.eulerAngles.y);
        // Debug.Log(a.eulerAngles.z);

    }

    public void OnEndDrag()
    {
        rot = true;
    }

    void MovementOnSoundOn() 
    {
        if(rot)
        {
            // // Круг против часовой стрелки
            Quaternion a = jointImg.transform.rotation;
            Quaternion b = rb.transform.rotation;
            float x_a = a.eulerAngles.x;
            float x_b = b.eulerAngles.x;

            if(Mathf.Round(a.eulerAngles.y) == 180f && Mathf.Round(a.eulerAngles.z) == 90f && Mathf.Round(a.eulerAngles.x) !=0)
            {
                //Значит это угол от 0 до 89 и от 271 до 359
                rb.AddTorque(speed *-1,0,0);
                audioRobot.SetActive(true);
                
                
                if(x_b >= x_a - 1 && x_b <= x_a + 1 && Mathf.Round(b.eulerAngles.y) == 180f && Mathf.Round(b.eulerAngles.z) == 90f)
                {
                    rb.angularVelocity = Vector3.zero;
                    rot = false;
                    audioRobot.SetActive(false);
                }
            }

            if(Mathf.Round(a.eulerAngles.z) == 270 && Mathf.Round(a.eulerAngles.x) !=0)
            {
                //Значит, что угол от 91 до 269
                rb.AddTorque(speed *-1,0,0);
                audioRobot.SetActive(true);

                if(x_b >= x_a - 1 && x_b <= x_a + 1 && Mathf.Round(b.eulerAngles.z) == 270)
                {
                    rb.angularVelocity = Vector3.zero;
                    rot = false;
                    audioRobot.SetActive(false);
                }
            }

            // Угол 90
            if(Mathf.Round(a.eulerAngles.x) == 90 && Mathf.Round(a.eulerAngles.y) == 90 && Mathf.Round(a.eulerAngles.z) == 0)
            {
                rb.AddTorque(speed *-1,0,0);
                audioRobot.SetActive(true);

                if(x_b >= x_a - 1 && x_b <= x_a + 1)
                {
                    rb.angularVelocity = Vector3.zero;
                    rot = false;
                    audioRobot.SetActive(false);
                }

            }    

            //Угол 180
            if(Mathf.Round(a.eulerAngles.x) == 0 && Mathf.Round(a.eulerAngles.y) == 0 && Mathf.Round(a.eulerAngles.z) == 270)
            {
                rb.AddTorque(speed *-1,0,0);
                audioRobot.SetActive(true);

                if(x_b >= x_a - 1 && x_b <= x_a + 1 && Mathf.Round(b.eulerAngles.z) == 270)
                {
                    rb.angularVelocity = Vector3.zero;
                    rot = false;
                    audioRobot.SetActive(false);
                }
            }

            //Угол 270
            if(Mathf.Round(a.eulerAngles.x) == 270 && Mathf.Round(a.eulerAngles.y) == 270 && Mathf.Round(a.eulerAngles.z) == 0) 
            {
                rb.AddTorque(speed *-1,0,0);
                audioRobot.SetActive(true);

                if(x_b >= x_a - 1 && x_b <= x_a + 1 && Mathf.Round(b.eulerAngles.z) == 270)
                {
                    rb.angularVelocity = Vector3.zero;
                    rot = false;
                    audioRobot.SetActive(false);
                }

            }

            // Угол 360(0)
            if (Mathf.Round(a.eulerAngles.x) == 0 && Mathf.Round(a.eulerAngles.y) == 180 && Mathf.Round(a.eulerAngles.z) == 90)
            {
                rb.AddTorque(speed *-1,0,0);
                audioRobot.SetActive(true);

                if(x_b >= x_a - 2 && x_b <= x_a + 2 && Mathf.Round(b.eulerAngles.x) == 0 && Mathf.Round(b.eulerAngles.y) == 180 && Mathf.Round(b.eulerAngles.z) == 90)
                {
                    rb.angularVelocity = Vector3.zero;
                    rot = false;
                    audioRobot.SetActive(false);
                }
               
            }

        }

    }
}








// First obtion

// public class Movement : MonoBehaviour
// {
//     public Slider mainSlider;
//     public GameObject Joint;
//     // public GameObject Angle;
//     // public GameObject angleInteractive;
//     // public InputField mainInputField;
//     private string input;
//     public Text jointText;
//     public AudioSource m_MyAudioSource;


//     void Start()
//     {}

//     void Update()
//     {
//         float x_1 = Joint.transform.rotation.eulerAngles.x;
//         Rot(x_1);   
//     }

//     //Rotatation through slider
//     void Rot(float x_1)
//     {
//         Joint.transform.rotation = Quaternion.Euler(mainSlider.value, 180, 0);
//         jointText.text = "Joint: " + mainSlider.value.ToString();

//         float x_2 = Joint.transform.rotation.eulerAngles.x;

//         if (x_2 - x_1 != 0)
//         {
//             // Debug.Log(Joint.transform.rotation.eulerAngles.x);
//             m_MyAudioSource.Play();
//         } 

//     }

// }
