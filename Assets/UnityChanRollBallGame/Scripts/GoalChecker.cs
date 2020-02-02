using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalChecker : MonoBehaviour
{
    private const string STAGE1 = "Stage1";
    private const string STAGE2 = "Stage2";
    private const string RESULT = "Result";

    public GameObject unityChan;
    public AudioSource gameBGM;
    public AudioSource goalBGM;
    public GameObject retryButton;
    public GameObject player;
    public GameObject timer;

    private void Start()
    {
        retryButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Rigidbody>().isKinematic = true;
        unityChan.transform.LookAt(Camera.main.transform);
        unityChan.GetComponent<Animator>().SetTrigger("Goal");
        player.GetComponent<PlayerController>().enabled = false;
        timer.GetComponent<Timer>().enabled = false;

        gameBGM.Stop();
        goalBGM.Play();

        retryButton.SetActive(true);
    }

    public void RetryStage()
    {
        if (SceneManager.GetActiveScene().name == STAGE1)
        {
            SceneManager.LoadScene(STAGE2);
        }
        else if (SceneManager.GetActiveScene().name == STAGE2)
        {
            SceneManager.LoadScene(RESULT);
        }
        
    }
}
