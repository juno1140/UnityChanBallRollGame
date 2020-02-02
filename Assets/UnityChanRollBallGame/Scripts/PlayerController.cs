using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    Vector3 startPosition;
    Rigidbody rb;
    public float speed;
    static int score;
    public Text scoreText;
    AudioSource getSE;
    public GameObject unityChan;

    // スコアを取得する
    public static int getScore()
    {
        return score;
    }

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        score = getScore();
        SetScoreText();
        getSE = GetComponent<AudioSource>();
    }

    // PCの性能に依存せずフレームレートが固定されている
    void FixedUpdate()
    {
        float moveH = CrossPlatformInputManager.GetAxis("Horizontal");
        float moveV = CrossPlatformInputManager.GetAxis("Vertical");

        unityChan.transform.LookAt(unityChan.transform.position + new Vector3(moveH, 0, moveV));

        Vector3 move = new Vector3(moveH, 0, moveV);
        rb.AddForce(move * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bottom"))
        {
            // 初期位置に戻す
            transform.position = startPosition;
            // Playerの動きを一度止める
            rb.isKinematic = true;
            rb.isKinematic = false;
            // キャラクターの向きを変える
            unityChan.transform.rotation = Quaternion.LookRotation(Vector3.zero);
        }
        else if (other.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
            score += 100;
            SetScoreText();
            getSE.Play();
        }

    }

    private void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
