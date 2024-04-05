using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBarricadaController : MonoBehaviour
{
    [SerializeField]
    protected GameObject furmiga;
    protected GameObject furmigaClon;
    protected int carrilAleatorio;
    protected int carrilAleatorio2;
    protected int carrilAleatorio3;
    protected bool heCreadoFormiga;

    [SerializeField]
    protected int[] oleadas;


    // Start is called before the first frame update
    void Start()
    {
        heCreadoFormiga = false;
        General.instance.SetContadorFormigasBarricada(0);
        General.instance.SetOleadaActual(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnearBarricadaFurmigaRandom()
    {
        if (General.instance.GetContadorFormigasBarricada() == 0)
        {
            General.instance.SetOleadaActual(General.instance.GetOleadaActual() + 1);
            General.instance.SetContadorFormigasBarricada(oleadas[General.instance.GetOleadaActual()]);
            
            if (heCreadoFormiga == false)
            {
                heCreadoFormiga = true;
                // esta variable tine ahora un valor de 0 a 2 (es decir el numero de carriles que hay).
                carrilAleatorio = Random.Range(0, this.gameObject.transform.childCount);
                //carrilAleatorio = 3;
                carrilAleatorio2 = carrilAleatorio + 1;

                //Si a salido el ultimo carril hacemos que valla al carril 0
                if (carrilAleatorio == this.gameObject.transform.childCount - 1)
                {
                    carrilAleatorio2 = 0;
                    carrilAleatorio3 = 1;
                }
                if (carrilAleatorio == this.gameObject.transform.childCount - 2)
                {
                    carrilAleatorio2 = this.gameObject.transform.childCount - 1;
                    carrilAleatorio3 = 0;

                }

                // creacion de un clon de formiga, en un punto de spawn.
                furmigaClon = (GameObject)Instantiate(furmiga, this.gameObject.transform.GetChild(carrilAleatorio).transform.position, Quaternion.identity);
                furmigaClon.AddComponent<FormigaDeBarricada>();

                furmigaClon = (GameObject)Instantiate(furmiga, this.gameObject.transform.GetChild(carrilAleatorio2).transform.position, Quaternion.identity);
                furmigaClon.AddComponent<FormigaDeBarricada>();

                furmigaClon = (GameObject)Instantiate(furmiga, this.gameObject.transform.GetChild(carrilAleatorio3).transform.position, Quaternion.identity);
                furmigaClon.AddComponent<FormigaDeBarricada>();
            }
        }
        

    }
}
