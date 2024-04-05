using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormigaCuajada2D : Enemigo
{
   protected bool pupa;
    protected GameObject hura;

   ItemDrop items;

    private void Awake()
    {
        hura = (GameObject)GameObject.FindGameObjectWithTag("Hura");
        pupa = false;
       // CombatManagerFormiga.instance.SetBloquearPorParry(false);
    }
    private void Start()
    {
       // items = GetComponent<ItemDrop>();

    }
    // Update is called once per frame
    void Update()
    {
        distancia = Vector3.Distance(this.gameObject.transform.position, hura.gameObject.transform.position);
        

        if (!pupa && vidaEnemigo>0)
        {
            Ataque();
            Heridou();
        }
    }
    public void DanioEnemigo(int danio)
    {
        
       // if (CombatManagerFormiga.instance.GetBloquearPorParry()== false)
        {
            vidaEnemigo = vidaEnemigo - danio;
            pupa = true;
            Debug.Log("da�o enemigo"+vidaEnemigo);
            muerte();
            Heridou();
            Perseguir();
        }
       
    }
    public void PermitirDanio()
    {
        CombatManagerFormiga.instance.SetPermitirDanio(true);
    }
    public void NoPermitirDanio()
    {
        CombatManagerFormiga.instance.SetPermitirDanio(false);
    }
    public void Heridou()
    {
        if (pupa==true)
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("herido");
            pupa =false;

        }
        
    }
    public void Perseguir()
    {
        this.gameObject.GetComponent<Animator>().SetBool("corriendo",true);
    }
    
   public void Iddle()
    {
        this.gameObject.GetComponent<Animator>().SetBool("corriendo", false);
    }

    public void Ataque()
    {
      
        if (distancia <= 2f)
        {
            int aleatorio = Random.Range(0,100);
            if (aleatorio <= 53)
            {
                this.gameObject.GetComponent<Animator>().SetTrigger("ataque1");
                this.gameObject.GetComponent<Animator>().ResetTrigger("ataque2");
                
            }
            else if(aleatorio>=54 && aleatorio<=99)
            {
                this.gameObject.GetComponent<Animator>().SetTrigger("ataque2");
                this.gameObject.GetComponent<Animator>().ResetTrigger("ataque1");
                
            }
            else
            {
                this.gameObject.GetComponent<Animator>().SetTrigger("Parry");
                this.gameObject.GetComponent<Animator>().ResetTrigger("ataque2");
                this.gameObject.GetComponent<Animator>().ResetTrigger("ataque1");
                
                CombatManagerFormiga.instance.SetBloquearPorParry(true);
                Invoke("DesbloquearPorParry",1f);

            }
         
        }
        
        
    }

    public void DesbloquearPorParry()
    {
        CombatManagerFormiga.instance.SetBloquearPorParry(false);
    }

    public void muerte()
    {
        if (vidaEnemigo <= 0)
        {
            this.gameObject.GetComponent<Animator>().ResetTrigger("herido");
            this.gameObject.GetComponent<Animator>().ResetTrigger("ataque1");
            this.gameObject.GetComponent<Animator>().ResetTrigger("ataque2");
            pupa =false;
            
            this.gameObject.GetComponent<Animator>().SetTrigger("muerte");
            //Destroy(this.gameObject.transform.parent.gameObject);
            Destroy(this.gameObject.transform.parent.GetComponent<FormigaCuajada>());
            Destroy(this.gameObject.transform.parent.GetComponent<CapsuleCollider>());
            Destroy(this.gameObject.GetComponent<BoxCollider2D>());
            Destroy(this.gameObject.transform.parent.GetComponent<Rigidbody>());

            //items.ItemSuelto();
            

        }
    }

}
