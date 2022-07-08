using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColliding : MonoBehaviour
{
    public MainManager mainManager;
    public static Color newColor;

    private void Awake()
    {
        if (mainManager != null)
        {
            mainManager.GetComponent<MainManager>();

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        
            if (collision.gameObject.CompareTag("Brick"))
            {
            newColor = collision.gameObject.GetComponent<Renderer>().material.color;
                Debug.Log("Touched the color: " + newColor);
            }
        


        
    }
}
