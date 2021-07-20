using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float jumpPower = 10f;
    public string currentColor;
    public float score;

    Rigidbody2D rb;
    SpriteRenderer sr;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI totalScoreText;

    public GameObject one, two, three;
    public GameObject panel;
    public GameObject retryButton;
    public GameObject playButton;

    public Color colorTurquoise;
    public Color colorYellow;
    public Color colorPink;
    public Color colorPlato;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        RandomColor();
        rb.bodyType = RigidbodyType2D.Static;   // Player baþlagýçta sabit kalamsý için statik yapýlýr
        panel.SetActive(false);
        retryButton.SetActive(false);
        playButton.SetActive(false);
    }
    void Update()
    {
        scoreText.text = score.ToString("f0");
        if (Input.GetButtonDown("Jump") || (Input.GetMouseButtonDown(0)))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;  // Player her hangi bir iþlemde hareket eder
            rb.velocity = Vector2.up * jumpPower;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "colorChanger")
        {
            collision.gameObject.transform.position = transform.position + new Vector3(0f,24f,0f);
            one.transform.position = transform.position + new Vector3(0f, 20f, 0f);
            score += 1;
            totalScoreText.text = score.ToString();
            RandomColor();            
            return;
        }
        if (collision.tag == "two")
        {
            collision.gameObject.transform.position = transform.position + new Vector3(0f, 24f, 0f);
            two.transform.position = transform.position + new Vector3(0f, 20f, 0f);
            score += 1;
            totalScoreText.text = score.ToString();
            RandomColor();
            return;
        }
        if (collision.tag == "three")
        {
            collision.gameObject.transform.position = transform.position + new Vector3(0f, 24f, 0f);
            three.transform.position = transform.position + new Vector3(0f, 20f, 0f);
            score += 1;
            totalScoreText.text = score.ToString();
            RandomColor();
            return;
        }
        if (collision.tag != currentColor)
        {
            panel.SetActive(true);
            retryButton.SetActive(true);
            Time.timeScale = 0;
        }
        if (collision.tag == "Respawn")
        {
            panel.SetActive(true);
            retryButton.SetActive(true);
            Time.timeScale = 0;
            
        }
    }
    void RandomColor()
    {
        int index = Random.Range(0,4);

        switch (index)
        {
            case 0:
                currentColor = "turquoise";
                sr.color = colorTurquoise;
                break;
            case 1:
                currentColor = "yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "pink";
                sr.color = colorPink;
                break;
            case 3:
                currentColor = "plato";
                sr.color = colorPlato;
                break;
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        panel.SetActive(false);
        Time.timeScale = 1;
    }
    public void RePlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        panel.SetActive(false);
        Time.timeScale = 1;
        rb.bodyType = RigidbodyType2D.Static;   // Player baþlagýçta sabit kalamsý için statik yapýlýr
    }
}
