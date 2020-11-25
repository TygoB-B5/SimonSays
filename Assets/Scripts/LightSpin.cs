using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpin : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.up * 360 * Time.deltaTime);
    }
}
