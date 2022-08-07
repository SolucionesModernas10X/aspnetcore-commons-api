//
//  Copyright 2022  Soluciones Modernas 10x
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;
using System.Runtime.Serialization;

namespace Dev10x.AspnetCore.Commons.Api.Exceptions
{
    /// <summary>
    /// Exception that includes StatusCode for api rest operations
    /// </summary>
    [Serializable]
    public class ApiException : Exception
    {
        /// <summary>
        /// Http Status Code
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Constructor for exception with custom message and status code
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        public ApiException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        protected ApiException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
        }

        private ApiException()
        { }

    }
}
