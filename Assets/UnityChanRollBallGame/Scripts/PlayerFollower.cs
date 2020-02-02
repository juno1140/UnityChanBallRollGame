using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = this.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position + offset;
    }
}
