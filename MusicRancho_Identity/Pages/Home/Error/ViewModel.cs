// Copyright (c) Duende Software. All rights reserved.
using Duende.IdentityServer.Models;
namespace UI.Pages.Error;
public class ViewModel
{
    public ViewModel()
    {
    }
    public ViewModel(string error)
    {
        Error = new ErrorMessage { Error = error };
    }
    public ErrorMessage Error { get; set; }
}