using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPatternConsole
{

    public interface Command
    {
        void Execute();
        void Undo();
    }

}