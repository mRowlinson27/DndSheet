using System;

namespace CustomForms.API.DTOs
{
    public interface IControlEvents
    {
        event EventHandler Click;
        event EventHandler MouseEnter;
        event EventHandler TextChanged;
        event EventHandler Enter;
    }
}
