using System;
using System.Collections.Generic;
using System.Text;

namespace PlayBall
{
    interface IBasicUserInterface
    {
        void Output(string message);

        void PauseOutput();

        Object PromptForSelection(Object[] options);
    }
}
