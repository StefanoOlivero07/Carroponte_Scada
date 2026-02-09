using S7.Net;

namespace Scada.Core
{
    public class PlcScada
    {
        static Plc? myPlc = null;
        private const string OK = "OK";

        private static PlcScada? _instance = null;

        private PlcScada(string ipAddress)
        {
            if (myPlc == null)
            {
                if (ipAddress == null)
                    ipAddress = "192.168.2.111";
                myPlc = new Plc(CpuType.S71500, ipAddress, 0, 1);
            }
        }

        public static PlcScada GetInstance(string address)
        {
            if (_instance == null)
                _instance = new PlcScada(address);
            return _instance;
        }

        public string ConnectPlc()
        {
            try
            {
                myPlc!.Open();
                DisableBits();
                return OK;
            }
            catch (Exception ex)
            {
                _instance = null;
                myPlc = null;
                return ex.Message;
            }
        }

        public string DisconnectPlc()
        {
            try
            {
                DisableBits();
                myPlc!.Write("DB1.DBX0.0", true);
                myPlc.Close();
                _instance = null;
                myPlc = null;
                return OK;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public void Automatic()
        {
            try
            {
           
                DisableBits();
                myPlc!.Write("DB1.DBX0.1", true);
            }
            catch (Exception) { }
        }

        public void Manual()
        {
            try
            {
                DisableBits();
                myPlc!.Write("DB1.DBX0.2", true);
            }
            catch(Exception) { }
        }

        public void Stop()
        {
            try
            {
               
                DisableBits();
                myPlc!.Write("DB1.DBX0.0", true);
            }
            catch (Exception) { }
        }

        public void Emergency()
        {
            try
            {
              
                DisableBits();
                myPlc!.Write("DB1.DBX0.4", false);
            }
            catch (Exception) { }
        }

        public void Reset()
        {
            try
            {
                DisableBits();
                myPlc!.Write("DB1.DBX0.3", true);
            }
            catch (Exception) { }
        }

        public void GoLeft(bool active)
        {
            try
            {
                myPlc!.Write("DB1.DBX1.2", false);
                myPlc.Write("DB1.DBX1.1", active);
            }
            catch (Exception) { }
        }

        public void GoRight(bool active)
        {
            try
            {
                myPlc!.Write("DB1.DBX1.1", false);
                myPlc.Write("DB1.DBX1.2", active);
            }
            catch (Exception) { }
        }

        public void GoForward(bool active)
        {
            try
            {
                myPlc!.Write("DB1.DBX0.7", false);
                myPlc.Write("DB1.DBX1.0", active);
            }
            catch (Exception) { }
        }

        public void GoBack(bool active)
        {
            try
            {
                myPlc!.Write("DB1.DBX1.0", false);
                myPlc.Write("DB1.DBX0.7", active);

         
            }
            catch (Exception) { }
        }

        public void GoUp(bool active)
        {
            try
            {
                myPlc!.Write("DB1.DBX0.6", false);
                myPlc.Write("DB1.DBX0.5", active);


             
            }
            catch (Exception) { }
        }

        public void GoDown(bool active)
        {
            try
            {
                myPlc!.Write("DB1.DBX0.5", false);
                myPlc.Write("DB1.DBX0.6", active);

             

            }
            catch (Exception) { }
        }
        public void DisableBits()
        {
            myPlc!.Write("DB1.DBX0.0", false);
            myPlc.Write("DB1.DBX0.1", false);
            myPlc.Write("DB1.DBX0.2", false);
            myPlc.Write("DB1.DBX0.3", false);
            // Emergency bit
            myPlc.Write("DB1.DBX0.4", true);
            myPlc.Write("DB1.DBX0.5", false);
            myPlc.Write("DB1.DBX0.6", false);
            myPlc.Write("DB1.DBX0.7", false);
            myPlc.Write("DB1.DBX1.0", false);
            myPlc.Write("DB1.DBX1.1", false);
            myPlc.Write("DB1.DBX1.2", false);
        }

        
    }
}
