using System;

namespace Bale007.Bindables
{
    public class BindableBoolean
    {
        private bool value;

        public BindableBoolean(bool value)
        {
            this.value = value;
        }

        public bool Value
        {
            get => value;
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    changed?.Invoke(value);
                }
            }
        }

        public event Action<bool> changed;
    }
}