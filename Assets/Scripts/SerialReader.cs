


using UnityEngine;
using System.IO.Ports;

public class SerialReader : MonoBehaviour
{
    public string portName = "COM7";
    public int baudRate = 115200;

    SerialPort serial;

    public int thumb;
    public int index;
    public int middle;
    public int ring;
    public int little;

    public int ax;
    public int ay;
    public int az;

    public int gx;
    public int gy;
    public int gz;

    void Start()
    {
        serial = new SerialPort(portName, baudRate);
        serial.ReadTimeout = 50;

        try
        {
            serial.Open();
        }
        catch
        {
            
        }
    }

    void Update()
    {
        if (serial == null || !serial.IsOpen)
            return;

        try
        {
            string data = serial.ReadLine();

            string[] values = data.Split(',');

            if (values.Length == 11)
            {
                thumb = int.Parse(values[0]);
                index = int.Parse(values[1]);
                middle = int.Parse(values[2]);
                ring = int.Parse(values[3]);
                little = int.Parse(values[4]);

                ax = int.Parse(values[5]);
                ay = int.Parse(values[6]);
                az = int.Parse(values[7]);

                gx = int.Parse(values[8]);
                gy = int.Parse(values[9]);
                gz = int.Parse(values[10]);
            }
        }
        catch
        {

        }
    }

    void OnApplicationQuit()
    {
        if (serial != null && serial.IsOpen)
            serial.Close();
    }
}