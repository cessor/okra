using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Okra.Model
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        // Equality comparer allows to have a generic setter and not repeat the "did it changed" checks
        // http://danrigby.com/2012/01/08/inotifypropertychanged-the-anders-hejlsberg-way/

        // To avoid race condition when calling events
        // http://blogs.msdn.com/b/ericlippert/archive/2009/04/29/events-and-races.aspx
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler == null) return;
            handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string ResolveFromExpression<T>(Expression<Func<T>> expression)
        {
            return ((MemberExpression) expression.Body).Member.Name;
        }

        protected void Set<T>(Expression<Func<T>> func, ref T field, T value)
        {
            string name = ResolveFromExpression(func);
            Set(name, ref field, value);
        }

        private void Set<T>(string propertyName, ref T field, T value)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return;
            field = value;
            NotifyPropertyChanged(propertyName);
        }
    }
}