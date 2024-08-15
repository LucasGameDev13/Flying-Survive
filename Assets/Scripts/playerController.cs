using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private gmController _gmController;
    private Rigidbody2D playerRb;

    // Start is called before the first frame update
    void Start()
    {

        _gmController = FindObjectOfType(typeof(gmController)) as gmController;
        playerRb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        movimento();

        limites();
    }

    void movimento()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        playerRb.velocity = new Vector2(horizontal * _gmController.velocidade, vertical * _gmController.velocidade);
    }

    void limites()
    {
        float posX = transform.position.x;
        float posY = transform.position.y;

        if(posX > _gmController.limiteMaxX)
        {
            posX = _gmController.limiteMaxX;
        }
        else if(posX < _gmController.limiteMinX)
        {
            posX = _gmController.limiteMinX;
        }

        if(posY > _gmController.limiteMaxY)
        {
            posY = _gmController.limiteMaxY;
        }
        else if(posY < _gmController.limiteMinY)
        {
            posY = _gmController.limiteMinY;
        }

        transform.position = new Vector3(posX, posY, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _gmController.mudaCena("GameOver");
    }
}
