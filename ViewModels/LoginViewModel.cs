using System;
using System.Net;
using System.Security;
using System.Windows;
using System.Windows.Input;
using ModernUI.Models;
using ModernUI.Views;
using ModernUI.Repositories;

namespace ModernUI.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private SecureString? _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public SecureString? Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public bool IsViewVisible
        {
            get => _isViewVisible;
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }
        
        private IUserRepository _repository;

        public LoginViewModel()
        {
            _repository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(ExecuteRecoverPasswordCommand);
        }

        private void ExecuteLoginCommand(object obj)
        {
            bool isValid = _repository.AuthenticateUser(new NetworkCredential(Username, Password));
            if (isValid)
            {
                IsViewVisible = false;
                MainView window = new MainView();
                window.Show();
            }
            else
                ErrorMessage = "* Invalid username or password";
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData = !(string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                               Password == null || Password.Length < 3);
            return validData;
        }

        private void ExecuteRecoverPasswordCommand(object obj)
        {

        }

    }
}