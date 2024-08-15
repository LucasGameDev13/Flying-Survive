using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gmController : MonoBehaviour
{
    //Acessando o script do player
    private playerController _playerController;

    //Variáveis para configuração das informações do player;
    [Header("Config. Player")]
    public float velocidade;
    public float limiteMaxX;
    public float limiteMinX;
    public float limiteMaxY;
    public float limiteMinY;

    //Variáveis para configuração das informações dos inimigos;
    [Header("Config. Inimigos")]
    public float velocidadeInimigo;
    public float limiteDestruicao;
    public float tempoSpawn;
    public int order;
    public GameObject inimigoProfab;
    public GameObject inimigoProfab2;

    //Variáveis globais para controle dos pontos;
    [Header("Config. Globais")]
    public int pontos;
    public float posXPlayer;
    public TextMeshProUGUI scoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializando o função para criação dos inimigos;
        //Função de instanciamento dos inimigo;
        StartCoroutine("tempoInstancia");

        //Acessando o script do player; 
        _playerController = FindObjectOfType(typeof(playerController)) as playerController;
            
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Pegando a posição do player a todo momento;
        posXPlayer = _playerController.transform.position.x;
    }

    //Função para instancias os inimigos;
    IEnumerator tempoInstancia()
    {
        //Estipulando de quanto em quanto tempo será criado as instancias;
        yield return new WaitForSeconds(tempoSpawn);

        //Criando a variável de posição do inimigo;
        float novoPosY = 0;

        //Criando a variável de sorteio para criação dos inimigos;
        float sorteio = Random.Range(0, 100);

        //Criando a variável inimigo;
        GameObject inimigo = null;

        //Se sorteio for maior que 50;
        if (sorteio > 50)
        {
            //Escolhe uma posY 
            //
            novoPosY = Random.Range(limiteMinY, limiteMaxY);
            order = 0;
            inimigo = inimigoProfab;
        }
        else
        {
            novoPosY = Random.Range(limiteMinY, limiteMaxY);
            order = 2;
            inimigo = inimigoProfab2;
        }

        GameObject inimigoInstancia = Instantiate(inimigo);

        inimigoInstancia.transform.position = new Vector3(inimigoInstancia.transform.position.x, novoPosY, 0);

        StartCoroutine("tempoInstancia");
    }

    public void pontuacao(int _pontos)
    {
        pontos += _pontos;
        scoreTxt.text = "Score : " + pontos.ToString();

    }

    public void mudaCena(string _cena)
    {
        SceneManager.LoadScene(_cena);
    }
}
