using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamepadClientNamespace;
using Windows.UI.Input;

namespace GamepadSemester
{
    static class Mediator
    {
        static private int buttonsAmount = 0;

        static public void ButtonsAmountHasChanged(string buttonsAmountString)
        {
            int amount = 0;

            bool result = int.TryParse(buttonsAmountString, out amount);

            if (result)
            {
                if (amount < 0)
                {
                    buttonsAmount = 0;
                }
                else if (amount > 200)
                {
                    buttonsAmount = 200;
                }
                else
                {
                    buttonsAmount = amount;
                }
            }
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

        static public void DPadPressed(PointerPoint point, string dPadName)
        {
            GamepadClient.Send(RecordMaker.MakeDPadPressRecord(point, dPadName));
        }

        static public void DPadReleased(string dPadName)
        {
            GamepadClient.Send(RecordMaker.MakeDPadReleaseRecord(dPadName));
        }

        static public void ButtonPressed(int buttonId)
        {
            GamepadClient.Send(RecordMaker.MakeButtonPressedRecord(buttonId));
        }
    }
}
