using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TopKontrol : MonoBehaviour
{
    Rigidbody2D rb;
    public float ziplamaKuvveti = 3f;
    bool basildiMi = false;

    public string mevcutRenk;
    public Color topunRengi;
    public Color turkuaz, sari, mor, pembe;

    [SerializeField]
    Text scoreText,bestScoreText;
    [SerializeField]
    Button startButton;
    [SerializeField]
    GameObject infoPanel;
    public static int score = 0;

    public GameObject halka, renkTekeri;

    public static bool isStart = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        bestScoreText.text = "BestScore:" +PlayerPrefs.GetInt("Score");
        scoreText.text ="Score: "+ score;
        RastgeleRenkBelirle();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            basildiMi = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            basildiMi = false;
        }
		if (!isStart)
		{
            rb.simulated = isStart;
			return;
		}
		else if (isStart)
		{
            rb.simulated = isStart;
        }
	}

    private void FixedUpdate()
    {
        if (basildiMi)
        {
            rb.velocity = Vector2.up * ziplamaKuvveti;
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "RenkTekeri")
        {
            RastgeleRenkBelirle();
            Destroy(collision.gameObject);
            return;
        }
        if (collision.tag != mevcutRenk && collision.tag != "PuanArttirici"  && collision.tag!="RenkTekeri")
        {
            score = 0;//Eğer can sistemi yapılacaksa burayı can sistemini ekle,can sistemi yoksa score'un static degerini kaldir.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   
        }

        if (collision.tag == "PuanArttirici")
        {
            score += 5;
            scoreText.text = "Score: " + score;
            PlayerPrefs.SetInt("Score", score);//Score stored inside PlayerPrefs key Score
            PlayerPrefs.Save();//PlayerPrefs InfoPanel'in icinde
            Destroy(collision.gameObject);

            Instantiate(halka, new Vector3(transform.position.x, transform.position.y + 8f,
                transform.position.z), Quaternion.identity);

            Instantiate(renkTekeri, new Vector3(transform.position.x, transform.position.y + 11f,
                transform.position.z), Quaternion.identity);
        }
    }
	#region RastgeleRenkBelirle
	void RastgeleRenkBelirle()
    {
        int rastgeleSayi = Random.Range(0, 4);//0-1-2-3
        switch (rastgeleSayi)
        {
            case 0:
                mevcutRenk = "Turkuaz";
                topunRengi = turkuaz;
                break;
            case 1:
                mevcutRenk = "Sari";
                topunRengi = sari;
                break;
            case 2:
                mevcutRenk = "Pembe";
                topunRengi = pembe;
                break;
            case 3:
                mevcutRenk = "Mor";
                topunRengi = mor;
                break;
        }
        GetComponent<SpriteRenderer>().color = topunRengi;
    }
	#endregion

	#region Start Game
	public void StartGame()
	{
        isStart = true;
        Destroy(startButton.gameObject);
	}
	#endregion

	#region Info Panel Process
	public void OpenInfoPanel()
	{
        infoPanel.SetActive(true);
	}

    public void CloseInfoPanel()
	{
        infoPanel.SetActive(false);
	}
	#endregion
}//Class
