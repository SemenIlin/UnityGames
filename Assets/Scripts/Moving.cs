using UnityEngine;

public class Moving : MonoBehaviour
{
    private Rigidbody2D rb;

    public AudioClip coinSound;
    public AudioClip trapSound;
    public Transform groundCheckPoint;
    public LayerMask groundLayer;
    public GameObject restart;
    public static bool Life = true;
    public bool isTouchingGround;

    public static int Coins = 0;
    public static int Score = 0;

    private float speed = 8.0f;
    private string tx;
    private string tx1;

   // private readonly float groundRadius = 0.2f;//without double jump   
    private float horisontal; // akselerometr

    private void Awake()
    {
        Life = true;
        Coins = 0;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position,groundRadius, groundLayer); // jump with tab on screen
        //if (Input.GetKeyDown(KeyCode.Space) && isTouchingGround)
        //{
        //    Jump();
        //}
    }

    void FixedUpdate()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            horisontal = Input.acceleration.x;
        }
        else
        {
            horisontal = Input.GetAxis("Horizontal");
        }
        if (Life)
        {
            rb.velocity = new Vector2(horisontal * 14f, rb.velocity.y);
        }
    }

    public void Jump()
    {
        if (Life == true)
        {
            rb.AddForce(transform.up * 8f, ForceMode2D.Impulse);
        }
    }
     
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Platform") && Life)
        {     
            rb.velocity = Vector2.zero;
            rb.AddForce(transform.up * 8f, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Coins" || collision.gameObject.tag == "CoinsMove")
        {
            Coins++;
            Destroy(collision.gameObject);
            GetComponent<AudioSource>().PlayOneShot(coinSound);
        }

        if (collision.gameObject.tag == "Trap")
        {
            Life = false;
            Score = SetScopeCoins(Coins);
            GetComponent<AudioSource>().PlayOneShot(trapSound);
            restart.SetActive(true);
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 450, 60), $"<color=black><size=40> Coins: {Coins} Score: {Score} </size></color>");
    }

    private int SetScopeCoins(int coins)
    {        
        if (Score < coins)
        {
            return coins;
        }
        else
        {
            return Score;
        }
    }
}
