using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClick : MonoBehaviour {

    public Button ButtonA, ButtonB, next;
    public Toggle CheckA, CheckB;
    public AudioClip[] Sounds;

    private AudioSource DasAudio;
    private int A, B;
    [SerializeField]
    public int[] Points;

    // Update is called once per frame
    void Start () {
        DasAudio = GetComponent<AudioSource>();
        ButtonA.onClick.AddListener(ClickA);
        ButtonB.onClick.AddListener(ClickB);
        next.onClick.AddListener(NextF);

        Points = new int[Sounds.Length];

        setAB();
    }

    void ClickA()
    {
        DasAudio.clip = Sounds[A];
        DasAudio.Play();
    }

    void ClickB()
    {
        DasAudio.clip = Sounds[B];
        DasAudio.Play();
        Debug.Log("B");
    }

    void NextF()
    {
        if (CheckA.isOn)
        {
            Points[A]++;
        }
        if (CheckB.isOn)
        {
            Points[B]++;
        }

        CheckA.isOn = false;
        CheckB.isOn = false;

        GameObject SavEntity = GameObject.Find("Save");
        SaveFile InterCon2 = SavEntity.GetComponent<SaveFile>();

        InterCon2.Save();


        setAB();
 
        
    }

    void setAB()
    {
        A = Random.Range(0, Sounds.Length);
        B = Random.Range(0, Sounds.Length);

        //always different sounds
        A = (A==B) ? A = Random.Range(0, Sounds.Length):A;

        Debug.Log(A + "  " + B);

    }
}

