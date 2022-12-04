using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static bool lastKeyFound = false;
    public static bool createEnemy;
    public List<GameObject> Keys;
    public GameObject Flashlight;
    public GameObject uvFlashlight;

    private int taskOrder = 0;
    private TextMesh task;
    private float TaskClose = 0f;
    void Start()
    {
        task = GetComponent<TextMesh>();
    }

    string StrikeThrough(string s)
    {
        string strikethrough = "";
        foreach (char c in s)
        {
            strikethrough = strikethrough + '\u0336' + c;
        }
        return strikethrough;
    }

    void changeTask(string taskTxt, GameObject gameObject,int taskOrd)
    {
        task.text = taskTxt;
        if (gameObject.activeSelf)
        {
            TaskClose += Time.deltaTime;
            if (TaskClose <= 1.5)
            {
                task.text = StrikeThrough(task.text);
            }
            else
            {
                taskOrder = taskOrd;
                TaskClose = 0f;
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        switch (taskOrder)
        {
            case 0:
                {
                    changeTask("Normal el feneri bul \n(Ýpucu: Kullanabilmek için batarya gerekir)", Flashlight, 1);
                    break;
                }
            case 1:
                {
                    changeTask("Kýsa koridora çýkan kapýyý açmak için anahtar bul.", Keys[0], 2);
                    break;
                }
            case 2:
                {
                    changeTask("Kýzýl Ötesi El feneri bul\n(Ýpucu: Bebek, ýþýðýndan çok rahatsýz olur)", uvFlashlight, 3);
                    break;
                }
            case 3:
                {
                    createEnemy = true;
                    changeTask("Kanlý kapýyý açmak için anahtar bul.", Keys[1], 4);
                    break;
                }
            case 4:
                {
                    changeTask("Banyoya ulaþmak için anahtar bul.", Keys[2], 5);
                    break;
                }
            case 5:
                {
                    changeTask("Çalýþma Odasýna girebilmek için anahtar bul.", Keys[3], 6);
                    break;
                }
            case 6:
                {
                    changeTask("Büyük odaya girmek için anahtar bul.", Keys[4], 7);
                    break;
                }
            case 7:
                {
                    changeTask("Yemek odasýna ulaþmak için anahtar bul.", Keys[5], 8);
                    break;
                }
            case 8:
                {
                    changeTask("Ana kapýdan kaçmak için anahtarýný bul.", Keys[6], 9);
                    break;
                }
            case 9:
                {
                    lastKeyFound = true;
                    task.text = "EVDEN KAÇ!\n(Dikkat et, bebek çok kýzgýn!!)";
                    break;
                }
        }
    }
}
