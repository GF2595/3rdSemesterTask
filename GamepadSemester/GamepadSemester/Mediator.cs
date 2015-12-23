using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamepadClientNamespace;

namespace GamepadSemester
{
    static class Mediator
    {
        static private int buttonsAmount = 0;

        static public void buttonsAmountHasChanged(int newButtonsAmount)
        {
            buttonsAmount = newButtonsAmount;
        }

        static public int getButtonsAmount()
        {
            return buttonsAmount;
        }

        static public void getCurrentlyUsedIPAddressAndPort(out string ipAddress, out string port)
        {            
            GamepadClient.getCurrentIPAddressAndPort(out ipAddress, out port);
        }

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
