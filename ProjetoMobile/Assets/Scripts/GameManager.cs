using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton
    private static GameManager instance;
    public static GameManager Instance => instance;


    [SerializeField] private GameObject obstaculo;
    public float tempoSpawn;
    public bool gameOver;

    [Header("Sistema de Pontos")]
    public TextMeshProUGUI txtMeshPro;
    private int pontuacao;
    private float tempoPontos;

    [Header("Painel Pause")]
    public GameObject painelPause;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;


        tempoSpawn = 2f;
        gameOver = false;
        StartCoroutine(SpawnObstaculo());
        pontuacao = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if(Time.timeScale == 0)
            {
                StartCoroutine(ScaleTime(0, 1, 0.5f));
                painelPause.SetActive(false);

            }
            else if(Time.timeScale == 1){

                StartCoroutine(ScaleTime(1, 0, 0.5f));
                painelPause.SetActive(true);
            }
        }

      if(gameOver == true)
        {
            return;
        }
        else
        {
            tempoPontos += Time.deltaTime;
            if (tempoPontos >= 1f)
            {
                pontuacao++;
                txtMeshPro.text = $"Pontos: {pontuacao}";
                tempoPontos = 0f;
            }
        }
    }

    private IEnumerator SpawnObstaculo()
    {
        while (gameOver == false) {

            var obstaculoToSpawn = Random.Range(1, 4);

            for (int i = 0; i < obstaculoToSpawn; i++)
            {
                var x = Random.Range(-7, 7);
                var damp = Random.Range(0f, 2f);
                Instantiate(obstaculo, new Vector3(x, 11, 0), Quaternion.identity);
                obstaculo.GetComponent<Rigidbody>().linearDamping = damp;

            }
            yield return new WaitForSeconds(tempoSpawn);
        }
    }

    public void GameOver()
    {
        gameOver = true;
    }

    IEnumerator ScaleTime(float start, float end, float duration)
    {
        float lastTime = Time.realtimeSinceStartup;
        float timer = 0.0f;

        while (timer < duration)
        {
            Time.timeScale = Mathf.Lerp(start, end, timer / duration);
            Time.fixedDeltaTime = 0.02f * Time.timeScale;

            timer += (Time.realtimeSinceStartup - lastTime);
            lastTime = Time.realtimeSinceStartup;

            yield return null;

        }

        Time.timeScale = end;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

}
