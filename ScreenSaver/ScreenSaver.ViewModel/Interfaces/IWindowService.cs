﻿using ScreenSaver.ViewModel.Bases;

namespace ScreenSaver.ViewModel.Interfaces;

public interface IWindowService<TViewModel, TResult> where TViewModel : ViewModelBase
													 where TResult : class
{
	public TResult Show(TViewModel viewModel);
	public Task<TResult> ShowAsync(TViewModel viewModel);
}

public interface IWindowService<TViewModel> where TViewModel : ViewModelBase
{
	public void Show(TViewModel viewModel);
	public Task ShowAsync(TViewModel viewModel);
}
