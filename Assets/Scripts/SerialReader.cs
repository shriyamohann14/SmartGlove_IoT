using UnityEngine;
using System.IO.Ports;

public class SerialReader : MonoBehaviour
{

    public string portName = "COM10";
    public int baudRate = 115200;


    SerialPort serialPort;


    public int thumb;
    public int index;
    public int middle;
    public int ring;
    public int little;


    void Start()
    {
        serialPort = new SerialPort(portName, baudRate);

        serialPort.Open();

        serialPort.ReadTimeout = 50;
    }


    void Update()
    {
        if(serialPort.IsOpen)
        {
            try
            {
                string data = serialPort.ReadLine();

                string[] values = data.Split(',');


                if(values.Length == 5)
                {
                    thumb = int.Parse(values[0]);
                    index = int.Parse(values[1]);
                    middle = int.Parse(values[2]);
                    ring = int.Parse(values[3]);
                    little = int.Parse(values[4]);

                    Debug.Log(data);
                }
            }

            catch{}
        }
    }


    void OnApplicationQuit()
    {
        serialPort.Close();
    }
}