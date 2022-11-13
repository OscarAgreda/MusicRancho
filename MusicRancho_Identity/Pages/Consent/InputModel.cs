// Copyright (c) Duende Software. All rights reserved.

namespace UI.Pages.Consent;

public class InputModel
{
    public string Button { get; set; }
    public IEnumerable<string> ScopesConsented { get; set; }
    public bool RememberConsent { get; set; } = true;
    public string ReturnUrl { get; set; }
    public string Description { get; set; }
}