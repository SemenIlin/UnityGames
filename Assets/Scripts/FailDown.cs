using UnityEngine;

public class FailDown : MonoBehaviour
{
    [SerializeField]
    private float failSpeed;

    void Update()
    {
        failSpeed = Random.Range(3.0f, 4.5f);
        if (transform.gameObject.tag == "Coins")
        {
            transform.Rotate(0, 2.0f, 0);
        }

        if ((transform.gameObject.tag == "Coins") && (Moving.Coins > SpawnCoins.THIRD_LEVEL))
        {
            Destroy(transform.gameObject);
        }

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }

        transform.position -= new Vector3(0, failSpeed * Time.deltaTime, 0);
    }
}
