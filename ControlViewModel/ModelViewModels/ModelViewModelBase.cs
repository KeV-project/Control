using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections;
using GalaSoft.MvvmLight;

namespace ControlViewModel.ModelViewModels
{
	public abstract class ModelViewModelBase: ViewModelBase, 
		INotifyDataErrorInfo
	{
        private Dictionary<string, List<string>> _errors =
            new Dictionary<string, List<string>>();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                return _errors[propertyName];
            }
            return null;
        }

        public bool HasErrors
        {
            get
            {
                return _errors.Count > 0;
            }
        }

        public bool IsValid
        {
            get
            {
                return !HasErrors;
            }
        }

        public void AddError(string propertyName, string error)
        {
            _errors[propertyName] = new List<string>() { error };
            NotifyErrorsChanged(propertyName);
            RaisePropertyChanged(nameof(IsValid));
        }

        public void RemoveError(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                _errors.Remove(propertyName);
            }
            NotifyErrorsChanged(propertyName);
            RaisePropertyChanged(nameof(IsValid));
        }

        public void NotifyErrorsChanged(string propertyName)
        { 
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(
                propertyName));
        }
    }
}
