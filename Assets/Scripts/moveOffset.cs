using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOffset : MonoBehaviour
{
    //Variáveis controle dos backgrounds
    private Renderer    meshRender;
    private Material    currentMaterial;
    private float       offset;
    public float        incrementoOffset;
    public float        velocidade;
    public int          orderInLayer;
    public string       sortingLayer;


    // Start is called before the first frame update
    void Start()
    {
        //Acessando o meshRender
        //Pegando o material atual
        meshRender      = GetComponent<Renderer>();
        currentMaterial = meshRender.material;

        //Definindo a ordem da layer
        //Definindo o tipo da layer
        meshRender.sortingOrder     = orderInLayer;
        meshRender.sortingLayerName = sortingLayer;
    }

    // Update is called once per frame
    void Update()
    {
        //Incrementando o offset
        offset += incrementoOffset;

        //Aplicando o valor do offset no offset do material
        currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset * velocidade, 0));
    }
}
