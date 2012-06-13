using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDSGiaKiem
{
    public class FilterParameter : ICloneable
    {
        private string _ParamaterName = string.Empty;
        private object _ParamaterValue = null;
        private object _ParamaterType = null;
        private bool _IsOutParameter = false;    //parameter direction, true is IN, false is OUTPUT
        public FilterParameter()
        {
            _ParamaterName = string.Empty;
            _ParamaterValue = null;
            _ParamaterType = null;
            _IsOutParameter = false; //default is Input Parameter
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterParameter"/> class.
        /// </summary>
        /// <param name="paramaterName">Name of the paramater.</param>
        /// <param name="paramaterValue">The paramater value.</param>
        /// <param name="paramaterType">Type of the paramater.</param>
        public FilterParameter(string paramaterName, object paramaterValue, object paramaterType)
        {
            _ParamaterName = paramaterName;
            _ParamaterValue = paramaterValue;
            _ParamaterType = paramaterType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterParameter"/> class.
        /// </summary>
        /// <param name="paramaterName">Name of the paramater.</param>
        /// <param name="paramaterValue">The paramater value.</param>
        /// <param name="paramaterType">Type of the paramater.</param>
        /// <param name="parameterDirection">if set to <c>false</c> OUTPUT, if set to <c>true</c> INPUT</param>
        public FilterParameter(string paramaterName, object paramaterValue, object paramaterType, bool isOutParam)
            : this(paramaterName, paramaterValue, paramaterType)
        {
            _IsOutParameter = isOutParam;
        }

        public string ParamaterName
        {
            get { return _ParamaterName; }
            set { _ParamaterName = value; }
        }
        public object ParamaterValue
        {
            get { return _ParamaterValue; }
            set { _ParamaterValue = value; }
        }
        public object ParamaterType
        {
            get { return _ParamaterType; }
            set { _ParamaterType = value; }
        }

        public bool IsOutParameter
        {
            get { return _IsOutParameter; }
            set { _IsOutParameter = value; }
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns></returns>
        public FilterParameter Clone()
        {
            return new FilterParameter
            {
                ParamaterName = ParamaterName,
                ParamaterType = ParamaterType,
                ParamaterValue = ParamaterValue,
                IsOutParameter = IsOutParameter
            };
        }


        #region ICloneable Members

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        object ICloneable.Clone()
        {
            return Clone();
        }

        #endregion
    }

}
