using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    private void Awake()
    {
        _camera =  Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if(!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_camera.ScreenPointToRay(pos: (Vector3)Mouse.current.position.ReadValue()));
        if (rayHit.collider)
        {
            Debug.Log(rayHit.collider.gameObject.name);
        }
        else
        {
            Debug.Log("oops");
        }

        
    }
}
