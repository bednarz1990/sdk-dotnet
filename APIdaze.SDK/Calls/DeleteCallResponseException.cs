﻿using System;

namespace APIdaze.SDK.Calls
{
    public class DeleteCallResponseException : SystemException
    {
        public DeleteCallResponseException(string message) : base(message)
        {
        }
    }
}