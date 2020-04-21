using System.Collections;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    public GameObject coin;
    public GameObject coinMove;
    public GameObject trap;
    public GameObject saw;
    GameObject coinOnScreen;

    public const int FIRST_LEVEL = 10;
    public const int SECOND_LEVEL = 20;
    public const int THIRD_LEVEL = 30;

    private const float LEFT_BOARD = -3.0f;
    private const float RIGHT_BOARD = 3.0f;
    private const float HIGHT = 6.0f;
    private const float BUTTON = -4.0f;
    
    void Start()
    {
        StartCoroutine(GenerateCoins(coin));
    }

    private void Update()
    {
        if (Moving.Coins == THIRD_LEVEL)
        {
            Moving.Coins++;
            coinOnScreen = coinMove;
            StartCoroutine(GenerateCoins(coinOnScreen));
        }

        if (Moving.Coins == FIRST_LEVEL)
        {
            Moving.Coins++;
            StartCoroutine(GenerateTraps());
        }

        if (Moving.Coins == SECOND_LEVEL)
        {
            Moving.Coins++;
            StartCoroutine(GenerateSaws());
        }
    }

    IEnumerator GenerateCoins(GameObject coinOnScreen)
    {    
        while (Moving.Life)
        {
            Instantiate(coinOnScreen, new Vector2(Random.Range(LEFT_BOARD, RIGHT_BOARD), HIGHT), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1.6f, 2.8f));
        }
    }

    IEnumerator GenerateTraps()
    {
        while (Moving.Life)
        {
            Instantiate(trap, new Vector2(Random.Range(LEFT_BOARD, RIGHT_BOARD), HIGHT), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(2.5f, 3.3f));
        }
    }

    IEnumerator GenerateSaws()
    {
        while (Moving.Life)
        {
            Instantiate(saw, new Vector2(LEFT_BOARD, Random.Range(BUTTON, BUTTON + 0.5f)), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(2.2f, 3.8f));
        }
    }
}
