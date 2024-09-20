using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFormsApp_Planning.Classes;

namespace TestFormsApp_Planning.Helpers
{
    public class OrdersHistory
    {
        private Stack<OrderAllocationsMemento> undoStack = new Stack<OrderAllocationsMemento>();
        private Stack<OrderAllocationsMemento> redoStack = new Stack<OrderAllocationsMemento>();

        public void SaveState(List<OrderAllocation> orders)
        {
            undoStack.Push(new OrderAllocationsMemento(orders));
            redoStack.Clear();  // Clear redo when a new action is performed
        }

        public OrderAllocationsMemento Undo()
        {
            if (undoStack.Count > 0)
            {
                var lastState = undoStack.Pop();
                redoStack.Push(lastState);
                return lastState;
            }
            return null;
        }

        public OrderAllocationsMemento Redo()
        {
            if (redoStack.Count > 0)
            {
                var nextState = redoStack.Pop();
                undoStack.Push(nextState);
                return nextState;
            }
            return null;
        }
    }
}
