using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPatternWithGameObjects
{

    public interface Command
    {
        void Execute();
        void Undo();
    }

}