using System;
using System.Globalization;
using System.Text;
using Molmed.PlattformOrdMan.Data;

namespace Molmed.PlattformOrdMan.Database
{
    public class SqlCommandBuilder
    {
        private Boolean MyHasParameters;
        private StringBuilder MyCommand;

        public SqlCommandBuilder(String storedProcedure)
        {
            MyCommand = new StringBuilder("EXECUTE " + storedProcedure);
            MyHasParameters = false;
        }

        private void AddParameterName(String parameterName)
        {
            if (MyHasParameters)
            {
                MyCommand.Append(",");
            }
            MyCommand.Append(" @");
            MyCommand.Append(parameterName);
            MyCommand.Append(" = ");
            MyHasParameters = true;
        }

        public void AddParameter(String parameterName, Boolean parameterValue)
        {
            AddParameterName(parameterName);
            if (parameterValue)
            {
                MyCommand.Append("1");
            }
            else
            {
                MyCommand.Append("0");
            }
        }

        public void AddParameter(String parameterName, DateTime parameterValue)
        {
            CultureInfo cultureInfo = PlattformOrdManData.MyCultureInfo;
            AddParameterName(parameterName);
            MyCommand.Append("'" + parameterValue.ToString("G", cultureInfo) + "'");
        }

        public void AddParameter(String parameterName, Double parameterValue)
        {
            AddParameterName(parameterName);
            MyCommand.Append(parameterValue.ToString().Replace(",", "."));
        }

        public void AddParameter(String parameterName, decimal parameterValue)
        {
            AddParameterName(parameterName);
            MyCommand.Append(parameterValue.ToString().Replace(",", "."));
        }

        public void AddParameter(String parameterName, Byte parameterValue)
        {
            AddParameterName(parameterName);
            MyCommand.Append(parameterValue.ToString());
        }

        public void AddParameter(String parameterName, Int16 parameterValue)
        {
            AddParameterName(parameterName);
            MyCommand.Append(parameterValue.ToString());
        }

        public void AddParameter(String parameterName, Int32 parameterValue)
        {
            AddParameterName(parameterName);
            MyCommand.Append(parameterValue.ToString());
        }

        public void AddParameter(String parameterName, String parameterValue)
        {
            if (parameterValue != null)
            {
                parameterValue = parameterValue.Replace("'", "''");
                AddParameterName(parameterName);
                MyCommand.Append("'");
                MyCommand.Append(parameterValue);
                MyCommand.Append("'");
            }
        }

        public String GetCommand()
        {
            return MyCommand.ToString();
        }
    }
}
