//using System.Collections;
//using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;


public class SaveFile : MonoBehaviour {

    private string fileName = "D.txt";

    private void Update()
    {
        
    }
    void Start () {

        Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
        Save();

        if (File.Exists(fileName))
            {
                Debug.Log(fileName + " already exists.");
                return;
            }
            var sr = File.CreateText(fileName);
            sr.WriteLine("Save");
            sr.WriteLine("file.",
                1, 4.2);
            sr.Close();
        }
	

    public void Save()
    {
        BinaryFormatter LeFormateur = new BinaryFormatter();
        FileStream LeFichier = File.Create(Application.persistentDataPath + "/sav2.txt") ;

        LeData data = new LeData();

        GameObject Omni = GameObject.Find("Omni");
        OnClick InterCon = Omni.GetComponent<OnClick>();

        var sr = File.CreateText(fileName);
        for (int i = 0; (i < InterCon.Sounds.Length); i++)
         {

            data.Texto = data.Texto + InterCon.Sounds[i] + " | " + InterCon.Points[i] + " @ ";
            
            sr.WriteLine(InterCon.Sounds[i] + " | " + InterCon.Points[i]);

        }
        sr.Close();

        
        LeFormateur.Serialize (LeFichier,data);
        LeFichier.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/sav.dat"))
        {
            BinaryFormatter LeFormateur = new BinaryFormatter();
            FileStream LeFichier = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);
            //LeData data = (LeData)LeFormateur.Deserialize(LeFichier);
            //LeFichier.Close();
            //agility = data.PlayerAGIL;
        }
    }

    [Serializable]
    class LeData
    {
        public String Texto;
    }
}

