using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace ShortCircuit
{
    public static class ErrorLog
    {
        private static List<ErrorMessage> _errorMessages = new List<ErrorMessage>();
        public static int ErrorCount { get { return _errorMessages.Count; } }

        public static void Add(string message)
        {
            _errorMessages.Add(new ErrorMessage(message));
        }

        public static void Add(Exception exception)
        {
            try
            {
                if (exception.Message != "Thread was being aborted.")
                {
                    _errorMessages.Add(new ErrorMessage(exception.Message));
                    Exception ce = exception;
                    while (ce.InnerException != null)
                    {
                        _errorMessages.Add(new ErrorMessage(ce.InnerException.Message));
                        ce = ce.InnerException;
                    }
                }
            }
            catch { }
        }

        public static void Update()
        {
            try
            {
                foreach (var message in _errorMessages)
                {
                    message.Update();
                }
                for (var i = _errorMessages.Count - 1; i > 0; i--)
                {
                    if (_errorMessages[i].ValueTimer <= 0.1f)
                        _errorMessages.RemoveAt(i);
                }
            }
            catch { }
        }

        public static void Draw()
        {
            try
            {
                var height =
                    ScreenManager.Fonts[GameFonts.ErrorFont].MeasureString(
                        "QWERTYUIOPASDFGHJKLZXCVBNM!@#$%^&*()_+=-0987654321`").Y;
                
                var toWrite = "";

                for (int i = 0; i < _errorMessages.Count; i++)
                {
                    var err = _errorMessages[i];
                    toWrite = string.Format("{0} : {1}", ErrorCount - (_errorMessages.Count - i),
                                             _errorMessages[i].Message);

                    ScreenManager.Sprites.DrawString(ScreenManager.Fonts[GameFonts.ErrorFont], err.Message, new Vector2(0, i*(height+4)),
                                                     Color.White * err.ValueTimer);
                }
            }
            catch { }
        }

        class ErrorMessage
        {
            public float ValueTimer { get; set; }
            public string Message { get; set; }

            public ErrorMessage(string message)
            {
                Message = message;
                ValueTimer = 1f;
            }

            public void Update()
            {
                ValueTimer -= 0.005f;
            }
        }
    }
}
