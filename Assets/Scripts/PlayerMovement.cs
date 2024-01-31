using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;



public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    private int score = 0;
    private int tim = 3;
    public Text txtScore;
    public Text txtTim;
    public GameObject panelEndGame;
    public GameObject panelWinGame;
    public Text txtDiemSo;

    Rigidbody2D rb;


    public AudioClip playerJump;
    public AudioClip collectCoin;
    public AudioClip nhacnen;
    public AudioClip ATchienthang;
    public AudioClip ATthatbai;

    private AudioSource audioSource;




    void Start()
    {

        audioSource =GetComponent<AudioSource>();

        txtScore = GameObject.Find("txtDiem").GetComponent<Text>();
        txtTim = GameObject.Find("txtMang").GetComponent<Text>();

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        txtDiemSo = panelWinGame.GetComponentInChildren<Text>();

        audioSource.PlayOneShot(nhacnen);
    }


     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TagCoin")
        {
            VaChamCoin(collision);

        }

        if (collision.gameObject.tag == "TagEmety")
        {
            VaChamEmety(collision);

        }

    }


    void OnCollisionEnter2D(Collision2D collision)
    {

      
        if (collision.gameObject.tag == "TagCNV")
        {
            VaChamCNV(collision);

        }
       


        if (collision.gameObject.tag == "Finish")
        {
            panelWinGame.SetActive(true);
            Time.timeScale = 0f;
            UpdateScoreText();
            audioSource.Stop();
            audioSource.PlayOneShot(ATchienthang);
        }
    }

    public void chuyenScene()
    {
        panelWinGame.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("man1");
    }


    void VaChamEmety(Collider2D collision)
    {
        tim--;
        UpdateScoreText();

        if (tim == 0)
        {
            panelEndGame.SetActive(true);
            Time.timeScale = 0f;
            audioSource.Stop();
            audioSource.PlayOneShot(ATthatbai);

        }

    }
    void VaChamCNV(Collision2D collision)
    {
        tim--;
        UpdateScoreText();

        if (tim == 0)
        {
            panelEndGame.SetActive(true);
            Time.timeScale = 0f;
            audioSource.Stop();
            audioSource.PlayOneShot(ATthatbai);

        }

    }

    public void RestartScene()
    {
        panelEndGame.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    void VaChamCoin(Collider2D collision)
    {
        score++;
        audioSource.PlayOneShot(collectCoin);
        Destroy(collision.gameObject);
        UpdateScoreText();
        
    }

    void UpdateScoreText()
    {
        txtScore.text = "x" + score.ToString();
        txtTim.text = "x" + tim.ToString();
        txtDiemSo.text = "Điểm số: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            audioSource.PlayOneShot(playerJump);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

   
}