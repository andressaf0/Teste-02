using UnityEngine;

public class ControladorJogador : MonoBehaviour
{
    public float velocidadeMaozinha;
    public Geral juizDoJogo;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Este código é para mão subir
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y <= 465)
        {
                Vector3 novaPos = new Vector3(0, velocidadeMaozinha * Time.deltaTime, 0);
            transform.position = transform.position + novaPos;
            //  transform.position += novaPos; simplicação do codigo da linha de cima
        }

        // Este código é para mao descer
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y >= 35)
        {
            Vector3 novaPos = new Vector3(0, velocidadeMaozinha * Time.deltaTime, 0);
            transform.position = transform.position - novaPos;
            //  transform.position -= novaPos; simplicação do codigo da linha de cima
        }


        /* if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= 875)
        {
            Vector3 novaPos = new Vector3(0, velocidadeMaozinha * Time.deltaTime, 0);
            transform.position = transform.position + novaPos;
            //  transform.position -= novaPos; simplicação do codigo da linha de cima
        }

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= 86)
        {
            Vector3 novaPos = new Vector3(0, velocidadeMaozinha * Time.deltaTime, 0);
            transform.position = transform.position - novaPos;
            //  transform.position -= novaPos; simplicação do codigo da linha de cima
        }*/

    }
    //  OnTriggerEnter2D(Collider2D collision) só é chamado quando colidir o trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {// quem bateu em mim comeca com nome "ferramenta" se sim, Vai buscar o componente controlador ferramenta e ao pegar, ele volta a posição inicial
        if (collision.name.StartsWith("Ferramenta"))
        {
            float posicaoY = Random.value * 465;
            collision.GetComponent<ControladorFerramenta>().posicaoFerramenta.x = 0;
            collision.GetComponent<ControladorFerramenta>().posicaoFerramenta.y = posicaoY;

            juizDoJogo.MarcarPonto();
        }
    }
}