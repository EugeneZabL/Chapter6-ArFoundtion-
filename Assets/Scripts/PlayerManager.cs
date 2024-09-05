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
        
        // Проверяем, было ли нажатие на экран
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            // Получаем позицию нажатия
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

            // Создаем луч из позиции нажатия
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
            RaycastHit hit;

           // Debug.Log(touchPosition);
            // Проверяем, попадает ли луч в объект с Collider
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("ok");
                ButtonsController button = hit.collider.GetComponent<ButtonsController>();
                // Если объект был нажат, вызываем соответствующий метод
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

