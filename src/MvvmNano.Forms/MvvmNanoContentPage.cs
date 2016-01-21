﻿/*****************************************************************************
 * Copyright (c) Thomas Bandt (https://thomasbandt.com). Licensed under the 
 * MIT License. See LICENSE file in the project root for detailed information. 
 ****************************************************************************/
using System;
using Xamarin.Forms;
using System.Linq.Expressions;

namespace MvvmNano.Forms
{
    public abstract class MvvmNanoContentPage<TViewModel> : ContentPage, IView
        where TViewModel : IViewModel
    {
        protected TViewModel ViewModel
        {
            get { return (TViewModel)BindingContext; }
        }

        protected void BindToViewModel(BindableObject self, BindableProperty targetProperty, 
            Expression<Func<TViewModel, object>> sourceProperty, BindingMode mode = BindingMode.Default, 
            IValueConverter converter = null, string stringFormat = null)
        {
            self.SetBinding(targetProperty, sourceProperty, mode, converter, stringFormat);
        }

        public void SetViewModel(IViewModel viewModel)
        {
            BindingContext = viewModel;

            OnViewModelSet();
        }

        public virtual void OnViewModelSet()
        {
            // Hook
        }

        public virtual void Dispose()
        {
            ViewModel.Dispose();
            BindingContext = null;
            Content = null;
        }
    }
}

