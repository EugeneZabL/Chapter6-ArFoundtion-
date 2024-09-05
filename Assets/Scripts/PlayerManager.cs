using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{

    public GameObject ButtonPlay, ButtonPause;

    [SerializeField]
    Animator _anim;


    void Update()
    {
        TapReyCast();
    }

    void TapReyCast()
    {
        
        // ���������, ���� �� ������� �� �����
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            // �������� ������� �������
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

            // ������� ��� �� ������� �������
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
            RaycastHit hit;

           // Debug.Log(touchPosition);
            // ���������, �������� �� ��� � ������ � Collider
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("ok");
                ButtonsController button = hit.collider.GetComponent<ButtonsController>();
                // ���� ������ ��� �����, �������� ��������������� �����
                if (button != null)
                {
                    button.SendMessage("OnAction");
                }
            }
        }
    }

    public void ChangeAnimation(bool state)
    {
        if (state)
            _anim.Play("Dance");
        else
            _anim.Play("Idle");
    }
}

