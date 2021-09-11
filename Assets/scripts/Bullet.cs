using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] bool moveright;
    [SerializeField] int damagePoints;

    // Start is called before the first frame update
    void Start()
    {
        new Vector2(1, 1);
        Vector2 esquinaInfDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int darDamagePoints()
    {
        return damagePoints;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisiono contra algo!");
        // guardar objeto en variable
        GameObject objeto = collision.gameObject;
        //tag, se destruye lo que toque la bala
        string etiqueta = objeto.tag;

        if (etiqueta == "Animal")
        {
            Destroy(this.gameObject);
        }

        if (etiqueta == "Suelo")
        {
            Destroy(this.gameObject);
        }


    }
}
