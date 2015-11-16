﻿using System;
using System.Web.UI;

namespace WebForms.vNextinator.Mvpvm
{
    public abstract class PageView<TPresenter, TViewModel> : Page 
        where TViewModel : IViewModel 
        where TPresenter : IPresenter<TViewModel>
    {
        private NotifyPropertyChangedEventMapper _mapper;

        protected PageView()
        {
        }

        protected PageView(TPresenter presenter) : this()
        {
            _mapper = new NotifyPropertyChangedEventMapper(presenter.ViewModel, this);
            Presenter = presenter;
        }

        protected TPresenter Presenter { get; private set; }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            if (_mapper != null)
            {
                _mapper.Dispose();
            }
        }
    }
}