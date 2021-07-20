using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float jumpPower = 10f;   // Zýplama gücü
    public string currentColor; // Player rengi
    public float score;

    Rigidbody2D rb;
    SpriteRenderer sr;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI totalScoreText;

    public GameObject one, two, three;  // Çemberler
    public GameObject panel;    // Oyun bitiþ paneli
    public GameObject retryButton;  // Yeniden baþlatma butonu
    public GameObject playButton;   // Baþlama butonu

    public Color colorTurquoise;    // Player renkleri
    public Color colorYellow;   // Player renkleri
    public Color colorPink;     // Player renkleri
    public Color colorPlato;    // Player renkleri
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        RandomColor();  // Player random renk alýr
        rb.bodyType = RigidbodyType2D.Static;   // Player baþlagýçta sabit kalamsý için statik yapýlýr
        panel.SetActive(false); // Oyun baþladýðýnda paneli pasif yap
        retryButton.SetActive(false);   // Oyun baþladýðýnda retryButton pasif yap
        playButton.SetActive(false);    // Oyun baþladýðýnda playButton pasif yap
    }
    void Update()
    {
        scoreText.text = score.ToString("f0");  // Score textini ekrana yazar
        if (Input.GetButtonDown("Jump") || (Input.GetMouseButtonDown(0)))
        {   // Eðer boþluk tuþuna basýlmýþsa veya mouse sol týklanmýþsa
            rb.bodyType = RigidbodyType2D.Dynamic;  // Player her hangi bir iþlemde(tuþa basýldýðýnda veya ekrana dokunulduðunda) hareket eder
            rb.velocity = Vector2.up * jumpPower;   // jumpPower deðeri kadar zýplar
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "colorChangerOne")
        {   // Eðer Player "colorChangerOne" tagýna temas etmiþse 
            collision.gameObject.transform.position = transform.position + new Vector3(0f,24f,0f);  // Temas edilen "colorChanger" objesi 24f "y" eksenide yukarý taþýnýr
            one.transform.position = transform.position + new Vector3(0f, 20f, 0f); // "one" çemberi  20f "y" eksenide yukarý taþýnýr
            score += 1; // Score 1 artar
            totalScoreText.text = score.ToString(); // Score ekranda güncellenir
            RandomColor();  // Player yeni random renk alýr            
            return;
        }
        if (collision.tag == "colorChangerTwo")
        {   // Eðer Player "colorChangerTwo" tagýna temas etmiþse 
            collision.gameObject.transform.position = transform.position + new Vector3(0f, 24f, 0f);    // Temas edilen "colorChanger" objesi 24f "y" eksenide yukarý taþýnýr
            two.transform.position = transform.position + new Vector3(0f, 20f, 0f); // "two" çemberi  20f "y" eksenide yukarý taþýnýr
            score += 1; // Score 1 artar
            totalScoreText.text = score.ToString(); // Score ekranda güncellenir
            RandomColor();  // Player yeni random renk alýr 
            return;
        }
        if (collision.tag == "colorChangerThree")
        {   // Eðer Player "colorChangerThree" tagýna temas etmiþse 
            collision.gameObject.transform.position = transform.position + new Vector3(0f, 24f, 0f);    // Temas edilen "colorChanger" objesi 24f "y" eksenide yukarý taþýnýr
            three.transform.position = transform.position + new Vector3(0f, 20f, 0f);   // "three" çemberi  20f "y" eksenide yukarý taþýnýr
            score += 1; // Score 1 artar
            totalScoreText.text = score.ToString(); // Score ekranda güncellenir
            RandomColor();  // Player yeni random renk alýr 
            return;
        }
        if (collision.tag != currentColor)
        {   // Eðer temas edilen objenin tagý "currentColor" deðilse - Eðer çembere temas etmiþse
            panel.SetActive(true);  // Panel aktif olur
            retryButton.SetActive(true);    // Yeniden baþlat butonu aktif olur
            Time.timeScale = 0; // Zaman hýzý 0 olur
        }
        if (collision.tag == "Respawn")
        {   // Eðer temas edilen objenin tagý "Respawn" ise alt sýnýra temas etmiþ ve oyun biter
            panel.SetActive(true);  // Panel aktif olur
            retryButton.SetActive(true);    // Yeniden baþlat butonu aktif olur
            Time.timeScale = 0; // Zaman hýzý 0 olur
        }
    }
    void RandomColor()
    {
        int index = Random.Range(0,4);
        // Player random þekilde 4 deðer arasýnda renk alýr
        switch (index)
        {
            case 0:
                currentColor = "turquoise"; // currentColor deðiþkeni turquoise olur
                sr.color = colorTurquoise;  // SpriteRenderer altýnda color compenetine eriþip rengini deðiþtirir
                break;
            case 1:
                currentColor = "yellow";    // currentColor deðiþkeni yellow olur
                sr.color = colorYellow; // SpriteRenderer altýnda color compenetine eriþip rengini deðiþtirir
                break;
            case 2:
                currentColor = "pink";  // currentColor deðiþkeni pink olur
                sr.color = colorPink;   // SpriteRenderer altýnda color compenetine eriþip rengini deðiþtirir
                break;
            case 3:
                currentColor = "plato"; // currentColor deðiþkeni plato olur
                sr.color = colorPlato;  // SpriteRenderer altýnda color compenetine eriþip rengini deðiþtirir
                break;
        }
    }
    public void Play()
    {   // Oyun baþatma butonu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   // Þuanki aktif sahneyi açar
        panel.SetActive(false); // Oyun baþlayýnca panel pasif olur
        Time.timeScale = 1; // Oyun baþlayýnca zaman normal deðerini alýr
    }
    public void RePlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   // Þuanki aktif sahneyi açar
        panel.SetActive(false); // Oyun baþlayýnca panel pasif olur
        Time.timeScale = 1; // Oyun baþlayýnca zaman normal deðerini alýr
        rb.bodyType = RigidbodyType2D.Static;   // Player baþlagýçta sabit kalamsý için statik yapýlýr
    }
}
