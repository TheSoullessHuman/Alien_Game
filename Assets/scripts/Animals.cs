using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool moveright;
    float minX, maxX;
    [SerializeField] int lifePoints;

    // Start is called before the first frame update
    void Start()
    {

        new Vector2(1, 1);
        Vector2 esquinaInfDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaInfDer.x;
        minX = esquinaInfIzq.x;
        


    }

    // Update is called once per frame
    void Update()
    {
        if (moveright)
        {
            //moverse en x
            Vector2 movimiento = new Vector2(speed * Time.deltaTime, 0);
            //aca se mueve
            transform.Translate(movimiento);


        }
        else 
        {
            Vector2 movimiento = new Vector2(-speed * Time.deltaTime, 0);
            transform.Translate(movimiento);

        }

        //jsdhfb

        if (transform.position.x >= maxX)
        {
            moveright = false;
            //devuelvase a maxX (izquierda) booleana

        }

        else if(transform.position.x <= minX)
        {

            moveright = true;
            //devuelvase a maxX (Derecha) booleana

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        //Debug.Log("Colisiono contra algo!");
        // guardar objeto en variable
        GameObject objeto = collision.gameObject;
        //tag, se destruye lo que toque la bala
        string etiqueta = collision.gameObject.tag;


        if (collision.gameObject.CompareTag("Disparo"))
        {
            int puntos = collision.gameObject.GetComponent<Bullet>().darDamagePoints();
            GameObject gm = GameObject.Find("GameManager");
            GameManager script = gm.GetComponent<GameManager>();
            script.CaptureAnimal();
            lifePoints = lifePoints - puntos;

            if (lifePoints < 1) 
            { 
                Destroy(this.gameObject);
            }
               

        }

    }
  
}