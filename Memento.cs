using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Memento
    {
        public Dictionary<string, string> Content { get; set; }
        public List<string> FileName { get; set; }
    }

    public class Caretaker
    {
        private object memento;

        public void RestoreState(IOriginator Originator)
        {
            memento = Originator.GetMemento();
        }
    }

    public interface IOriginator
    {
        object GetMemento();
        void SetMemento(object memento);
    }
}
