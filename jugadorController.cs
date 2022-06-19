using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Agregamos
using UnityEngine.UI;

public class jugadorController : MonoBehaviour
{
    //Variable RigidBody que luego se asociara a nuestro jugado
    private Rigidbody rb;

    //inicializo el contador de coleccionables recogidos
    private int contador;

    //inicializo variables para los textos
    public Text textoContador, textoGanar;


    public float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        //Capturo esa variable al iniciar el juego
        rb = GetComponent<Rigidbody>();  

        //inicio el contador a 0
        contador = 0;
        //Actualizo el texto del contador por pimera vez
        setTextoContador();

        //inicio el texto contador en vacio
        textoGanar.text = "";
    }
    //Para que se sincronice con los frames de fisica del motor
    void FixedUpdate(){
        //variables que capturan el movimiento
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");

        //un vector 3 es un trio de posiciones en el espacio xyz en este caso el que corresponde al movimiento
        Vector3 movimiento = new Vector3(movimientoH, 0.0f,movimientoV);

        //asigno ese movimiento o desplazamiento a mi RigidBody
        rb.AddForce(movimiento * velocidad);
    }

    //Se ejecuta al entrar a un objeto con la opcion isTrigger seleccionada
    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag ("Coleccionable")){
            //desactivo el objeto
            other.gameObject.SetActive (false);
            //incremento el contador en uno (tambien se puede hacer como contador++)
            contador = contador + 1;

            //Actualizo el texto del contador
            setTextoContador();
        }
    }

    //actualizo el texto del contador(o muestro el de ganar si las ha cogido todas)
    void setTextoContador(){
        textoContador.text = "Contador: " + contador.ToString();
        if (contador >= 12){
            textoGanar.text = "¡Ganaste!";
        }
    }
}
