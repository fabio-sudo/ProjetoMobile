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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;


        tempoSpawn = 2f;
        gameOver = false;
        StartCoroutine(SpawnObstaculo());
    }

    // Update is called once per frame
    void Update()
    {
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
                txtMeshPro.text = $"Pontuação: {pontuacao}";
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
}
