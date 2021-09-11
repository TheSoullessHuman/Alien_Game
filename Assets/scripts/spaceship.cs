using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceship : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bala;
    [SerializeField] GameObject disparador;
    [SerializeField] GameObject BalaR;
    [SerializeField] GameObject BalaLenta;
    [SerializeField] float fireRate;
    [SerializeField] int SlowMotion;

    public int secondsLeft = 5;
    public bool takingAway = false;
    int Count = 4;

    float minX, maxX, minY, maxY;
    float nextFire = 0;
    //float VelocidadDisparo = 0.25f;
    float nextRafaga = 0;
    bool cambiarBala = true;
    bool Lentoo = true;
    bool Rafaga = true;
    float nextLento = 0;



    // Start is called before the first frame update
    void Start()
    {
        new Vector2(1, 1);
        Vector2 esquinaSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 puntoMinParaY = Camera.main.ViewportToWorldPoint(new Vector2(0, 0.7f));

        maxX = esquinaSupDer.x - 0.6f;
        maxY = esquinaSupDer.y - 0.6f;
        minX = puntoMinParaY.x + 0.6f;
        minY = puntoMinParaY.y;



        //World space = el espacio de juego
        //screen space =resolucion
        //viewport = la camara

    }

    // Update is called once per frame
    void Update()
    {
        MoverNave();
        if (cambiarBala)
        {
            Disparar();
        }

        else if (Rafaga)
        { 
            DispararRafaga();
        }

        if (Time.timeScale == 0.3f)
        {
            DispararLento();
        }
        
           

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (cambiarBala)
            {
                cambiarBala = false;
            }
            else
                cambiarBala = true;

            //cambiarBala = cambiarBala ? false : true;
        }  //rafaga

        if (Input.GetKeyDown(KeyCode.X))
        {


            if (takingAway == false && secondsLeft > 0)
            {
                    Count --;

                if (Count > 0)
                {
                  StartCoroutine(SloMo());
                }

            }
        }  //slow motion

    }
   
    void MoverNave()
    {
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");

        Vector2 movimiento = new Vector2(movH * Time.deltaTime * speed, movV * Time.deltaTime * speed);

        //aca se mueve
        transform.Translate(movimiento);

        //aca posicion
        if (transform.position.x > maxX)
        {
            //devuelvase a maxX
            transform.position = new Vector2(maxX, transform.position.y);

        }
        if (transform.position.x < minX)
        {
            //devuelvase a minX
            transform.position = new Vector2(minX, transform.position.y);

        }
        if (transform.position.y > maxY)
        {
            //devuelvase a maxY
            transform.position = new Vector2(transform.position.x, maxY);

        }
        if (transform.position.y < minY)
        {
            //devuelvase a minY
            transform.position = new Vector2(transform.position.x, minY);

        }



    }
    void Disparar()
    {
        //Time.time
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFire)
        {
            //Instantiate(bala, transform.position, transform.rotation);
            Instantiate(bala, disparador.transform.position, transform.rotation);
            //objeto, lugar, rotacion
            nextFire = Time.time + fireRate;

        }
    }
    void DispararRafaga()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextRafaga)
        {
            Instantiate(BalaR, disparador.transform.position, transform.rotation);
            nextRafaga = Time.time + (fireRate / 4);
        }
    }
    void DispararLento()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextLento)
        {
            Instantiate(BalaLenta, disparador.transform.position, transform.rotation);
            nextLento = Time.time + fireRate;
        }
    }
    public IEnumerator SloMo()
    {
        takingAway = true;
        Time.timeScale = 0.3f;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        takingAway = false;
        Time.timeScale = 1;

        // agregar destroy all objects 
    }



}
