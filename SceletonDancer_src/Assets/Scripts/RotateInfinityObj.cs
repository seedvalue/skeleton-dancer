using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Sergey : Just simple rotator, use any when need simple infinity rotation
/// </summary>
public class RotateInfinityObj : MonoBehaviour
{

    public float Speed = 1F;

    public bool IsRight = true;
    public bool IsLeft = false;
    public bool IsForward = false;
    public bool IsBack = false;
    public bool IsDown = false;
    public bool IsUp = false;



    void Update()
    {

        if (IsRight)
        {
            transform.Rotate(Vector3.right * Time.deltaTime * Speed);
        }

        if (IsLeft)
        {
            transform.Rotate(-Vector3.right * Time.deltaTime * Speed);
        }

        if (IsForward)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * Speed);
        }

        if (IsBack)
        {
            transform.Rotate(-Vector3.forward * Time.deltaTime * Speed);
        }

        if (IsDown)
        {
            transform.Rotate(Vector3.down * Time.deltaTime * Speed);
        }

        if (IsUp)
        {
            transform.Rotate(-Vector3.down * Time.deltaTime * Speed);
        }
    }
}
