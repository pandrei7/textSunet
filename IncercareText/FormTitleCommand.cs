using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncercareText
{
    class FormTitleCommand : ICommand
    {
        public string Value { get; private set; }

        public FormTitleCommand(string title)
        {
            Value = title;
        }
    }
}
