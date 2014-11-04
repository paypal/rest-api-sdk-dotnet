﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PayPal.Api;

namespace PayPal.Util
{
    public class ArgumentValidator
    {
        /// <summary>
        /// Helper method for validating an argument that will be used by this API in any requests.
        /// </summary>
        /// <param name="argument">The object to be validated.</param>
        /// <param name="argumentName">The name of the argument. This will be placed in the exception message for easy reference.</param>
        public static void Validate(object argument, string argumentName)
        {
            if (argument is string)
            {
                if (string.IsNullOrEmpty(argument as string))
                {
                    throw new ArgumentNullException(argumentName + " cannot be null or empty");
                }
            }
            else if (argument == null)
            {
                throw new ArgumentNullException(argumentName + " cannot be null");
            }
        }

        /// <summary>
        /// Helper method for validating and setting up an APIContext object in preparation for it being used when sending an HTTP request.
        /// </summary>
        /// <param name="apiContext">APIContext used for API calls.</param>
        public static void ValidateAndSetupAPIContext(APIContext apiContext)
        {
            ArgumentValidator.Validate(apiContext, "APIContext");
            ArgumentValidator.Validate(apiContext.AccessToken, "AccessToken");
            if (apiContext.HTTPHeaders == null)
            {
                apiContext.HTTPHeaders = new Dictionary<string, string>();
            }
            apiContext.HTTPHeaders[BaseConstants.ContentTypeHeader] = BaseConstants.ContentTypeHeaderJson;
            apiContext.SdkVersion = new SDKVersion();
        }
    }
}
