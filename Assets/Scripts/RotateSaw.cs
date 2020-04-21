using UnityEngine;

public class RotateSaw : MonoBehaviour
{
    private readonly float speed = 2f;
   
    void Update()
    {
        if (transform.position.x > 5f)
        {
            Destroy(gameObject);
        }

        transform.Rotate(0, 0, 2.0f);
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}

