using UnityEngine;
using System;

public class GetColorInput : MonoBehaviour
{
    private Camera cam;
    public SColor color { get; private set; }

    public event Action<SColor> OnClickOnColor = delegate { };

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ShootRay();
    }

    private void ShootRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, cam.ScreenPointToRay(Input.mousePosition).direction, out hit, Mathf.Infinity))
        {
            if (hit.transform.name == "Red")
            {
                GetComponent<SoundHandler>().PlaySound("bleep1");
                color = SColor.Red;
                OnClickOnColor(color);
            }
            else if (hit.transform.name == "Green")
            {
                GetComponent<SoundHandler>().PlaySound("bleep2");
                color = SColor.Green;
                OnClickOnColor(color);
            }
            else if (hit.transform.name == "Blue")
            {
                GetComponent<SoundHandler>().PlaySound("bleep3");
                color = SColor.Blue;
                OnClickOnColor(color);
            }
            else if (hit.transform.name == "Yellow")
            {
                GetComponent<SoundHandler>().PlaySound("bleep4");
                color = SColor.Yellow;
                OnClickOnColor(color);
            }
        }
    }
}
