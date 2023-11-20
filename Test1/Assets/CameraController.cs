using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 10.0f;
    public float sensitivity = 1.0f;

    private Vector3 mouseOrigin;
    private bool isRotating;

    void Update()
    {
        // WASD�ł̈ړ�
        float xAxisValue = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float zAxisValue = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(new Vector3(xAxisValue, 0.0f, zAxisValue));

        // E�ŏ㏸�AQ�ŉ��~
        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }

        // �E�N���b�N�������Ȃ���}�E�X�ړ��ŃJ�����̌�����ύX
        if (Input.GetMouseButtonDown(1))
        {
            // �}�E�X�̈ʒu��ۑ�
            mouseOrigin = Input.mousePosition;
            isRotating = true;
        }

        if (!Input.GetMouseButton(1)) isRotating = false;

        if (isRotating)
        {
            // �}�E�X�̌��݈ʒu�ƍŏ��̈ʒu�Ƃ̍����v�Z
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            // �}�E�X�̈ړ��ʂɊ�Â��ĐV�����p�x��ݒ�
            Vector3 move = new Vector3(-pos.y * sensitivity, pos.x * sensitivity, 0);

            // ��]�p�x���X�V
            transform.Rotate(move, Space.Self);
        }
    }
}
