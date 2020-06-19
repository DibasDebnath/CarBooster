using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    Controller inputAction;

    public bool tap;
    public bool move;
    

    public Vector2 preTouchPosition;
    public Vector2 touchPosition;

    public Vector2 oldTouchPosition;

    private void Awake()
    {
        instance = this;
        inputAction = new Controller();
        inputAction.Player.TouchStart.performed += ctx => tap = true;
        inputAction.Player.TouchEnd.performed += ctx => tap = false;
        inputAction.Player.TouchMove.performed += ctx => preTouchPosition = ctx.ReadValue<Vector2>();
        
    }
    private void Start()
    {
        tap = false;
        move = false;
    }
    private void Update()
    {
        
;   }
    private void FixedUpdate()
    {
        if (tap)
        {
            touchPosition.x = preTouchPosition.x / Screen.width;
            touchPosition.y = preTouchPosition.y / Screen.height;
            if(oldTouchPosition.x == touchPosition.x)
            {
                move = false;
            }
            else if(oldTouchPosition.x != touchPosition.x || oldTouchPosition.y != touchPosition.y)
            {
                move = true;
            }
            else
            {
                move = false;
            }

            oldTouchPosition.x = touchPosition.x;
            oldTouchPosition.y = touchPosition.y;
        }
        else
        {
            touchPosition.x = 0;
            touchPosition.y = 0;
            oldTouchPosition.x = 0;
            oldTouchPosition.y = 0;
            move = false;
        }
            
    }

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }
}
