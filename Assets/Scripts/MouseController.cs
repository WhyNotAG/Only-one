using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {
    
    public enum MouseAxis {
        MouseX = 1,
        MouseY = 2,
    }

    public float verticalSens = 6.0f;
    public float horizontalSens = 6.0f;

    public MouseAxis mouseAxis = MouseAxis.MouseX;

    private float _minVertical = -35.0f;
    private float _maxVertical = 45.0f;

    private float _rotationX = 0.0f;
    private float _rotationY = 0.0f;
    

    // Update is called once per frame
    void Update() {
        if(mouseAxis == MouseAxis.MouseX) {
            transform.Rotate(0, Input.GetAxis("Mouse X") * horizontalSens, 0);
        } else if (mouseAxis == MouseAxis.MouseY) {
            _rotationX -= Input.GetAxis("Mouse Y") * verticalSens;
            _rotationX = Mathf.Clamp(_rotationX, _minVertical, _maxVertical);

            _rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
    }
}
