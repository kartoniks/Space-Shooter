using UnityEngine;
using System.Collections;

public class AccelerometerInput : MonoBehaviour
{
    public static float GetAxis()
    {

        return Input.acceleration.x;
    }
    //void Update()
    //{
    //    transform.Translate(Input.acceleration.x, 0, 0);
    //}
}