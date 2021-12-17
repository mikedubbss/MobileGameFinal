using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class car_Move : MonoBehaviour
{

    //private bool startingMenu;

    private Rigidbody playerRB;
    private Animator playerAnim;
    public bool stopScrolling;
    public float maxHealth = 40.0f;
    public float currentHealth;
    public bool isOnGround = true;
    public bool losingGas = true;
    public healthSlider healthBar;
    public int positionCounter;
    
    public bool startRestart;

    //public ParticleSystem explosionParticle;
    //public ParticleSystem dirtParticle;

    private Vector2 startTouchPosition, endTouchPosition;
    public bool gameOver;
    private int coin = 0;
    public TextMeshProUGUI textForCoins;
    public TextMeshProUGUI totalCoins;
 
    public GameObject carGameObject;

    public GameObject restartScreen;

    private PauseMenu pause_menu;

    public GameObject pause_Button;

    // Start is called before the first frame update
    void Start()
    {
        //startingMenu = true;

        pause_menu = GameObject.Find("PauseScreen").gameObject.GetComponent<PauseMenu>();

        positionCounter = 0;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        //restartScreen.SetActive() = true;

        //GameObject.Find("GameOverScreen").SetActive(false);
        playerRB = GetComponent<Rigidbody>();
        carGameObject = GetComponent<GameObject>();
        playerAnim = GetComponent<Animator>();
        //restartScreen = GetComponent<GameObject>();
        //Physics.gravity *= gravityModifier;

        losingGas = true;

        totalCoins.text = PlayerPrefs.GetInt("textForCoins", 0).ToString();

        //pause_Button.SetActive(true);
        //restartScreen.SetActive(false);
    }

    // Update is called once per frame

    public void KeepCoins()
    {
        PlayerPrefs.SetInt("textForCoins", coin);
        totalCoins.text = textForCoins.ToString();
    }

    void Update()
    {

        if (!stopScrolling)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                startTouchPosition = Input.GetTouch(0).position;

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endTouchPosition = Input.GetTouch(0).position;


                if ((endTouchPosition.x < startTouchPosition.x) && transform.position.x >= -1.22f)
                    transform.position = new Vector2(transform.position.x - 1.22f, transform.position.y);


                if ((endTouchPosition.x > startTouchPosition.x) && transform.position.x <= 0.59f)
                    transform.position = new Vector2(transform.position.x + 1.22f, transform.position.y);


                UnityEngine.Debug.Log("PleaseWork");
            }
        }

        //if (!pause_menu.paused)
        //{
            if (losingGas == true)
            {
                if (!pause_menu.paused)
                {
                    TakeDamage(0.007f);
                }
                //healthBar.value = health;
            }

            else if (currentHealth <= 0.0f)
            {
                UnityEngine.Debug.Log("NoMoreGas");
                //losingGas = false;
            }
        //}



        //if (!pause_menu.paused)
        //{
        //    //slider.value = health;
        //    if (losingGas == true)
        //    {
        //        TakeDamage(0.007f);
        //    }


    }


    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealthBar(currentHealth);

        if (currentHealth <= 0.0f)
        {
            UnityEngine.Debug.Log("NoMoreGas");
            losingGas = false;
            StartCoroutine(your_timer());
            StartCoroutine(stop_scrolling());
        }

        IEnumerator your_timer()
        {

            //playerAnim.SetTrigger("CarCrash");
            yield return new WaitForSeconds(0.23f);
            //pause_Button.SetActive(false);
            startRestart = true;
            restartScreen.gameObject.SetActive(true);
            //Time.timeScale = 0;

        }

        IEnumerator stop_scrolling()
        {
            yield return new WaitForSeconds(0.06f);
            stopScrolling = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coins")
        {
            coin += 1;
            textForCoins.text = coin.ToString();

            Destroy(other.gameObject);

        }

        if (other.tag == "CoinGroup")
        {
            coin += 3;
            textForCoins.text = coin.ToString();
            Destroy(other.gameObject);
        }

        //THIS IS FOR THE FUEL WILL CHANGE THIS LATER
        if (other.tag == "Obstacle")
        {
            if (currentHealth <= maxHealth)
            {
                currentHealth = currentHealth + 5.0f;
                healthBar.SetMaxHealth(maxHealth);
                //currentHealth = Mathf.Clamp(currentHealth + maxHealth, 5, currentHealth);
                //healthBar.SetMaxHealth(maxHealth);
            }

            if (currentHealth >= maxHealth)
            {
                //currentHealth = currentHealth + 5.0f;
                //healthBar.SetMaxHealth(maxHealth);
                currentHealth = Mathf.Clamp(currentHealth + maxHealth, 0, maxHealth);
                healthBar.SetMaxHealth(maxHealth);
            }
            //if ((currentHealth == 40) && (other.tag == "Obstacle"))
            //{
            //currentHealth = currentHealth + 0;
            //healthBar.SetMaxHealth(maxHealth);
            //}
            //else if (currentHealth >= maxHealth)
            //{
            //healthBar.SetMaxHealth(maxHealth);
            //}

            Destroy(other.gameObject);
        }

        if (other.tag == "Enemy")
        {
            losingGas = false;

            StartCoroutine(your_timer());
            StartCoroutine(stop_scrolling());
            
        }


        //else
        //{
            //UnityEngine.Debug.Log("NOT PAUSED");
            //losingGas = true;
            //stopScrolling = false;
        //}

        IEnumerator your_timer()
        {

            //playerAnim.SetTrigger("CarCrash");
            yield return new WaitForSeconds(0.23f);
            startRestart = true;
            restartScreen.gameObject.SetActive(true);
            


        }

        IEnumerator stop_scrolling()
        {
            yield return new WaitForSeconds(0.06f);
            stopScrolling = true;
        }

    }

    //public void KeepCoins()
    //{
    //    totalCoins.text = coin.ToString();
    //    PlayerPrefs.SetInt("CoinAmount", coin);
    //}

    // private void OnCollisionEnter(Collision collision)
    // {

    //if (collision.gameObject.CompareTag("Ground"))
    //{
    //isOnGround = true;
    //dirtParticle.Play();
    //}

    //if(collision.gameObject.CompareTag("Enemy"))
    // {
    //Destroy(gameObject);
    //}

    //else if (collision.gameObject.CompareTag("Obstacle"))
    //{
    //UnityEngine.Debug.Log("Game Over Man!");
    //gameOver = true;
    //playerAnim.SetBool("Death_b", true);
    //playerAnim.SetInteger("DeathType_int", 1);
    //explosionParticle.Play();
    //dirtParticle.Stop();
    //playerAudio.PlayOneShot(crashSound, 0.5f);
    //}
    //}

}
