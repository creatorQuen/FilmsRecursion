using System;
using System.Collections.Generic;
using System.Text;

namespace FilmsRecursion
{
    public class ZadachaZapolnenia
    {
        public static List<int> BoxSizes; // Один общий для всех.
        public int EmptyPlace; // Сколько места останлось в конкретной ноде.

        public List<int> CurrentBoxes;

        public ZadachaZapolnenia(int emptyPlace, List<int> currtneBox)
        {
            // Надо понимать сколько свободного места.
            // И какие коробки уже лежат.

            EmptyPlace = emptyPlace;
            CurrentBoxes = currtneBox;

        }

    }
}
