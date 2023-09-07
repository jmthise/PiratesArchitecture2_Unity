using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pirates.BSpline {
    public partial class BSpline {
        public event Action OnModified;
        void DispatchModified() => OnModified?.Invoke();
    }
}