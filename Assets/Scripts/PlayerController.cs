using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class PlayerController : MonoBehaviour
{
    private float deaths;
    private float deathPref;

    public Shake shaker;
    public GameObject ripple;

    public float moveSpeed;
    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedMilestoneCount;

    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;

    private Rigidbody2D rb2d;

    public bool grounded;
    public LayerMask ground;

    private Collider2D myCollider;

    public float knockbackCount;
    public float counter;

    private float scorenumber = 0;
    public Text score;

    public Animator animator;

    public Collider2D physicalCollider;

    public AudioClip JumpSound;
    public AudioSource AudioSource;

    private float highScore;

    public Canvas gameOverCanvas;
    public Text finalScoreDisplay;
    public Text highScoreDisplay;

    private InterstitialAd AD;


    [SerializeField] private string appID = "ca-app-pub-4049453727836488~9418740234";

    [SerializeField] private string regularAD = "ca-app-pub-4049453727836488/4607243164";

    // Start is called before the first frame update
    private void Awake()
    {
        MobileAds.Initialize(appID);
    }

    void Start()
    {
        
        RequestRegularAD();

        highScore = PlayerPrefs.GetFloat("Highscore");

        animator = this.gameObject.GetComponent<Animator>();

        rb2d = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        jumpTimeCounter = jumpTime;

        speedMilestoneCount = speedIncreaseMilestone;

        AudioSource.clip = JumpSound;

        deaths = PlayerPrefs.GetFloat("Deaths");
    }

    // Update is called once per frame
    void Update()
    {
        

        score.text = scorenumber.ToString();

        grounded = Physics2D.IsTouchingLayers(myCollider, ground);

        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;


            speedIncreaseMilestone += speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }


        rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);

        if (grounded)
        {
            ripple.SetActive(true);
        }
        else
        {
            ripple.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {

                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);

                AudioSource.Play();


            }

        }
        if (Input.GetKey(KeyCode.Z))
        {
            if (grounded)
            {

                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce + 8);
                AudioSource.Play();

            }

        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero);
            if (hit.collider != null)
            {
                if (grounded)
                {
                    //Touch touch = Input.GetTouch(0);
                    //Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                    if (hit.collider.name == "JumpTouchZone")
                    {
                        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);

                        AudioSource.Play();

                    }

                }


                if (hit.collider.name == "JumpTouchZone" && Input.GetMouseButton(0))
                {
                    if (jumpTimeCounter > 0)
                    {
                        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
                        jumpTimeCounter -= Time.deltaTime;
                    }
                }


            }
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
            {
                jumpTimeCounter = 0;
            }


        }
        if (grounded)
        {
            jumpTimeCounter = jumpTime;
        }







    }

    //Player Touches Enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Enemy"))
        {
            deaths++;
            shaker.GetComponent<Shake>().ShakeObj();
            Destroy(ripple);
            Destroy(physicalCollider);
            Destroy(this);

            PlayerPrefs.SetFloat("Score", scorenumber);


            if (scorenumber > highScore)
            {
                highScore = scorenumber;
                PlayerPrefs.SetFloat("Highscore", scorenumber);
            }

            Debug.Log(PlayerPrefs.GetFloat("Score"));
            Debug.Log(PlayerPrefs.GetFloat("Highscore"));

            Time.timeScale = 0;
            gameOverCanvas.gameObject.SetActive(true);
            finalScoreDisplay.text = scorenumber.ToString();
            highScoreDisplay.text = highScore.ToString();

            Debug.Log(deaths);
            PlayerPrefs.SetFloat("Deaths", deaths);
            deathPref = PlayerPrefs.GetFloat("Deaths");
            if (deathPref >= 1)
            {
                deaths = 0;
                PlayerPrefs.SetFloat("Deaths", 0);
                Debug.Log("Playing Ad");
                if (this.AD.IsLoaded())
                {
                    this.AD.Show();
                }




            }

        }


    }
    public void scoreAddFromEnemyDying()
    {
        scorenumber++;
        score.text = scorenumber.ToString();
    }

    private void RequestRegularAD()
    {


#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.AD = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.AD.LoadAd(request);
    }




}
