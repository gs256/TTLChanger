using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TTLChanger
{
    public class WindowViewModel : BaseViewModel
    {

        #region Private properties

        private int _currentTTL = TTLMng.GetDefaultTTL();
        //private int _currentTTL = 1;
        private int _textBoxValue;

        #endregion


        #region Public properties

        /// <summary>
        /// Current ttl value
        /// </summary>
        public string CurrentTTL {
            get
            {
                return _currentTTL != 0 && _currentTTL > 0 && _currentTTL < 999 ? _currentTTL.ToString() : "NS";
            }
            set
            {
                _currentTTL = Convert.ToInt32( value);
            }
        }

        /// <summary>
        /// Text of the label below ttl value 
        /// </summary>
        public string TTLLabel {
            get
            {
                //return _currentTTL != 0 && _currentTTL > 0 && _currentTTL < 999 ? "Default TTL" : "Not set";
                return "Default TTL";
            }
            set { } }

        /// <summary>
        /// Value of the textbox
        /// </summary>
        public string TextBoxValue{
            get
            {
                return _textBoxValue > 0 ? _textBoxValue.ToString() : "";
            }
            set
            {
                try
                {
                    _textBoxValue = Convert.ToInt32(value);
                }
                catch { }
            } }

        #endregion


        #region Commands

        /// <summary>
        /// Minimize window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// Maximize window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// Set ttl value
        /// </summary>
        public ICommand SetTTL { get; set; }

        /// <summary>
        /// Create a desktop shortcut of the application
        /// </summary>
        public ICommand CreateShortcut { get; set; }

        /// <summary>
        /// Set system ttl value (delete value "DefaultTTL" from registry)
        /// </summary>
        public ICommand SetSystemTTL { get; set; }

        #endregion


        #region Constructor

        public WindowViewModel()
        {
            MinimizeCommand = new RelayCommand(() => Application.Current.MainWindow.WindowState = WindowState.Minimized);

            CloseCommand = new RelayCommand(() => Application.Current.MainWindow.Close());

            SetTTL = new RelayCommand(() =>
            {
                if (_textBoxValue > 0 && _textBoxValue < 256)
                {
                    TTLMng.SetDefaultTTL(_textBoxValue);
                    UpdateScreenTTLValue(_currentTTL);
                    OnPropertyChanged(nameof(TTLLabel));
                }
            });

            CreateShortcut = new RelayCommand(() =>AppMng.CreateShortcut() );

            SetSystemTTL = new RelayCommand(() =>
            {
                TTLMng.RestoreSystemTTLValue();
                UpdateScreenTTLValue(_currentTTL);
             });

        }

        #endregion

        // Update screen ttl value
        private async void UpdateScreenTTLValue(int prevTTL)
        {
            int actualTTL = prevTTL;

            for (int i = 0; i < 40; i++)
            {
                actualTTL = TTLMng.GetDefaultTTL();

                if (actualTTL != prevTTL)
                    break;

                await Task.Delay(50);
            }

            if (prevTTL == actualTTL)
                return;
            else
                ScreenTTLValueTransition(prevTTL, actualTTL, 1);
            
        }

        // Smooth transition between previous and actual screen ttl values
        private async void ScreenTTLValueTransition(int prevTTL, int actualTTL, int delay)
        {
            int _cTtl = prevTTL;
            int aTtl = actualTTL;

            if (actualTTL > prevTTL)
            {
                while (_currentTTL < actualTTL)
                {
                    _currentTTL++;
                    OnPropertyChanged(nameof(CurrentTTL));
                    IncDelay(ref delay, 1500, _cTtl, aTtl);
                    await Task.Delay(delay);
                }
            }
            else if (actualTTL < prevTTL)
            {
                while (actualTTL < _currentTTL)
                {
                    _currentTTL--;
                    OnPropertyChanged(nameof(CurrentTTL));
                    IncDelay(ref delay, 1500, _cTtl, aTtl);
                    await Task.Delay(delay);
                }
            }

        }

        private void IncDelay(ref int delay, int time, int startPont, int endPoint)
        {
            int n = Math.Abs(endPoint - startPont);
            float d = 0;
            float x1 = (2 * (time - 1 * n));
            float x2 = (n * n - n);
            if ((int)x2 != 0)
                d = x1 / x2;
            if (d < 1)
                d = 1f;
            //Debug.WriteLine(d);
            delay += (int)d;
        }

    }
}
