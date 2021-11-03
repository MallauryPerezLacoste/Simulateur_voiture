using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ReadDataPort : MonoBehaviour
{
    //Create Serial Port
    [SerializeField]
    private string Port;

    [SerializeField]
    private int BaudRate;

    private SerialPort mySerialPort;

    //Return Values
    public List<int> Values;


    // Start is called before the first frame update
    void Start()
    {
        try
        {
            mySerialPort = new SerialPort(Port, BaudRate);
            mySerialPort.Open();
            Debug.Log("Serial Port opened");
        }
        catch
        {
            Debug.Log("Failed openning Serial Port");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        ReadValues();
    }

    void ReadValues()
    {
        Values.Clear();
        string[] data = mySerialPort.ReadLine().Split(',');

        for(int i = 0; i < data.Length; i++)
        {
            Values.Add(int.Parse(data[i]));
        }
    }
}
