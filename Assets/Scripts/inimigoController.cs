using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoController : MonoBehaviour
{
    private gmController _gmController;
    private Rigidbody2D inimigoRb;
    private Renderer orderInLayer;
    private bool contador;


    // Start is called before the first frame update
    void Start()
    {
        _gmController = FindAnyObjectByType(typeof(gmController)) as gmController;
        inimigoRb = GetComponent<Rigidbody2D>();
        orderInLayer = GetComponent<Renderer>();

        orderInLayer.sortingOrder = _gmController.order;

        inimigoRb.velocity = new Vector2(_gmController.velocidadeInimigo, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float posXInimigo = transform.position.x;

        if(posXInimigo < _gmController.limiteDestruicao)
        {
            Destroy(this.gameObject);   
        }

        if (!contador)
        {
            if (posXInimigo < _gmController.posXPlayer)
            {
                contador = true;
                _gmController.pontuacao(10);
            }
        }
    }
}
