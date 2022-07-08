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
        if (collision.gameObject.name == "BrickPrefab(Clone)")
        {
            newColor = collision.gameObject.GetComponent<MeshRenderer>().material.color;
        }

    }
}
