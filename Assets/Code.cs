using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Code : MonoBehaviour
{
    public Text chiffre1;
    public Text chiffre2;
    public Text chiffre3;
    public Text chiffre4;
    public Text chiffre5;

    private int n1 = 0, n2 = 0, n3 = 0, n4 = 0, n5 = 0;

    void Update()
    {
        if (n1 == 4 && n2 == 1 && n3 == 8 && n4 == 7 && n5 == 3)
            Debug.Log("you win");
    }

    public void but1()
    {
        n1++;
        if (n1 < 10)
            chiffre1.text = n1.ToString();
        else
        {
            n1 = 0;
            chiffre1.text = n1.ToString();
        }
    }

    public void but2()
    {
        n2++;
        if (n2 < 10)
            chiffre2.text = n2.ToString();
        else
        {
            n2 = 0;
            chiffre2.text = n2.ToString();
        }
    }

    public void but3()
    {
        n3++;
        if (n3 < 10)
            chiffre3.text = n3.ToString();
        else
        {
            n3 = 0;
            chiffre3.text = n3.ToString();
        }
    }

    public void but4()
    {
        n4++;
        if (n4 < 10)
            chiffre4.text = n4.ToString();
        else
        {
            n4 = 0;
            chiffre4.text = n4.ToString();
        }
    }

    public void but5()
    {
        n5++;
        if (n5 < 10)
            chiffre5.text = n5.ToString();
        else
        {
            n5 = 0;
            chiffre5.text = n5.ToString();
        }
    }

}
