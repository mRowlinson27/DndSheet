using System;

namespace DataManipulation.API.EntryData
{
    public interface IEntryData
    {
        int Eid { get; set; }
        object Output { get; }
        event EventHandler Update;
        void AddSubscriber(IEntryData data, object change);
        void UnSubscribeTo(IEntryData data);
        void SubscribeTo(IEntryData data, object change);
    }
}
