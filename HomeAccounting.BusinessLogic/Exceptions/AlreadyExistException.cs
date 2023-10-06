using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.BusinessLogic.Exceptions
{
    public class AlreadyExistException:Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="AlreadyExistException"/>
        /// </summary>
        public AlreadyExistException()
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="AlreadyExistException"/>
        /// </summary>
        /// <param name="message">The message of the exception</param>
        public AlreadyExistException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="AlreadyExistException"/>
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="ex">The exception</param>
        public AlreadyExistException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
