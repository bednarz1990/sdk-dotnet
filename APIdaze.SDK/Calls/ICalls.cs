using System;
using System.Collections.Generic;
using APIdaze.SDK.Messages;

namespace APIdaze.SDK.Calls
{
    public interface ICalls
    {
        Guid CreateCall(PhoneNumber callerId, string origin, string destination, string callType);

        List<Call> GetCalls();

        Call GetCall(Guid id);

        void DeleteCall(Guid id);
    }
}