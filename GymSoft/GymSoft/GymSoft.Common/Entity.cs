using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace GymSoft.Common
{
    public abstract class Entity : INotifyPropertyChanged, IDataErrorInfo
    {
        public virtual string Error
        {
            get { return String.Empty; }
        }

        public virtual string this[string columnName]
        {
            get { return String.Empty; }
        }

        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Method supports event.")]
        protected void RaisePropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
