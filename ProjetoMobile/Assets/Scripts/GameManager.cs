using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaculo;
    public float tempoSpawn;
    public bool gameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tempoSpawn = 2f;
        gameOver = false;
        StartCoroutine(SpawnObstaculo());
    }

    // Update is called once per frame
    void Update()
    {
      
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
}
