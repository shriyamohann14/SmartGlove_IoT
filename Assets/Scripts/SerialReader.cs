


using UnityEngine;
using System;
using System.IO.Ports;

public class SerialReader : MonoBehaviour
{
    public string portName = "COM10";
    public int baudRate = 115200;

    private SerialPort serial;

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
    public int ax;
    public int ay;
    public int az;

    public int gx;
    public int gy;
    public int gz;

    void Start()
    {
        Debug.Log("SerialReader Started");

        try
        {
            serial = new SerialPort(portName, baudRate);
            serial.ReadTimeout = 100;
            serial.NewLine = "\n";

            serial.Open();

            Debug.Log("✅ Serial Port Opened: " + portName);
        }
        catch (Exception e)
        {
            Debug.LogError("❌ Could not open serial port.\n" + e.Message);
        }
    }

    void Update()
    {
        if (serial == null)
            return;

        if (!serial.IsOpen)
            return;

        try
        {
            string data = serial.ReadLine().Trim();

            // Uncomment ONLY if you want to see every line from Arduino
            // Debug.Log(data);

            string[] values = data.Split(',');
            string[] values = data.Split(',');

            if (values.Length != 11)
            {
                Debug.LogWarning("Received " + values.Length + " values instead of 11.");
                return;
            }

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

            Debug.Log($"Thumb:{thumb}  Index:{index}  Middle:{middle}  Ring:{ring}  Little:{little}");
        }
        catch (TimeoutException)
        {
            // Ignore normal serial timeouts
        }
        catch (Exception e)
        {
            Debug.LogError("Serial Parse Error:\n" + e.Message);
        }
    }

    void OnApplicationQuit()
    {
        if (serial != null && serial.IsOpen)
        {
            serial.Close();
            Debug.Log("Serial Port Closed");
        }
    }
}