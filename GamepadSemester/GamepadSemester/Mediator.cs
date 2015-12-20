using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamepadClientNamespace;

namespace GamepadSemester
{
    class Mediator
    {
        static public string SetConnection(string address, string port)
        {
            try
            {
                GamepadClient.Connect(address, port);
                return "Connection established";
            }
            catch (Exception)
            {
                return "Connect error";
            }
        }

        static public string Send(int buttonNumber)
        {
            try
            {
                GamepadClient.Send(buttonNumber);

                return "";
            }
            catch (SendingErrorException)
            {
                return "Sending error. Check receiver settings";
            }
        }
    }
}
