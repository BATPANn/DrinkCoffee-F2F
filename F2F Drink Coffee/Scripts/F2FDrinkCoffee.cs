using UnityEngine;
using TMPro;
using System.Collections;

public class F2FDrinkCoffee : MonoBehaviour
{

    public TextMeshProUGUI DrinkText;

    public Animator CoffeeAnimator;

    public AudioSource CoffeeSource;

    public AudioClip CoffeeClip;

    private bool CanDrink = true;

    private int DrinkAmount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        DrinkText.text = "Press (Space) To Drink Coffee";

    }

    // Update is called once per frame
    void Update()
    {

        if(CanDrink == true)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {

                StartCoroutine(DrinkCoffeeCO());


            }


        }

        

        
    }



    IEnumerator DrinkCoffeeCO()
    {

        CanDrink = false;

        DrinkText.text = "";

        if(DrinkAmount == 0)
        {

            // drink for the first time
            CoffeeAnimator.SetInteger("C", 1);

        }
        else if(DrinkAmount == 1)
        {

            // drink for the second time ( last time )
            CoffeeAnimator.SetInteger("C", 2);

        }

        DrinkAmount++; // drink amount +1

        CoffeeSource.PlayOneShot(CoffeeClip);

        yield return new WaitForSeconds(1.5f);

        if(DrinkAmount == 1)
        {
            DrinkText.text = "Press (Space) To Drink Coffee";
            CanDrink = true;
        }
        else if(DrinkAmount == 2)
        {
            DrinkText.text = "";
            CanDrink = false;
        }




    }


}
