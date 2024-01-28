using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject weapon;
    public static float speed = -5f;
    public static bool isFlipped = false;
    public float range = 180f;
    private Quaternion startingRotation;
    private bool attackBool = false;
    private bool using2D;
    // Start is called before the first frame update
    void Start()
    {
        startingRotation = weapon.transform.rotation;
        using2D = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            using2D = using2D==true?false:true;
        }
        if (Input.GetKeyDown(KeyCode.Z) && using2D && !attackBool)
        {
            Debug.Log("pressing z");
            weapon.transform.rotation = startingRotation;
            weapon.SetActive(true);
            attackBool = true;
            
        }
        if (attackBool)
        {
            if (!isFlipped)
            {
                if (weapon.transform.eulerAngles.z < startingRotation.eulerAngles.z + range)
                {
                    weapon.transform.Rotate(0f, 0f, speed);
                    Debug.Log(weapon.transform.eulerAngles.z);
                    Debug.Log(startingRotation.eulerAngles.z);
                }
                else
                {
                    weapon.SetActive(false);
                    attackBool = false;
                }
            }
            else
            {
                if (weapon.transform.eulerAngles.z > startingRotation.eulerAngles.z - range)
                {
                    weapon.transform.Rotate(0f, 0f, speed);
                    Debug.Log(weapon.transform.eulerAngles.z);
                    Debug.Log(startingRotation.eulerAngles.z);
                }
                else
                {
                    weapon.SetActive(false);
                    attackBool = false;
                }
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (attackBool && collision.gameObject.CompareTag("Branch"))
        {
            BreakBranch.isBreaking=true;
        }
        
    }
}
