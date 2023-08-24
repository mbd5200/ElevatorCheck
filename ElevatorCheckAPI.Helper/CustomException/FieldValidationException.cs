using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCheckAPI.Helper.CustomException
{
    public class FieldValidationException : Exception
    {
        public FieldValidationException(List<string> messageList)
        {
            base.Data["FieldValidationMessage"] = messageList;
        }
    }
}
