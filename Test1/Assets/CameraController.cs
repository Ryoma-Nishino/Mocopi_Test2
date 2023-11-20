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
        // WASDでの移動
        float xAxisValue = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float zAxisValue = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(new Vector3(xAxisValue, 0.0f, zAxisValue));

        // Eで上昇、Qで下降
        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }

        // 右クリックを押しながらマウス移動でカメラの向きを変更
        if (Input.GetMouseButtonDown(1))
        {
            // マウスの位置を保存
            mouseOrigin = Input.mousePosition;
            isRotating = true;
        }

        if (!Input.GetMouseButton(1)) isRotating = false;

        if (isRotating)
        {
            // マウスの現在位置と最初の位置との差を計算
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            // マウスの移動量に基づいて新しい角度を設定
            Vector3 move = new Vector3(-pos.y * sensitivity, pos.x * sensitivity, 0);

            // 回転角度を更新
            transform.Rotate(move, Space.Self);
        }
    }
}
