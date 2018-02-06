using UnityEngine;
using System.Collections;

public class WiggleLight: MonoBehaviour
{

    public float Smooth = 5;
    public float bobSpeed = 0.25f;
    public float bobAmount = 0.005f;

    private float defCamPos = 0;
    private float timer = 0.0f;
    private float camPos;
    private float waveslice;
    private float translateChange;
    private float totalAxes;
    private Transform MyTransform;

    void Start()
    {
        MyTransform = transform;
        defCamPos = MyTransform.localPosition.y;
        camPos = defCamPos;
    }

    void Update()
    {
        Vector3 camHeight = new Vector3(MyTransform.localPosition.x, camPos, MyTransform.localPosition.z);
        Vector3 smoothHeight = Vector3.Lerp(MyTransform.localPosition, camHeight, Time.deltaTime * Smooth);
        MyTransform.localPosition = smoothHeight;

        waveslice = 0.0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0)
        {
            timer = 0.0f;
        }
        else
        {
            waveslice = Mathf.Sin(timer);
            timer = timer + bobSpeed;
            if (timer > Mathf.PI * 2)
            {
                timer = timer - (Mathf.PI * 2);
            }
        }
        if (waveslice != 0)
        {
            translateChange = waveslice * bobAmount;
            totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
            translateChange = totalAxes * translateChange;
            MyTransform.localPosition = new Vector3(MyTransform.localPosition.x, smoothHeight.y + translateChange, MyTransform.localPosition.z);
        }
        else
        {
            MyTransform.localPosition = new Vector3(MyTransform.localPosition.x, smoothHeight.y, MyTransform.localPosition.z);
        }
    }
}