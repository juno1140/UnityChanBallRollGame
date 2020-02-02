using UnityEngine;

public class Ground : MonoBehaviour
{
    // Groundのタグの種類
    private const string RY = "RotationY";
    private const string PXTL = "PositionXToLeft";
    private const string PXTR = "PositionXToRight";
    private const string PYTU = "PositionYToUp";
    private const string PYTD = "PositionYToDown";

    private const int MAX_POSITION = 5; // 最大移動距離

    public float speed = 80;
    private float preAngle; // 前フレーム時の角度
    public int maxWaitTime; // 待ち時間
    private int waitTime;

    private float groundPositionX;
    private float groundPositionY;
    private bool sw; // 切替スイッチ
    public float l = 5; // 移動距離

    void Start()
    {
        preAngle = 0;
        waitTime = 0;
        groundPositionX = transform.position.x;
        groundPositionY = transform.position.y;

        if (gameObject.CompareTag(RY) || gameObject.CompareTag(PXTL) || gameObject.CompareTag(PYTU))
        {
            sw = true;
        }
        else if (gameObject.CompareTag(PXTR) || gameObject.CompareTag(PYTD))
        {
            sw = false;
        }
    }

    void Update()
    {
        if (gameObject.CompareTag(RY))
        {
            GroundTransformRotationY();
        }
        else if (gameObject.CompareTag(PXTL) || gameObject.CompareTag(PXTR))
        {
            GroundTransformPositionX();
        }
        else if (gameObject.CompareTag(PYTU) || gameObject.CompareTag(PYTD))
        {
            GroundTransformPositionY();
        }
    }

    /// <summary>
    /// 地面をY方向に回転させる
    /// 180°回転ごとに停止する時間を作る
    /// </summary>
    private void GroundTransformRotationY()
    {
        float groundAngleY = transform.localEulerAngles.y % 180;

        if (preAngle <= groundAngleY)
        {
            TransformRotationY(speed);
            preAngle = groundAngleY;
        }
        else
        {
            if (waitTime <= maxWaitTime)
            {
                waitTime++;
            }
            else
            {
                preAngle = groundAngleY;
                waitTime = 0;
            }
        }
    }

    /// <summary>
    /// 地面をX方向に移動させる()
    /// </summary>
    private void GroundTransformPositionX()
    {
        if (sw)
        {
            TransformPositionX(l);

            if (transform.position.x > groundPositionX + MAX_POSITION)
            {
                sw = false;
            }
        }
        else
        {
            TransformPositionX(-l);

            if (transform.position.x < groundPositionX - MAX_POSITION)
            {
                sw = true;
            }
        }
    }

    /// <summary>
    /// 地面をY方向に移動させる()
    /// </summary>
    private void GroundTransformPositionY()
    {
        if (sw)
        {
            TransformPositionY(l);

            if (transform.position.y > groundPositionY + MAX_POSITION)
            {
                sw = false;
            }
        }
        else
        {
            TransformPositionY(-l);

            if (transform.position.y < groundPositionY - MAX_POSITION)
            {
                sw = true;
            }
        }
    }

    /// <summary>
    /// X方向に移動させる
    /// </summary>
    /// <param name="x">1秒間に移動させる距離</param>
    private void TransformPositionX(float x)
    {
        transform.position += new Vector3(x, 0) * Time.deltaTime;
    }

    /// <summary>
    /// Y方向に移動させる
    /// </summary>
    /// <param name="y">1秒間に移動させる距離</param>
    private void TransformPositionY(float y)
    {
        transform.position += new Vector3(0, y) * Time.deltaTime;
    }

    /// <summary>
    /// Y方向に回転させる
    /// </summary>
    /// <param name="y">1秒間に回転させる角度</param>
    private void TransformRotationY(float y)
    {
        transform.Rotate(new Vector3(0, y) * Time.deltaTime);
    }
}
