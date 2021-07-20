using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float jumpPower = 10f;   // Z�plama g�c�
    public string currentColor; // Player rengi
    public float score;

    Rigidbody2D rb;
    SpriteRenderer sr;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI totalScoreText;

    public GameObject one, two, three;  // �emberler
    public GameObject panel;    // Oyun biti� paneli
    public GameObject retryButton;  // Yeniden ba�latma butonu
    public GameObject playButton;   // Ba�lama butonu

    public Color colorTurquoise;    // Player renkleri
    public Color colorYellow;   // Player renkleri
    public Color colorPink;     // Player renkleri
    public Color colorPlato;    // Player renkleri
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        RandomColor();  // Player random renk al�r
        rb.bodyType = RigidbodyType2D.Static;   // Player ba�lag��ta sabit kalams� i�in statik yap�l�r
        panel.SetActive(false); // Oyun ba�lad���nda paneli pasif yap
        retryButton.SetActive(false);   // Oyun ba�lad���nda retryButton pasif yap
        playButton.SetActive(false);    // Oyun ba�lad���nda playButton pasif yap
    }
    void Update()
    {
        scoreText.text = score.ToString("f0");  // Score textini ekrana yazar
        if (Input.GetButtonDown("Jump") || (Input.GetMouseButtonDown(0)))
        {   // E�er bo�luk tu�una bas�lm��sa veya mouse sol t�klanm��sa
            rb.bodyType = RigidbodyType2D.Dynamic;  // Player her hangi bir i�lemde(tu�a bas�ld���nda veya ekrana dokunuldu�unda) hareket eder
            rb.velocity = Vector2.up * jumpPower;   // jumpPower de�eri kadar z�plar
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "colorChangerOne")
        {   // E�er Player "colorChangerOne" tag�na temas etmi�se 
            collision.gameObject.transform.position = transform.position + new Vector3(0f,24f,0f);  // Temas edilen "colorChanger" objesi 24f "y" eksenide yukar� ta��n�r
            one.transform.position = transform.position + new Vector3(0f, 20f, 0f); // "one" �emberi  20f "y" eksenide yukar� ta��n�r
            score += 1; // Score 1 artar
            totalScoreText.text = score.ToString(); // Score ekranda g�ncellenir
            RandomColor();  // Player yeni random renk al�r            
            return;
        }
        if (collision.tag == "colorChangerTwo")
        {   // E�er Player "colorChangerTwo" tag�na temas etmi�se 
            collision.gameObject.transform.position = transform.position + new Vector3(0f, 24f, 0f);    // Temas edilen "colorChanger" objesi 24f "y" eksenide yukar� ta��n�r
            two.transform.position = transform.position + new Vector3(0f, 20f, 0f); // "two" �emberi  20f "y" eksenide yukar� ta��n�r
            score += 1; // Score 1 artar
            totalScoreText.text = score.ToString(); // Score ekranda g�ncellenir
            RandomColor();  // Player yeni random renk al�r 
            return;
        }
        if (collision.tag == "colorChangerThree")
        {   // E�er Player "colorChangerThree" tag�na temas etmi�se 
            collision.gameObject.transform.position = transform.position + new Vector3(0f, 24f, 0f);    // Temas edilen "colorChanger" objesi 24f "y" eksenide yukar� ta��n�r
            three.transform.position = transform.position + new Vector3(0f, 20f, 0f);   // "three" �emberi  20f "y" eksenide yukar� ta��n�r
            score += 1; // Score 1 artar
            totalScoreText.text = score.ToString(); // Score ekranda g�ncellenir
            RandomColor();  // Player yeni random renk al�r 
            return;
        }
        if (collision.tag != currentColor)
        {   // E�er temas edilen objenin tag� "currentColor" de�ilse - E�er �embere temas etmi�se
            panel.SetActive(true);  // Panel aktif olur
            retryButton.SetActive(true);    // Yeniden ba�lat butonu aktif olur
            Time.timeScale = 0; // Zaman h�z� 0 olur
        }
        if (collision.tag == "Respawn")
        {   // E�er temas edilen objenin tag� "Respawn" ise alt s�n�ra temas etmi� ve oyun biter
            panel.SetActive(true);  // Panel aktif olur
            retryButton.SetActive(true);    // Yeniden ba�lat butonu aktif olur
            Time.timeScale = 0; // Zaman h�z� 0 olur
        }
    }
    void RandomColor()
    {
        int index = Random.Range(0,4);
        // Player random �ekilde 4 de�er aras�nda renk al�r
        switch (index)
        {
            case 0:
                currentColor = "turquoise"; // currentColor de�i�keni turquoise olur
                sr.color = colorTurquoise;  // SpriteRenderer alt�nda color compenetine eri�ip rengini de�i�tirir
                break;
            case 1:
                currentColor = "yellow";    // currentColor de�i�keni yellow olur
                sr.color = colorYellow; // SpriteRenderer alt�nda color compenetine eri�ip rengini de�i�tirir
                break;
            case 2:
                currentColor = "pink";  // currentColor de�i�keni pink olur
                sr.color = colorPink;   // SpriteRenderer alt�nda color compenetine eri�ip rengini de�i�tirir
                break;
            case 3:
                currentColor = "plato"; // currentColor de�i�keni plato olur
                sr.color = colorPlato;  // SpriteRenderer alt�nda color compenetine eri�ip rengini de�i�tirir
                break;
        }
    }
    public void Play()
    {   // Oyun ba�atma butonu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   // �uanki aktif sahneyi a�ar
        panel.SetActive(false); // Oyun ba�lay�nca panel pasif olur
        Time.timeScale = 1; // Oyun ba�lay�nca zaman normal de�erini al�r
    }
    public void RePlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   // �uanki aktif sahneyi a�ar
        panel.SetActive(false); // Oyun ba�lay�nca panel pasif olur
        Time.timeScale = 1; // Oyun ba�lay�nca zaman normal de�erini al�r
        rb.bodyType = RigidbodyType2D.Static;   // Player ba�lag��ta sabit kalams� i�in statik yap�l�r
    }
}
