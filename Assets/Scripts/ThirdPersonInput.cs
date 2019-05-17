using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class ThirdPersonInput : MonoBehaviour
{

    public FixedJoystick joystick;
    public Button jump;
    public Button camaras;
    public ThirdPersonUserControl control;
    public Camera main;
    public Camera tres;
    public Camera dos; 

    protected float CameraAngle;
    protected float CameraAngleSpeed;
    private enum Vista{UNO,DOS,TRES};

    // Start is called before the first frame update
    void Start()
    {
        dos.enabled = false;
        tres.enabled = false;
        joystick = GameObject.FindWithTag("Joystick").GetComponent<FixedJoystick>();
        jump.GetComponent<Button>().onClick.AddListener(() => control.m_Jump = true);
        control.GetComponent<ThirdPersonUserControl>();
        camaras.onClick.AddListener(() => ButtonClicked());
    }


    // Update is called once per frame
    void Update()
    {
        control.VInput = joystick.Vertical;
        control.HInput = joystick.Horizontal;
        Debug.Log(joystick.Vertical);
    }

    private Vista vistas = Vista.UNO;
    void ButtonClicked()
    {

        if (vistas == Vista.UNO)
        {
            main.enabled = false;
            dos.enabled = true;
            vistas =  Vista.DOS;
        }
        else 
        if (vistas == Vista.DOS)
        {
            dos.enabled = false;
            tres.enabled = true;
            vistas = Vista.TRES;
        }
        else 
        if (vistas == Vista.TRES)
        {
            tres.enabled = false;
            main.enabled = true;
            vistas = Vista.UNO;
        }
    }
}
