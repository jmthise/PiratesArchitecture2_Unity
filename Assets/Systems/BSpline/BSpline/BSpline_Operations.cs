using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pirates.BSpline {
    public partial class BSpline {
        private List<IBSplineOperation> operations_prev = new List<IBSplineOperation>();
        private List<IBSplineOperation> operations_next = new List<IBSplineOperation>();
        public void Operate(IBSplineOperation operation) {
            if (operation.Execute(this)) operations_prev.Add(operation);
            operations_next.Clear();
        }

        public bool UndoOperation() {
            if (operations_prev.Count <= 0) return false;
            var operation = operations_prev[operations_prev.Count - 1];
            if (operation.Undo(this)) {
                Debug.Log("Undo");
                operations_prev.RemoveAt(operations_prev.Count - 1);
                operations_next.Add(operation);
                return true;
            }
            return false;
        }

        public bool RedoOperation() {
            if (operations_next.Count <= 0) return false;
            var operation = operations_next[operations_next.Count - 1];
            if (operation.Execute(this)) {
                Debug.Log("Redo");
                operations_next.RemoveAt(operations_next.Count - 1);
                operations_prev.Add(operation);
                return true;
            }
            return false;
        }
    }
}