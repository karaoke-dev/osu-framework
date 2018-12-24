﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using Foundation;
using osu.Framework.Input;

namespace osu.Framework.iOS.Input
{
    public class IOSTextInput : ITextInputSource
    {
        private readonly IOSGameView view;

        private string pending = string.Empty;

        public IOSTextInput(IOSGameView view)
        {
            this.view = view;
        }

        public bool ImeActive => false;

        public string GetPendingText()
        {
            try
            {
                return pending;
            }
            finally
            {
                pending = string.Empty;
            }
        }

        private void handleShouldChangeCharacters(NSRange range, string text)
        {
            if (text == " " || text.Trim().Length > 0)
                pending += text;
        }

        public void Deactivate(object sender)
        {
            view.KeyboardTextField.HandleShouldChangeCharacters -= handleShouldChangeCharacters;
            view.KeyboardTextField.UpdateFirstResponder(false);
        }

        public void Activate(object sender)
        {
            view.KeyboardTextField.HandleShouldChangeCharacters += handleShouldChangeCharacters;
            view.KeyboardTextField.UpdateFirstResponder(true);
        }

        public event Action<string> OnNewImeComposition;
        public event Action<string> OnNewImeResult;
    }
}
